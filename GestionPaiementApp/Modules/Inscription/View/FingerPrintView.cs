using DPFP;
using DPFP.Capture;
using DPFP.Error;
using GestionPaiementApp.Model;
using GestionPaiementApp.Model.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp.Modules.Inscription.View
{
    public partial class FingerPrintView : UserControl, DPFP.Capture.EventHandler
    {
        public List<EtudiantEmpreinte> empreintes { get; set; }

        object[] doigts = new object[]
            {
                "Pouce droit",
                "Pouce gauche",
                "Index droit",
                "Index gauche",
                "Majeur droit",
                "Majeur gauche",
                "Annulaire droit",
                "Annulaire gauche",
                "Auriculaire droit",
                "Auriculaire gauche"
            };

        string doigt;

        public FingerPrintView(Model.Inscription inscription)
        {
            etudiant = inscription.Etudiant;
            empreintes = new List<EtudiantEmpreinte>();

            InitializeComponent();

            FingerPrintController.Capturer.EventHandler = this;
            FingerPrintController.Start();
        }

        const int REGISTER_FINGER_COUNT = 4;

        byte[] fingerPrintImage;
        int ScanCount = 0;
        Etudiant etudiant;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected virtual void Process(DPFP.Sample Sample)
        {
            try
            {
                var img = FingerPrintUtil.ConvertSampleToBitmap(Sample);

                DrawPicture(img);

                var features = FingerPrintUtil.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
               
                if (features != null)  
                {
                    FingerPrintController.Enroller.AddFeatures(features);
                }

                ScanCount--;

                lblmsg.Invoke(new MethodInvoker(delegate
                {
                    lblmsg.Text = string.Format("Laissez reposer puis levez {0} fois votre le {1}", ScanCount, doigt.ToString()); ;
                }));

                if (FingerPrintController.Enroller.TemplateStatus == DPFP.Processing.Enrollment.Status.Ready)
                {
                    try
                    {
                        //("The fingerprint feature set was created.");
                           // Add feature set to template.

                        MemoryStream s = new MemoryStream();
                        FingerPrintController.Enroller.Template.Serialize(s);

                        var empreinte = new EtudiantEmpreinte()
                        {
                            Etudiant = etudiant,
                            Image = fingerPrintImage,
                            Template = s.ToArray(),
                            Size = features.Size,
                            Finger = Dao.Helper.Util.ToFingers(doigt)
                        };

                        etudiant.Empreintes.Add(empreinte);
                        empreintes.Add(empreinte);

                        AddFingerInPanel(empreinte);

                        ScanCount = REGISTER_FINGER_COUNT;
                        FingerPrintController.Enroller.Clear();
                        fingerPrintImage = null;
                        pbFinger.Image = null;

                        lblmsg.Invoke(new MethodInvoker(delegate
                        {
                            lblmsg.Text = string.Format("Laissez reposer puis levez {0} fois votre le {1}", ScanCount, doigt.ToString()); ;
                        }));
                    }
                    catch (SDKException ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        private void DrawPicture(Bitmap bitmap)
        {
            fingerPrintImage = ImageUtil.Bitmap2ToByte(bitmap, bitmap.Size);
            pbFinger.Image = ImageUtil.ByteToBitmap(fingerPrintImage);
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
           
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            //lblmsg.Invoke(new MethodInvoker(delegate
            //{
            //    lblmsg.Text = "Laissez reposer puis levez 4 fois votre le même doigt";
            //    lblmsg.ForeColor = Color.Black;
            //}));      
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            //lblmsg.Invoke(new MethodInvoker(delegate
            //{
            //    lblmsg.Text = "Lecteur d'emprinte non connecté, veuillez le connecter s'il vous plaît !";
            //    lblmsg.ForeColor = Color.Red;
            //}));
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good) ;
            //("The quality of the fingerprint sample is good.");
            else;
            //("The quality of the fingerprint sample is poor.");
        }

        private void FingerPrintView_Load(object sender, EventArgs e)
        {
            //InitDevice();
            cmbDoigts.Items.AddRange(doigts);
            cmbDoigts.SelectedIndex = 0;
        }

        private void cmbDoigts_SelectedIndexChanged(object sender, EventArgs e)
        {
            doigt = ((ComboBox)sender).SelectedItem.ToString();
            ScanCount = REGISTER_FINGER_COUNT;
        }

        void AddFingerInPanel(EtudiantEmpreinte empreinte)
        {
            Panel panel = new Panel();

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(70, 90);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = ImageUtil.ByteToBitmap(empreinte.Image);
            pictureBox.Location = new Point(2, 2);

            Label label = new Label();
            label.Text = empreinte.Finger.ToString();
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Size = new Size(70, 20);
            label.Font = new Font("Segoe UI", 9);
            label.ForeColor = Color.Black;
            label.Location = new Point(2, pictureBox.Height + 10);

            var _size = new Size(70, pictureBox.Height + label.Height + 10);

            panel.Size = _size;
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);

            flowLayoutPanelFingers.Invoke(new MethodInvoker(delegate
            {
                //flowLayoutPanelFingers.Padding = new Padding();
                flowLayoutPanelFingers.Controls.Add(panel);
            }));
        }

        private void btnValide_Click(object sender, EventArgs e)
        {
            Task.Delay(1000).Wait(1000);

            FingerPrintController.Stop();

            ((Form)this.TopLevelControl).Close();
        }
    }
}
