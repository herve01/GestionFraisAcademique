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
    public partial class ChoosingEtudiantView : UserControl
    {
        List<Model.Inscription> inscriptions;
        AnneeAcademique selectedAnnee = null;
        public Model.Inscription Inscription { get; set; }

        public ChoosingEtudiantView(AnneeAcademique annee)
        {
            Inscription = new Model.Inscription();
            Inscription.Annee = annee;
            selectedAnnee = annee;
            inscriptions = new List<Model.Inscription>();
            InitializeComponent();
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
            lstViewData.Columns.Add("Sexe",  50);
            lstViewData.Columns.Add("Téléphone", 100);
            lstViewData.Columns.Add("Adresse", sizeColumn);
            lstViewData.Columns.Add("Vacation", 70);
            lstViewData.Columns.Add("Faculté", sizeColumn - 50);
            lstViewData.Columns.Add("Promotion", 200);
        }

        private void InscriptionView_Load(object sender, EventArgs e)
        {
            DrawListView();

            LoadInscription();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInscription();
        }

        async Task LoadInscription()
        {
            lstViewData.Items.Clear();

            if (selectedAnnee == null)
                return;

            inscriptions = await Task.Run(() => new Dao.InscriptionDao().GetAllAsync(selectedAnnee));

            lblCount.Text = string.Format("({0})", inscriptions.Count);

            foreach (var row in inscriptions)
            {
                lstViewData.Items.Add(new ListViewItem(row.data));
            }
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

        private void lstViewData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var key = int.Parse(((ListView)sender).SelectedItems[0].Text);

                Inscription = inscriptions.Find(i => i.Number == key);

                Task.Delay(1000);

                ((Form)this.TopLevelControl).Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
