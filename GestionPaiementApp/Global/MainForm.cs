using GestionPaiementApp.Dao.Helper;
using GestionPaiementApp.Global;
using GestionPaiementApp.Modules.Parametres.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp
{
    public partial class MainForm : Form
    {
        DbConnectorView dbConnectorView = new DbConnectorView();
        Global.Popup Popup;

        static MainForm _obj;

        public static MainForm Instance
        {
            get
            {
                if (_obj == null)
                    _obj = new MainForm();

                return _obj;
            }
        }

        DefaulMainPresentationView presenter;

        public MainForm()
        {
            presenter = new DefaulMainPresentationView();            
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;

            timer.Start();
        }
        Timer timer;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _obj = this;
            AddViewIn(presenter);
        }

        public void AddViewIn(UserControl view)
        {
            view.Size = pnlMain.Size;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(view);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(!pnlMain.Controls.Contains(presenter))
                AddViewIn(presenter);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer = null;

            if (ConnectionHelper.GetConnection() == null)
            {
                dbConnectorView = new DbConnectorView(true);

                dbConnectorView.Size = new Size(380, 470);
                dbConnectorView.ResizePanle();

                Popup = new Popup(dbConnectorView);
                Popup.StartPosition = FormStartPosition.CenterParent;

                Popup.ShowDialog();

                Login();
            }
            else
            {
                Login();
            }
        }

        private void pbConnector_Click(object sender, EventArgs e)
        {
            new LoginView().ShowDialog();
            presenter.ActiveOption();
            statusLogin();
        }

        void statusLogin()
        {
            var user = Model.App.AppConfig.CurrentUser;

            lblUser.Invoke(new MethodInvoker(delegate
            {
                lblUser.Text = user?.RoleString ?? "Utilisateur";
            }));

            lblUserName.Invoke(new MethodInvoker(delegate
            {
                lblUserName.Text = user == null ? "aucun" : $"{user?.Prenom} {user?.Nom?.ToUpper()}" ;
            }));
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment abondonner la session  ?", "Stone Consulting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Model.App.AppConfig.CurrentUser = null;
                presenter.ActiveOption();
                statusLogin();
                AddViewIn(presenter);

                Login();
            }
        }

        void Login()
        {
            new LoginView().ShowDialog();
            presenter.ActiveOption();
            statusLogin();
        }
    }
}
