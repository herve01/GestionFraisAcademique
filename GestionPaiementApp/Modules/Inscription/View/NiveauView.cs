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
    public partial class NiveauView : UserControl
    {
        Niveau niveau;

        public Niveau Instance { get; set; }

        public NiveauView()
        {
            Instance = new Niveau();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Functions.IsEmptyTextBox(this))
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                niveau = new Niveau();
                niveau.Nom = txtNom.Text;
                niveau.Ordre = int.Parse(txtOrdre.Text);

                if (new Dao.NiveauDao().Add(niveau) > 0)
                {
                    MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Instance = niveau.Clone() as Niveau;

                    Functions.InitTextBox(this);

                    Task.Delay(1000);
                    ((Form)this.TopLevelControl).Close();
                }
            }
        }
    }
}
