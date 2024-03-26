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
    public partial class FaculteView : UserControl
    {
        Faculte faculte;
        List<Faculte> facultes;

        public FaculteView()
        {
            
            facultes = new List<Faculte>();
            InitializeComponent();
            //DrawListView();

            InitSave();
        }

        void InitSave()
        {
            faculte = new Faculte();
            btnSave.Text = "Enregistrer";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Functions.IsEmptyTextBox(pnlZone))
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                faculte.Nom = txtNom.Text;

                if(((Button)sender).Text.Trim() == "Enregistrer")
                {
                    if (new Dao.FaculteDao().Add(faculte) > 0)
                    {
                        MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Add(faculte);
                        Functions.InitTextBox(pnlZone);
                    }
                }
                else
                {
                    if (new Dao.FaculteDao().Update(faculte, null) > 0)
                    {
                        MessageBox.Show("Modification reussie avec succès !!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lstViewData.Items.RemoveAt(index);
                        facultes.Remove(faculte);

                        Add(faculte);

                        Functions.InitTextBox(pnlZone);
                    }
                }

                InitSave();
            }
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        async Task LoadFaculte()
        {
            tokenSource = new CancellationTokenSource();

            lstViewData.Items.Clear();

            facultes =  await Task.Run(() => new Dao.FaculteDao().GetAllAsync(tokenSource.Token));

            lblCount.Text = string.Format("({0})", facultes.Count);

            Add();
        }

        public void StopProccess()
        {
            tokenSource.Cancel();
        }

        void Add(Faculte faculte = null)
        {
            var list = new List<Faculte>();

            if (faculte == null)
                foreach (var row in facultes)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {          
                faculte.Number = facultes.Count == 0 ? 1 : facultes.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(faculte.data));
                facultes.Add(faculte);
                lblCount.Text = string.Format("({0})", facultes.Count);
            }
        }

        private void FaculteView_Load(object sender, EventArgs e)
        {
            DrawListView();
            LoadFaculte();
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;
            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Nom", lstViewData.Width - 50);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFaculte();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            lstViewData.Items.Clear(); 
                                      
            lstViewData.Items.AddRange(facultes.Where(i => string.IsNullOrEmpty(motif) || i.Nom.ToLower().Trim().NoAccent().StartsWith(motif) || i.Nom.ToLower().Trim().NoAccent().Contains(motif))
                .Select(c => new ListViewItem(c.data)).ToArray());
        }

        private void ModifierContext_Click(object sender, EventArgs e)
        {
            txtNom.Text = faculte.Nom;
            btnSave.Text = "Modifier";
        }

        private void ImprimerContext_Click(object sender, EventArgs e)
        {

        }

        int index = 0;

        private void lstViewData_MouseClick(object sender, MouseEventArgs e)
        {
            var listView = (ListView)lstViewData;

            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    lstViewMenu.Show(Cursor.Position);
                }

                var key = int.Parse(focusedItem.Text);

                faculte = facultes.Find(i => i.Number == key);

                index = focusedItem.Index;
            }
        }
    }
}
