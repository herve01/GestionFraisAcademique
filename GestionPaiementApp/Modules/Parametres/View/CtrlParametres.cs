using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp.Modules.Parametres.View
{
    public partial class CtrlParametres : UserControl
    {
        DbConnectorView connectorView;
        UserView userView;
        LogView logView;

        public CtrlParametres()
        {
            InitializeComponent();

            connectorView = new DbConnectorView();
            userView = new UserView();
            logView = new LogView();
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            connectorView.ResizePanle();

            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(connectorView);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(userView);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            var ctl = ((Button)sender);

            lblTitle.Text = ctl.Text.Trim();
            signMenu.Location = new Point(signMenu.Location.X, ctl.Location.Y);
            AddViewIn(logView);
        }

        void AddViewIn(UserControl userControl)
        {
            userControl.Size = pnlCtner.Size;
            pnlCtner.Controls.Clear();
            pnlCtner.Controls.Add(userControl);
        }

        private void CtrlParametres_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Connection DB";
            signMenu.Location = new Point(signMenu.Location.X, btnDB.Location.Y);
            AddViewIn(connectorView);
        }
    }
}
