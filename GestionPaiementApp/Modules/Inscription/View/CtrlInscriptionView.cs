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
    public partial class CtrlInscriptionView : UserControl
    {
        FaculteView faculteView;
        DepartementView departementView;
        PromotionView promotionView;
        InscriptionView inscriptionView;
        AnneeAcademiqueView academiqueView;
        ReinscriptionView reinscriptionView;

        public CtrlInscriptionView()
        {     
            faculteView = new FaculteView();
            departementView = new DepartementView();
            promotionView = new PromotionView();
            inscriptionView = new InscriptionView();
            academiqueView = new AnneeAcademiqueView();
            reinscriptionView = new ReinscriptionView();

            InitializeComponent();
            lblTitle.Text = "Faculté";
        }

        void AddViewIn(UserControl userControl)
        {
            userControl.Size = pnlCtner.Size;
            pnlCtner.Controls.Clear();
            pnlCtner.Controls.Add(userControl);
        }

        private void btnFaculte_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);
            promotionView.StopProccess();

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(faculteView);
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);
            faculteView.StopProccess();

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(promotionView);
        }

        private void btnAnnee_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(academiqueView);
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(inscriptionView);
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(departementView);
        }

        private void CtrlInscriptionView_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Faculté";
            signMenu.Location = new Point(signMenu.Location.X, btnFaculte.Location.Y);
            AddViewIn(faculteView);
        }

        private void btnReinscription_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);

            AddViewIn(reinscriptionView);
        }
    }
}
