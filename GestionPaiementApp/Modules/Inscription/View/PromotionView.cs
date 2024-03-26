using GestionPaiementApp.Extension;
using GestionPaiementApp.Model;
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
  
    public partial class PromotionView : UserControl
    {
        Promotion promotion;
        List<Promotion> promotions;

        NiveauView niveauView;
        Global.Popup Popup;

        public PromotionView()
        {
            promotions = new List<Promotion>();
            InitializeComponent();
        }

        private void btnAddNiveau_Click(object sender, EventArgs e)
        {
            niveauView = new NiveauView();
            Popup = new Global.Popup(niveauView);

            Popup.ShowDialog();

            AddNiveau(niveauView.Instance);  
        }

        async Task LoadNiveau()
        {
            //Dao.Helper.ConnectionHelper.GetNewInstance();

            cmbNiveau.Items.Clear();
            cmbNiveau.AutoCompleteCustomSource.Clear();

            var list = await Task.Run(() => new Dao.NiveauDao().GetAllAsync());

            cmbNiveau.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNiveau.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                cmbNiveau.AutoCompleteCustomSource.Add(row.ToString());
                cmbNiveau.Items.Add(row);
            }

            cmbNiveau.SelectedIndex = list.Count > 0 ? 0 : -1;
        }

        async Task LoadDepartement()
        {
            cmbDepartement.Text = string.Empty;
            cmbDepartement.Items.Clear();

            if (cmbFaculte.SelectedItem == null)
                return;

            var faculte = (Faculte)cmbFaculte.SelectedItem;

            var list = await Task.Run(() => new Dao.DepartementDao().GetAllAsync(faculte));

            cmbDepartement.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDepartement.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                cmbDepartement.AutoCompleteCustomSource.Add(row.ToString());
                cmbDepartement.Items.Add(row);
            }

            cmbDepartement.SelectedIndex = list.Count > 0 ? 0 : -1;
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        async Task LoadFaculte()
        {
            tokenSource = new CancellationTokenSource();

            cmbFaculte.Items.Clear();
            cmbFaculte.AutoCompleteCustomSource.Clear();

            var list = await Task.Run(() => new Dao.FaculteDao().GetAllAsync(tokenSource.Token));

            cmbFaculte.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFaculte.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                cmbFaculte.AutoCompleteCustomSource.Add(row.ToString());
                cmbFaculte.Items.Add(row);
            }

            cmbFaculte.SelectedIndex = list.Count > 0 ? 0 : -1;
        }

        public void StopProccess()
        {
            tokenSource.Cancel();
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;

            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Promotion", lstViewData.Width - 50);
        }

        void AddNiveau(Niveau row)
        {
            if (row.Id == null)
                return;

            cmbNiveau.AutoCompleteCustomSource.Add(row.ToString());
            cmbNiveau.Items.Add(row);
        }

        async Task LoadPromotion()
        {
            lstViewData.Items.Clear();

            var dao = new Dao.PromotionDao();
            dao.NewConnection();

            promotions = await Task.Run(() => dao.GetAllAsync());

            lblCount.Text = string.Format("({0})", promotions.Count);

            Add();
        }

        void Add(Promotion instance = null)
        {
            if (instance == null)
                foreach (var row in promotions)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {
                instance.Number = promotions.Count == 0 ? 1 : promotions.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(instance.data));

                promotions.Add(instance);
                lblCount.Text = string.Format("({0})", promotions.Count);
            }
        }

        private void btnRefreshD_Click(object sender, EventArgs e)
        {
            LoadDepartement();
        }

        private void btnRefreshF_Click(object sender, EventArgs e)
        {
            LoadFaculte();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Functions.IsEmptyTextBox(pnlZone))
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                promotion = new Promotion();
                promotion.Niveau = (Niveau)cmbNiveau.SelectedItem;
                promotion.Departement = (Departement)cmbDepartement.SelectedItem;
                promotion.Filiere = txtFiliere.Text;

                if (new Dao.PromotionDao().Add(promotion) > 0)
                {
                    MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Add(promotion);
                    Functions.InitTextBox(pnlZone);
                }
            }
        }

        private void PromotionView_Load(object sender, EventArgs e)
        {
            DrawListView();

            LoadFaculte();
            LoadNiveau();
            cmbFaculte.SelectedIndexChanged += cmbFaculte_SelectedIndexChanged;

            LoadPromotion();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPromotion();
        }

        private void cmbFaculte_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDepartement();
        }

        private void btnRefreshN_Click(object sender, EventArgs e)
        {
            LoadNiveau();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            lstViewData.Items.Clear();

            lstViewData.Items.AddRange(promotions.Where(i => string.IsNullOrEmpty(motif) || i.ToString().ToLower().Trim().NoAccent().StartsWith(motif) || i.ToString().ToLower().Trim().NoAccent().Contains(motif))
                .Select(c => new ListViewItem(c.data)).ToArray());
        }
    }
}
