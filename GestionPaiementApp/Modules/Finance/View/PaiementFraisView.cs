using GestionPaiementApp.Extension;
using GestionPaiementApp.Model;
using GestionPaiementApp.Modules.Inscription.View;
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
    public partial class PaiementFraisView : UserControl
    {
        Paiement paiement;
        List<Paiement> paiements;
        Model.Inscription inscription;

        ChoosingEtudiantView choosingEtudiantView;
        Global.Popup Popup;

        public PaiementFraisView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   
            if (Functions.IsEmptyTextBox(pnlZone) )
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                paiement = new Paiement();
                paiement.Inscription = inscription;
                paiement.Type = Dao.Helper.Util.ToPaiementType(cmbPaiement.SelectedItem.ToString());
                paiement.Date = DateTime.Today;
                paiement.Montant = decimal.Parse(txtMontant.Text);
                paiement.Unit = paiement.Type == PaiementType.TRANCHE ? (object)cmbTranche.SelectedItem : (object)cmbTranche.SelectedItem;
                paiement.EstPayeTotalite = paiement.Type == PaiementType.TRANCHE ? paiement.Montant == ((Tranche)cmbTranche.SelectedItem).Montant
                    : paiement.Montant == ((Prevision)cmbTranche.SelectedItem).Montant;

                if (new Dao.PaiementDao().Add(paiement) > 0)
                {
                    MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Add(paiement);
                    Functions.InitTextBox(pnlZone);
                    ResetHistoEtud(null);
                }
            }
        }

        void Add(Paiement instance = null)
        {
            if (instance == null)
                foreach (var row in paiements)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {
                instance.Number = paiements.Count == 0 ? 1 : paiements.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(instance.data));

                paiements.Add(instance);
                lblCount.Text = string.Format("({0})", paiements.Count);
            }
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;

            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Etudiant", lstViewData.Width - 600);
            lstViewData.Columns.Add("Date", 100);
            lstViewData.Columns.Add("Promotion", 180);
            lstViewData.Columns.Add("Montant", 270);
        }


        private void btnRefreshA_Click(object sender, EventArgs e)
        {
            LoadAnnee();
        }

        private void PaiementView_Load(object sender, EventArgs e)
        {
            DrawListView();
            ResetHistoEtud(null);

            LoadAnnee();
            cmbPaiement.SelectedIndex = 0;

            LoadPaiement();
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
            LoadPaiement();
        }

        async Task LoadPaiement()
        {
            lstViewData.Items.Clear();

            var dao = new Dao.PaiementDao();
            dao.NewConnection();

            paiements = await Task.Run(() => dao.GetAllAsync());

            lblCount.Text = string.Format("({0})", paiements.Count);

            Add();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            lstViewData.Items.Clear();

            lstViewData.Items.AddRange(paiements.Where(i => string.IsNullOrEmpty(motif) ||
            i.Inscription.Etudiant.Name.ToLower().Trim().NoAccent().StartsWith(motif) ||
            i.Inscription.Etudiant.Name.ToLower().Trim().NoAccent().Contains(motif) ||
            i.Inscription.Promotion.ToString().ToLower().Trim().NoAccent().Contains(motif)
            )
            .Select(p => new ListViewItem(p.data)).ToArray());
        }

        private void btnChoosen_Click(object sender, EventArgs e)
        {
            if (cmbAnnee.SelectedItem == null)
                return;

            var annee = (AnneeAcademique)cmbAnnee.SelectedItem;

            choosingEtudiantView = new ChoosingEtudiantView(annee);
            Popup = new Global.Popup(choosingEtudiantView);

            Popup.ShowDialog();

            var inscription = choosingEtudiantView.Inscription;

            this.inscription = inscription;

            ResetHistoEtud(inscription);

            cmbPaiement.SelectedItem = inscription.Type;

            LoadDetailPaiement(inscription.Type);
        }

        void ResetHistoEtud(Model.Inscription inscription)
        {
            lblName.Text = string.Format("{0}", inscription?.Etudiant?.Name?? "NOMS : -");
            lblSexe.Text = string.Format("SEXE : {0}", inscription?.Etudiant?.Sexe ?? " -"); 
            lblPromotion.Text = string.Format("{0}", inscription?.Promotion?.ToString() ?? "Promotion : -"); 
            lblMode.Text = string.Format("MODE : {0}", inscription?.Type.ToString() ?? " -");

            var histPaie = string.Empty;

            inscription?.Paiements.ForEach(p => histPaie += p.ToString() + " ");

            lblHistoPaie.Text = histPaie == string.Empty ? "Paiement - " : histPaie;
        }

        private void cmbPaiement_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = Dao.Helper.Util.ToPaiementType((((ComboBox)sender).SelectedItem).ToString().Trim());

            LoadDetailPaiement(type);
        }

        private void btnRefreshD_Click(object sender, EventArgs e)
        {

        }

        async Task LoadDetailPaiement(PaiementType Type)
        {
            if (this.inscription?.Id == null)
                return;

            cmbTranche.Items.Clear();
            cmbTranche.AutoCompleteCustomSource.Clear();

            var dao = new Dao.PrevisionDao();
            dao.NewConnection();

            var paiement = await Task.Run(() => dao.GetAsync(this.inscription.Annee.Id, this.inscription.Promotion.Niveau.Id, Type == PaiementType.TRANCHE));

            cmbTranche.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTranche.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if(Type == PaiementType.PREVISION)
            {
                cmbTranche.AutoCompleteCustomSource.Add(paiement.ToString());
                cmbTranche.Items.Add(paiement);
                cmbTranche.SelectedIndex = 0;
            }
            else
            {
                foreach (var row in paiement.Tranches)
                {
                    cmbTranche.AutoCompleteCustomSource.Add(row.ToString());
                    cmbTranche.Items.Add(row);
                }
                cmbTranche.SelectedIndex = paiement.Tranches.Count > 0 ? 0 : -1;
            }
        }

        private void PaiementFraisView_Load(object sender, EventArgs e)
        {
            cmbPaiement.SelectedIndex = 0;
            ResetHistoEtud(null);

            DrawListView();
            LoadAnnee();

            LoadPaiement();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Functions.InitTextBox(pnlZone);
            ResetHistoEtud(null);
        }
    }
}
