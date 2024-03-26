using GestionPaiementApp.Model;
using GestionPaiementApp.Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp.Modules.Inscription.View
{
    public partial class AddEtudiantView : UserControl
    {
        FingerPrintView fingerPrintView;
        PhotoView photoView;
        Global.Popup Popup;
        List<Departement> departements;
        List<Faculte> facultes;

        public Model.Inscription Inscription { get; set; }
        public bool IsModify { get; set; }

        public AddEtudiantView()
        {
            facultes = new List<Faculte>();
            departements = new List<Departement>();
            Inscription = new Model.Inscription();
            InitializeComponent();
            btnSave.Text = "Enregistrer";
            IsModify = false;
        }

        public AddEtudiantView(Model.Inscription inscription) : this()
        {
            Inscription = inscription;
            btnSave.Text = "Modifier";
            IsModify = true;
        }


        private void AddEtudiantView_Load(object sender, EventArgs e)
        {
            cmbSexe.SelectedIndex = 0;
            cmbVacation.SelectedIndex = 0;

            LoadFaculte();

            if (btnSave.Text == "Modifier")
            {
                pbPhoto.Image = Model.Helper.ImageUtil.ByteToBitmap(Inscription.Photo);

                cmbFaculte.Invoke(new MethodInvoker(delegate
                {
                    cmbFaculte.SelectedItem = Inscription?.Faculte as object;
                }));

                cmbDepartement.Invoke(new MethodInvoker(delegate
                {
                    cmbDepartement.Text = Inscription?.Promotion?.Departement?.ToString();
                }));

                cmbPromotion.Invoke(new MethodInvoker(delegate
                {
                    cmbPromotion.Text = Inscription?.Promotion?.ToString();
                }));


                cmbVacation.SelectedItem = Inscription.Vacation.ToString();

                txtMatricule.Text = Inscription?.Etudiant?.Matricule;
                txtNom.Text = Inscription?.Etudiant?.Nom;
                txtPostnom.Text = Inscription?.Etudiant?.Postnom;
                txtPrenom.Text = Inscription.Etudiant?.Prenom;
                cmbSexe.SelectedItem = Inscription?.Etudiant?.Sexe;
                txtTelephone.Text = Inscription?.Etudiant?.Telephone;
                txtAdresse.Text = Inscription?.Etudiant?.Adresse;

                if (Inscription.Etudiant.Empreintes.Count > 0)
                {
                    Inscription.Etudiant.Empreintes.ForEach(f => AddFingerInPanel(f));
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if (Functions.IsEmptyTextBox(this))
                MessageBox.Show("Remplissez tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Inscription.Annee = new Dao.AnneeAcademiqueDao().Get();
                Inscription.Promotion = (Promotion)cmbPromotion.SelectedItem;
                Inscription.Vacation = Dao.Helper.Util.ToVacationType(cmbVacation.SelectedItem.ToString().Trim());
                Inscription.Faculte = (Faculte)cmbFaculte.SelectedItem;

                Inscription.Etudiant.Matricule = txtMatricule.Text;
                Inscription.Etudiant.Nom = txtNom.Text;
                Inscription.Etudiant.Postnom = txtPostnom.Text;
                Inscription.Etudiant.Prenom = txtPrenom.Text;
                Inscription.Etudiant.Sexe = cmbSexe.SelectedItem.ToString();
                Inscription.Etudiant.Telephone = txtTelephone.Text;
                Inscription.Etudiant.Adresse = txtAdresse.Text;

                var succes = false;

                if (btn.Text.Trim().ToLower() == "enregistrer")
                {
                    if (new Dao.InscriptionDao().Add(Inscription) > 0)
                    {
                        MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Functions.InitTextBox(this);

                        succes = true;
                    }
                }
                else
                {
                    if (new Dao.InscriptionDao().Update(Inscription, null) > 0)
                    {
                        MessageBox.Show("Modification reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Functions.InitTextBox(this);

                        succes = true;

                        IsModify = true;
                    }
                }

                if (succes)
                {
                    Task.Delay(1000).Wait(1000);

                    ((Form)this.TopLevelControl).Close();
                }
            }
        }

        async Task LoadDepartement()
        {
            cmbDepartement.Text = string.Empty;
            cmbDepartement.Items.Clear();

            if (cmbFaculte.SelectedItem == null)
                return;

            var faculte = (Faculte)cmbFaculte.SelectedItem;

            var dao = new Dao.DepartementDao();
            dao.NewConnection();

            departements = await Task.Run(() => dao.GetAll(faculte));

            cmbDepartement.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDepartement.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in departements)
            {
                cmbDepartement.AutoCompleteCustomSource.Add(row.ToString());
                cmbDepartement.Items.Add(row);
            }

            if (btnSave.Text != "Modifier")
                cmbDepartement.SelectedIndex = departements.Count > 0 ? 0 : -1;
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        async Task LoadFaculte()
        {
            facultes = new List<Faculte>();
            tokenSource = new CancellationTokenSource();

            cmbFaculte.Items.Clear();
            cmbFaculte.AutoCompleteCustomSource.Clear();

            var dao = new Dao.FaculteDao();
            dao.NewConnection();

            facultes = await Task.Run(() => dao.GetAll2Async(tokenSource.Token));

            cmbFaculte.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFaculte.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in facultes)
            {
                cmbFaculte.AutoCompleteCustomSource.Add(row.ToString());
                cmbFaculte.Items.Add(row);
            }

            if (btnSave.Text != "Modifier")
                cmbFaculte.SelectedIndex = facultes.Count > 0 ? 0 : -1;
        }

        async Task LoadPromotion()
        {
            cmbPromotion.Text = string.Empty;
            cmbPromotion.Items.Clear();

            if (cmbDepartement.SelectedItem == null)
                return;

            var departement = (Departement)cmbDepartement.SelectedItem;

            var dao = new Dao.PromotionDao();
            dao.NewConnection();

            var list = await Task.Run(() => dao.GetAllAsync(departement));

            cmbPromotion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPromotion.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                //cmbNiveau.ValueMember = "Nom";
                cmbPromotion.AutoCompleteCustomSource.Add(row.ToString());
                cmbPromotion.Items.Add(row);
            }

            if (btnSave.Text != "Modifier")
                cmbPromotion.SelectedIndex = list.Count > 0 ? 0 : -1;
        }

        private void btnRefreshP_Click(object sender, EventArgs e)
        {
            LoadPromotion();
        }

        private void btnRefreshF_Click(object sender, EventArgs e)
        {
            LoadFaculte();
        }

        private void btnRefreshD_Click(object sender, EventArgs e)
        {
            LoadDepartement();
        }

        private void cmbFaculte_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDepartement();
        }

        private void cmbDepartement_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPromotion();
        }

        private void btnFinger_Click(object sender, EventArgs e)
        {
            fingerPrintView = new FingerPrintView(Inscription);
            Popup = new Global.Popup(fingerPrintView);
            Popup.ShowDialog();

            if(Inscription.Etudiant.Empreintes.Count > 0)
            {
                Inscription.Etudiant.Empreintes.ForEach(f => AddFingerInPanel(f));
            }       
        }


        void AddFingerInPanel(EtudiantEmpreinte empreinte)
        {
            Panel panel = new Panel();

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(50, 70);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = ImageUtil.ByteToBitmap(empreinte.Image);
            pictureBox.Location = new Point(2, 2);

            Label label = new Label();
            label.Text = empreinte.Finger.ToString();
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Size = new Size(50, 20);
            label.Font = new Font("Segoe UI", 9);
            label.ForeColor = Color.Black;
            label.Location = new Point(2, pictureBox.Height + 5);

            var _size = new Size(50, pictureBox.Height + label.Height + 5);

            panel.Size = _size;
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);

            flowLayoutPanel1.Invoke(new MethodInvoker(delegate
            {
                //flowLayoutPanelFingers.Padding = new Padding();
                flowLayoutPanel1.Controls.Add(panel);
            }));
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            photoView = new PhotoView();
            Popup = new Global.Popup(photoView);
            Popup.ShowDialog();

            pbPhoto.Image = Model.Helper.ImageUtil.ByteToBitmap(photoView.Image);

            Inscription.Photo = photoView.Image;
        }
    }
}
