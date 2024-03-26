using GestionPaiementApp.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp.Modules.Parametres.View
{
    public partial class DbConnectorView : UserControl
    {
        string defaultdbName = "gestion_frais_academique_db";

        bool InParent;

        public DbConnectorView(bool inParent = false)
        {
            InParent = inParent;
            InitializeComponent();
        }

        DbConnection connection;

        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (Dao.Helper.AppDao.TestDatabase(connection, cmbDbs.SelectedItem.ToString().Trim()))
            {
                //IsTested = true;
                MessageBox.Show("Connexion réussie !", "Stone Consulting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("La connexion a échoué. Vous avez choisi une mauvaise base de données !", "Stone Consulting", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        async Task LoadDatabases(object p = null)
        {
            cmbDbs.Items.Clear();
            cmbDbs.AutoCompleteCustomSource.Clear();

            var list = await Task.Run(() => Dao.Helper.AppDao.GetDatabases(connection));

            cmbDbs.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDbs.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (var row in list)
            {
                cmbDbs.AutoCompleteCustomSource.Add(row.ToString());
                cmbDbs.Items.Add(row);
            }

            cmbDbs.Text = list.Count > 0 ? defaultdbName : null;
        }


        void Bind()
        {
            txtServeur.Text = Properties.Settings.Default.local_server;
            txtUserName.Text = Properties.Settings.Default.local_user;
            txtPort.Text = Properties.Settings.Default.local_port;
        }

        private void cmbDbs_DropDown(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Items.Count == 0)
            {
                var feed = Dao.Helper.AppDao.CreateConnection(txtServeur.Text.Trim(), txtUserName.Text.Trim(), txtPW.Text.Trim(), txtPort.Text.Trim());
                if (feed is DbConnection)
                {
                    connection = (DbConnection)feed;
                    LoadDatabases();
                }
                else
                {
                    MessageBox.Show(feed.ToString(), "Stone Consulting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DbConnectorView_Load(object sender, EventArgs e)
        {
            Bind();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            DbConfig.DbName = Properties.Settings.Default.local_dbname = cmbDbs?.SelectedItem?.ToString();
            DbConfig.DbUser = Properties.Settings.Default.local_user = txtUserName.Text.Trim();
            DbConfig.DbPassword = Properties.Settings.Default.local_pwd = txtPW.Text.Trim();
            DbConfig.ServerName = Properties.Settings.Default.local_server = txtServeur.Text.Trim();
            DbConfig.DbPort = Properties.Settings.Default.local_port = txtPort.Text.Trim();

            Properties.Settings.Default.Save();

            MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(InParent)
            {
                Task.Delay(1000);

                ((Form)this.TopLevelControl).Close();
            }
        }

        public void ResizePanle()
        {
            int X = (this.ClientSize.Width - panel1.Width) / 2;
            int Y = (this.ClientSize.Height - panel1.Height) / 2;

            panel1.Location = new Point(X, Y);
        }
    }
}
