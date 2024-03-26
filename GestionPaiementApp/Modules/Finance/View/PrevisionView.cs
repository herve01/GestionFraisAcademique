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

namespace GestionPaiementApp.Modules.Finance.View
{
    public partial class PrevisionView : UserControl
    {
        Prevision prevision;
        List<Prevision> previsions;

        public PrevisionView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   
            if (Functions.IsEmptyTextBox(pnlZone) | Functions.IsEmptyTextBox(tranchePanel))
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                prevision = new Prevision();
                prevision.Niveau = (Niveau)cmbNiveau.SelectedItem;
                prevision.Annee = (AnneeAcademique)cmbAnnee.SelectedItem;
                prevision.NombreTranche = int.Parse(txtNbreTranche.Text);
                prevision.Montant = decimal.Parse(txtMontant.Text);
                prevision.Date = DateTime.Today;
                ProcessTranche(ref prevision);

                if (new Dao.PrevisionDao().Add(prevision) > 0)
                {
                    MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Add(prevision);
                    Functions.InitTextBox(pnlZone);
                }
            }
        }

        void Add(Prevision instance = null)
        {
            if (instance == null)
                foreach (var row in previsions)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {
                
                instance.Number = previsions.Count == 0 ? 1 : previsions.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(instance.data));

                previsions.Add(instance);
                lblCount.Text = string.Format("({0})", previsions.Count);
            }
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;

            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Année", 100);
            lstViewData.Columns.Add("Promotion", 100);
            lstViewData.Columns.Add("Montant", 130);
            lstViewData.Columns.Add("Prévision", lstViewData.Width - 380);
        }

        void ProcessTranche(ref Prevision prevision)
        {
            int i = 0;

            foreach (var item in tranchePanel.Controls.OfType<TextBox>())
            {
                i++;
                var tranche = new Tranche()
                {
                    Numero = i,
                    Montant = decimal.Parse(item.Text),
                };

                prevision.Tranches.Add(tranche);
            }
        }

        void DrawTranche(int nbreTranche)
        {
            TextBox textBox;
            Label label;

            int sizetxt = (tranchePanel.Width - 28) / nbreTranche;

            var point = new Point(11, 5);
            var pointT = new Point(15, 5);

            tranchePanel.Controls.Clear();

            for (int i = 0; i < nbreTranche; i++)
            {
                textBox = new TextBox();
                label = new Label();

                textBox.Size = new Size(sizetxt, 30);
                label.Size = new Size(sizetxt, 20);
                textBox.Font = new Font("Segoe UI", 10);
                label.Font = new Font("Segoe UI", 9);

                label.Location = point;
                label.Text = string.Format("{0} è Tranche ", (i+1));

                pointT.Y = label.Height + 5;
                textBox.Location = pointT;

                tranchePanel.Controls.Add(label);
                tranchePanel.Controls.Add(textBox);

                point.X += label.Width + 5;
                pointT.X += textBox.Width + 5;

            }
        }

        private void txtNbreTranche_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nbre;

                int.TryParse(txtNbreTranche.Text, out nbre);

                DrawTranche(nbre);
            }
            catch (Exception)
            {
                tranchePanel.Controls.Clear();
            }
        }

        private void btnRefreshA_Click(object sender, EventArgs e)
        {
            LoadAnnee();
        }

        private void btnRefreshN_Click(object sender, EventArgs e)
        {
            LoadNiveau();
        }

        private void PrevisionView_Load(object sender, EventArgs e)
        {
            DrawListView();

            LoadAnnee();
            LoadNiveau();

            LoadPrevision();
        }

        async Task LoadNiveau()
        {

            cmbNiveau.Items.Clear();
            cmbNiveau.AutoCompleteCustomSource.Clear();

            var dao = new Dao.NiveauDao();
            dao.NewConnection();

            var list = await Task.Run(() => dao.GetAllAsync());

            cmbNiveau.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNiveau.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                cmbNiveau.AutoCompleteCustomSource.Add(row.ToString());
                cmbNiveau.Items.Add(row);
            }

            cmbNiveau.SelectedIndex = list.Count > 0 ? 0 : -1;
        }

        async Task LoadAnnee()
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
            LoadPrevision();
        }

        async Task LoadPrevision()
        {
            lstViewData.Items.Clear();

            var dao = new Dao.PrevisionDao();
            dao.NewConnection();

            previsions = await Task.Run(() => dao.GetAllAsync());

            lblCount.Text = string.Format("({0})", previsions.Count);

            Add();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            lstViewData.Items.Clear();

            lstViewData.Items.AddRange(previsions.Where(i => string.IsNullOrEmpty(motif) || 
            i.Niveau.ToString().ToLower().Trim().NoAccent().StartsWith(motif) || 
            i.Niveau.ToString().ToLower().Trim().NoAccent().Contains(motif))
                .Select(p => new ListViewItem(p.data)).ToArray());
        }
    }
}
