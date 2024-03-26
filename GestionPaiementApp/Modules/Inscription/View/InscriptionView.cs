using GestionPaiementApp.Extension;
using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp.Modules.Inscription.View
{
    public partial class InscriptionView : UserControl
    {
        AddEtudiantView addEtudiantView = new AddEtudiantView();
        Global.Popup Popup;

        FingerPrintView fingerPrintView;
        PhotoView photoView;

        List<Model.Inscription> inscriptions;

        public InscriptionView()
        {
            inscriptions = new List<Model.Inscription>();
            addEtudiantView = new AddEtudiantView();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEtudiantView = new AddEtudiantView();
            Popup = new Global.Popup(addEtudiantView);
            Popup.ShowDialog();

            if(addEtudiantView.Inscription?.Id != null)
                Add(addEtudiantView.Inscription);
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;

            var sizeColumn = (lstViewData.Width - 470) / 3;

            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Etudiant", sizeColumn + 50);
            lstViewData.Columns.Add("Sexe", 50);
            lstViewData.Columns.Add("Téléphone", 100);
            lstViewData.Columns.Add("Adresse", sizeColumn);
            lstViewData.Columns.Add("Vacation", 70);
            lstViewData.Columns.Add("Faculté", sizeColumn);
            lstViewData.Columns.Add("Promotion", 150);
           



            //ListViewGroup group = new ListViewGroup(lstViewData[6]);

            //lstViewData.Groups.Add(group);
        }

        private void InscriptionView_Load(object sender, EventArgs e)
        {
            DrawListView();

            LoadAnneeAcademique();
        }

        private void btnRefreshD_Click(object sender, EventArgs e)
        {
            LoadAnneeAcademique();
        }

        async Task LoadAnneeAcademique()
        {
            cmbAnnee.Items.Clear();

            var dao = new Dao.AnneeAcademiqueDao();
            dao.NewConnection();

            var list = await Task.Run(() => dao.GetAllAsync());

            if (list == null)
                return;

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
            LoadInscription();
        }

        async Task LoadInscription()
        {
            lstViewData.Items.Clear();

            if (cmbAnnee.SelectedItem == null)
                return;

            var selectedAnnee = (AnneeAcademique)cmbAnnee.SelectedItem;

            inscriptions = await Task.Run(() => new Dao.InscriptionDao().GetAllAsync(selectedAnnee));

            lblCount.Text = string.Format("({0})", inscriptions.Count);

            Add();
        }

        void Add(Model.Inscription instance = null)
        {
            if (instance == null)
                foreach (var row in inscriptions)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {

                instance.Number = inscriptions.Count == 0 ? 1 : inscriptions.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(instance.data));
                //lstViewData.LargeImageList.Images.Add(Model.Helper.ImageUtil.ByteToBitmap(instance.Photo));

                inscriptions.Add(instance);
                lblCount.Text = string.Format("({0})", inscriptions.Count);
            }
        }

        private void cmbAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInscription();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();

            if (motif == null | inscriptions == null)
                return;

            lstViewData.Items.Clear();

            lstViewData.Items.AddRange(inscriptions.Where(i => 
                string.IsNullOrEmpty(motif) || 
                i.Etudiant.Name.ToLower().Trim().NoAccent().StartsWith(motif) || 
                i.Etudiant.Name.ToLower().Trim().NoAccent().Contains(motif) ||
                i.Promotion.ToString().ToLower().Trim().NoAccent().Contains(motif)
                )
                .Select(c => new ListViewItem(c.data)).ToArray());
        }

        Model.Inscription SelectedInscription = null;

        private void lstViewData_MouseClick(object sender, MouseEventArgs e)
        {
            var listView = (ListView)lstViewData;

            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }

                var key = int.Parse(focusedItem.Text);

                SelectedInscription = inscriptions.Find(i => i.Number == key);
            }
        }

        private void ModifierMenuContext_Click(object sender, EventArgs e)
        {
            addEtudiantView = new AddEtudiantView(SelectedInscription);
            Popup = new Global.Popup(addEtudiantView);
            Popup.ShowDialog();

            if (addEtudiantView.IsModify)
            {
                inscriptions.Find(i => i.Id == SelectedInscription.Id).Etudiant = addEtudiantView.Inscription.Etudiant;
                inscriptions.Find(i => i.Id == SelectedInscription.Id).Promotion = addEtudiantView.Inscription.Promotion;
                inscriptions.Find(i => i.Id == SelectedInscription.Id).Vacation = addEtudiantView.Inscription.Vacation;
            }
                
        }

        private void PhotoMenuContext_Click(object sender, EventArgs e)
        {
            photoView = new PhotoView();
            Popup = new Global.Popup(photoView);
            Popup.ShowDialog();

            var photo = photoView.Image;

            if (photo != null)
            {
                SelectedInscription.Photo = photo;
                if (new Dao.InscriptionDao().SetPhoto(SelectedInscription) > 0)
                {
                    MessageBox.Show(string.Format("La photo de {0} vient d'être changer avec succès !!", SelectedInscription.Etudiant.Name), "Changement photo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    inscriptions.Find(i => i.Id == SelectedInscription.Id).Photo = photo;
                }        
            }
        }

        private void FringerMenuContext_Click(object sender, EventArgs e)
        {
            fingerPrintView = new FingerPrintView(SelectedInscription);
            Popup = new Global.Popup(fingerPrintView);
            Popup.ShowDialog();

            var empreintes = fingerPrintView.empreintes;

            if (empreintes.Count > 0)
            {
                if(new Dao.EtudiantEmpreinteDao().SetEmpreintes(empreintes) > 0)
                {
                    MessageBox.Show(string.Format("Les empreintes digital de {0} vient d'être enregistrer avec succès !!", SelectedInscription.Etudiant.Name), "Changement photo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    inscriptions.Find(i => i.Id == SelectedInscription.Id).Etudiant.Empreintes = empreintes;
                }
            }         
        }
    }
}
