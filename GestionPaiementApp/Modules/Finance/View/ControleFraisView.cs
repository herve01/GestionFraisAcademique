using DPFP;
using DPFP.Capture;
using GestionPaiementApp.Extension;
using GestionPaiementApp.Model;
using GestionPaiementApp.Modules.Inscription.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp.Modules.Finance.View
{
    public partial class ControleFraisView : UserControl, DPFP.Capture.EventHandler
    {

        List<Model.POCO.PaiementDetail> paiements;
        Model.Inscription inscription;

        public ControleFraisView()
        {
            InitializeComponent();
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;

            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Etudiant", lstViewData.Width - 500);
            lstViewData.Columns.Add("Modalité paiement", 150);
            lstViewData.Columns.Add("Detail paiement", 300);
        }

        private void btnRefreshA_Click(object sender, EventArgs e)
        {
            LoadAnneeAcademique();
        }

        private void PaiementView_Load(object sender, EventArgs e)
        {
            DrawListView();
            ResetHistoEtud(null);

            LoadAnneeAcademique();
        }

        async Task LoadAnneeAcademique()
        {

            cmbAnnee.Items.Clear();
            cmbAnnee.AutoCompleteCustomSource.Clear();

            var dao = new Dao.AnneeAcademiqueDao();
            dao.NewConnection();

            var list = await Task.Run(() => dao.GetAllAsync());

            cmbAnnee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAnnee.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                cmbAnnee.AutoCompleteCustomSource.Add(row.ToString());
                cmbAnnee.Items.Add(row);
            }

            cmbAnnee.SelectedIndex = list.Count > 0 ? 0 : -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPaiement(inscription);
        }

        async Task LoadPaiement(Model.Inscription inscription)
        {
            lstViewData.Items.Clear();

            if (inscription == null)
                return;

            var dao = new Dao.PaiementDao();
            dao.NewConnection();

            paiements = await Task.Run(() => dao.GetInfoPaiementsAsync(inscription));

            int i = 0;

            foreach (var item in paiements)
            {
                if (i == 0)
                {
                    lstViewData.Invoke(new MethodInvoker(delegate
                    {
                        lstViewData.Items.Add(new ListViewItem(new string[] { "1", inscription.Etudiant.Name, inscription?.Type.ToString(), "*************************************" }));
                    }));
                }
                i++;

                lstViewData.Invoke(new MethodInvoker(delegate
                {
                    lstViewData.Items.Add(new ListViewItem(new string[] { "", "", "", item.ToString() }));
                }));
            }
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            //lstViewData.Items.Clear();

            //lstViewData.Items.AddRange(paiements.Where(i => string.IsNullOrEmpty(motif) ||
            //i.Inscription.Etudiant.Name.ToLower().Trim().NoAccent().StartsWith(motif) ||
            //i.Inscription.Etudiant.Name.ToLower().Trim().NoAccent().Contains(motif) ||
            //i.Inscription.Promotion.ToString().ToLower().Trim().NoAccent().Contains(motif)
            //)
            //.Select(p => new ListViewItem(p.data)).ToArray());
        }


        void ResetHistoEtud(Model.Inscription inscription)
        {
            pbEtudiant.Invoke(new MethodInvoker(delegate
            {
                var image = inscription?.Etudiant?.Sexe == "M" ? Properties.Resources.Principal_01 : Properties.Resources.Woman_04;

                pbEtudiant.Image = inscription?.Photo == null ? image :
                    Model.Helper.ImageUtil.ByteToBitmap(inscription?.Photo);

            }));

            lblName.Invoke(new MethodInvoker(delegate
            {
                lblName.Text = string.Format("{0}", inscription?.Etudiant?.Name ?? "NOMS : -");
            }));

            lblSexe.Invoke(new MethodInvoker(delegate
            {
                lblSexe.Text = string.Format("SEXE : {0}", inscription?.Etudiant?.Sexe ?? " -");
            }));

            lblPromotion.Invoke(new MethodInvoker(delegate
            {
                lblPromotion.Text = string.Format("{0}", inscription?.Promotion?.ToString() ?? "Promotion : -");

                LoadPaiement(inscription);
            }));            
        }

        private void PaiementFraisView_Load(object sender, EventArgs e)
        {
            DrawListView();

            ResetHistoEtud(null);

            LoadAnneeAcademique();
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
            
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good) ;
            //("The quality of the fingerprint sample is good.");
            else;
            //("The quality of the fingerprint sample is poor."); 
        }


        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        async Task Identify(DPFP.Sample Sample)
        {
            try
            {
               
                var finger = await Task.Run(() => new Dao.EtudiantEmpreinteDao().GetAsync(Sample));

                if (finger != null)
                {
                    var etudiant = finger?.Etudiant;

                    inscription = await Task.Run(() => new Dao.InscriptionDao().GetAsync(etudiant, SelectedAnnee));
                }

                CheckFinger(finger);
                //InitDevice();
            }
            catch (Exception e)
            {
                await ResetInfo();
                CheckFinger(null);
            }
        }


        void CheckFinger(EtudiantEmpreinte empreinte)
        {
            var image = empreinte == null ? Properties.Resources.Close : Properties.Resources.Check1 ;
            var text = empreinte == null ? "empreinte non reconnue" : "empreinte valide";

            pbError.Invoke(new MethodInvoker(delegate
            {
                pbError.Image = image;
            }));

            lblFinger.Invoke(new MethodInvoker(delegate
            {
                lblFinger.Text = text;
            }));

            ResetHistoEtud(empreinte == null ? null : inscription) ;
        }

        async Task ResetInfo()
        {
            await Task.Delay(5000);

            //Model.Inscription = null;
            //Presence = null;
            //DejaPointe = false;
            //Salutation = "Salut";
            //ScanStatus = string.Empty;
        }

        protected virtual void Process(DPFP.Sample Sample)
        {
            try
            {
                 Identify(Sample);
            }
            catch (Exception)
            {

            }
        }

        AnneeAcademique SelectedAnnee;
        private void cmbAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedAnnee = (AnneeAcademique)((ComboBox)sender).SelectedItem;
        }
    }
}
