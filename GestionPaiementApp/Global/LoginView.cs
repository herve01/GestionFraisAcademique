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

namespace GestionPaiementApp.Global
{
    public partial class LoginView : Form
    {
        User user;

        public LoginView()
        {
            //user = new User();
            InitializeComponent();
            pbLoad.Visible = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                pbLoad.Invoke(new MethodInvoker(delegate
                {
                    pbLoad.Visible = true;
                }));

                Task.Delay(3000).Wait(3000);

                user = new Dao.UserDao().Get(txtUserName.Text.Trim(), txtpwd.Text.Trim());

                pbLoad.Invoke(new MethodInvoker(delegate
                {
                    pbLoad.Visible = false;
                }));

                if (user != null)
                {
                    if (user.Etat == UserEtat.FONCTIONNEL)
                    {

                        Properties.Settings.Default.last_connected_user_name = txtUserName.Text.Trim();
                        Properties.Settings.Default.Save();

                        Model.App.AppConfig.CurrentUser = user;

                        this.Invoke(new MethodInvoker(delegate
                        {
                            this.Close();
                        }));
                    }
                    else
                    {
                        user = null;
                        MessageBox.Show("Vous ne pouvez pas accéder au système pour l'instant. Votre compte a été bloqué. Veuillez contacter l'administrateur !", "SKUL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !", "SKUL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });


    

            //timer1.Start();


        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Properties.Settings.Default.last_connected_user_name;
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConnect_Click(sender, (EventArgs)e);
        }

        private void txtpwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
