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
    public partial class AnneeAcademiqueView : UserControl
    {
        Model.AnneeAcademique anneeAcademique;
        List<Model.AnneeAcademique> anneeAcademiques;

        public AnneeAcademiqueView()
        {
            anneeAcademiques = new List<AnneeAcademique>();
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnneeAcademique();
        }

        private void AnneeAcademiqueView_Load(object sender, EventArgs e)
        {
            DrawListView();

            LoadAnneeAcademique();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Functions.InitTextBox(pnlZone);
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;

            var sizeColumn = (lstViewData.Width - 200) / 2;

            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Année Academique", 150);
            lstViewData.Columns.Add("Date d'ouverture", sizeColumn);
            lstViewData.Columns.Add("Date de clôture", sizeColumn);
        }


        async Task LoadAnneeAcademique()
        {
            lstViewData.Items.Clear();

            anneeAcademiques = await Task.Run(() => new Dao.AnneeAcademiqueDao().GetAllAsync());

            lblCount.Text = string.Format("({0})", anneeAcademiques.Count);

            Add();
        }

        void Add(AnneeAcademique instance = null)
        {
            if (instance == null)
                foreach (var row in anneeAcademiques)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {
                instance.Number = anneeAcademiques.Count == 0 ? 1 : anneeAcademiques.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(instance.data));

                anneeAcademiques.Add(instance);
                lblCount.Text = string.Format("({0})", anneeAcademiques.Count);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Functions.IsEmptyTextBox(pnlZone))
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                anneeAcademique = new Model.AnneeAcademique();
                anneeAcademique.Annee = txtAnnee.Text;
                anneeAcademique.DateOuverture = dtpOuverture.Value;
                anneeAcademique.DateCloture = dtpCloture.Value;

                if(anneeAcademique.DateOuverture.Date == anneeAcademique.DateCloture.Date)
                    MessageBox.Show(string.Format("La date d''ouverture {0} ne doit pas être égal à celle du clôture {1}", anneeAcademique.DateOuverture.ToString("dd/MM/yyyy"), anneeAcademique.DateCloture.ToString("dd/MM/yyyy")), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);  

                else if(anneeAcademique.DateOuverture.Date > anneeAcademique.DateCloture.Date)
                    MessageBox.Show(string.Format("La date d''ouverture {0} ne doit pas être strictement inferieur à celle du clôture {1}", anneeAcademique.DateOuverture.ToString("dd/MM/yyyy"), anneeAcademique.DateCloture.ToString("dd/MM/yyyy")), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                else
                    if (new Dao.AnneeAcademiqueDao().Add(anneeAcademique) > 0)
                    {
                        MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Add(anneeAcademique);
                        Functions.InitTextBox(pnlZone);
                    }
            }
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            lstViewData.Items.Clear();

            lstViewData.Items.AddRange(anneeAcademiques.Where(i => string.IsNullOrEmpty(motif) || i.Annee.ToLower().Trim().NoAccent().StartsWith(motif) || i.Annee.ToLower().Trim().NoAccent().Contains(motif))
                .Select(c => new ListViewItem(c.data)).ToArray());
        }
    }
}
