using GestionPaiementApp.Model.Helper;
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
    public partial class CtrlFinanceView : UserControl
    {
        PrevisionView previsionView;
        PaiementFraisView paiementFraisView;
        ControleFraisView controleFraisView;
        //InscriptionView inscriptionView;
        //AnneeAcademiqueView academiqueView;

        public CtrlFinanceView()
        {
            previsionView = new PrevisionView();
            paiementFraisView = new PaiementFraisView();
            controleFraisView = new ControleFraisView();
            //inscriptionView = new InscriptionView();
            //academiqueView = new AnneeAcademiqueView();

            InitializeComponent();
        }

        void AddViewIn(UserControl userControl)
        {
            userControl.Size = pnlCtner.Size;
            pnlCtner.Controls.Clear();
            pnlCtner.Controls.Add(userControl);
        }

        private void btnPrevision_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(previsionView);
        }

        private void btnControlFrais_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            FingerPrintController.Capturer.EventHandler = controleFraisView;
            FingerPrintController.Stop();
            FingerPrintController.Start();
          
            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(controleFraisView);
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            //AddViewIn(academiqueView);
        }


        private void btnPaiement_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(paiementFraisView);
        }

        private void CtrlFinanceView_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Prevision";
            signMenu.Location = new Point(signMenu.Location.X, btnFaculte.Location.Y);
            AddViewIn(previsionView);
        }
    }
}
