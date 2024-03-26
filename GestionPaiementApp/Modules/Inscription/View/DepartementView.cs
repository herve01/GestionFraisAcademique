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
    public partial class DepartementView : UserControl
    {
        Departement departement;
        List<Departement> departements;

        public DepartementView()
        {
            departements = new List<Departement>();

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Functions.IsEmptyTextBox(pnlZone))
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                departement = new Departement();
                departement.Nom = txtNom.Text;
                departement.Faculte = (Faculte)cmbFaculte.SelectedItem;

                if (new Dao.DepartementDao().Add(departement) > 0)
                {
                    MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Add(departement);
                    Functions.InitTextBox(pnlZone);
                }
            }
        }
        CancellationTokenSource tokenSource = new CancellationTokenSource();

        async Task LoadFaculte()
        {
            tokenSource = new CancellationTokenSource();

            cmbFaculte.Items.Clear();
            cmbFaculte.AutoCompleteCustomSource.Clear();

            var dao = new Dao.FaculteDao();
            dao.NewConnection();

            var list = await Task.Run(() =>dao.GetAllAsync(tokenSource.Token));

            cmbFaculte.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFaculte.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                //cmbFaculte.ValueMember = "Nom";
                cmbFaculte.AutoCompleteCustomSource.Add(row.ToString());
                cmbFaculte.Items.Add(row);
            }

            cmbFaculte.SelectedIndex = list != null ? 0 : -1;
        }

        async Task LoadDepartement()
        {
            lstViewData.Items.Clear();

            departements = await Task.Run(() => new Dao.DepartementDao().GetAllAsync());

            lblCount.Text = string.Format("({0})", departements.Count);

            Add();
        }

        void Add(Departement instance = null)
        {
            var list = new List<Faculte>();

            if (instance == null)
                foreach (var row in departements)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {
                instance.Number = departements.Count == 0 ? 1 : departements.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(instance.data));

                departements.Add(instance);
                lblCount.Text = string.Format("({0})", departements.Count);
            }
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;

            var sizeColumn = (lstViewData.Width - 50) / 2;

            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Faculté", sizeColumn);
            lstViewData.Columns.Add("Département", sizeColumn);
        }

        private void DepartementView_Load(object sender, EventArgs e)
        {
            DrawListView();
            LoadFaculte();

            LoadDepartement();
            
        }

        private void btnRefreshD_Click(object sender, EventArgs e)
        {
            LoadFaculte();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDepartement();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            lstViewData.Items.Clear();

            lstViewData.Items.AddRange(departements.Where(i => string.IsNullOrEmpty(motif) || i.Nom.ToLower().Trim().NoAccent().StartsWith(motif) || i.Nom.ToLower().Trim().NoAccent().Contains(motif))
                .Select(c => new ListViewItem(c.data)).ToArray());
        }
    }
}
