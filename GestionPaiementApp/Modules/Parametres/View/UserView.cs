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

namespace GestionPaiementApp.Modules.Parametres.View
{
    public partial class UserView : UserControl
    {
        List<User> users;
        private Array types;
        private Array roles;
        User user;

        public UserView()
        {   
            users = new List<User>();
            types = Enum.GetValues(typeof(UserType));
            roles = Enum.GetValues(typeof(RoleType));

            InitializeComponent();

            InitSave();
        }


        void InitSave()
        {
            user = new User();
            btnSave.Text = "Enregistrer";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Functions.IsEmptyTextBox(pnlZone))
                MessageBox.Show("Une Erreur est survenue lors de l'enregistrement.\n Rassurez-vous d'avoir rempli tous les champs !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                user.Nom = txtNom.Text;
                user.Prenom = txtPrenom.Text;
                user.UserName = txtUserName.Text;
                user.Email = txtMail.Text;
                user.Type = (UserType)cmbType.SelectedItem;
                user.Role = (RoleType)cmbRole.SelectedItem;
                user.PassWord = txtPsswd.Text;

                if (((Button)sender).Text.Trim() == "Enregistrer")
                {
                    if(user.PassWord != txtRepeatePW.Text)
                        MessageBox.Show("Le mot de passe introduit ne correspont pas !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (new Dao.UserDao().Add(user) > 0)
                        {
                            MessageBox.Show("Enregistrement reussi avec succès !!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Add(user);
                            Functions.InitTextBox(pnlZone);
                        }
                    }
                }
                else
                {
                    if (new Dao.UserDao().Update(user, null) > 0)
                    {
                        MessageBox.Show("Modification reussie avec succès !!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //lstViewData.Items.RemoveAt(index);
                        users.Remove(user);

                        Add(user);

                        Functions.InitTextBox(pnlZone);
                    }
                }

                InitSave();
            }
        }

        void DrawListView()
        {
            lstViewData.View = System.Windows.Forms.View.Details;
            lstViewData.GridLines = true;
            lstViewData.FullRowSelect = true;
            //Add column header
            lstViewData.Columns.Add("#", 50);
            lstViewData.Columns.Add("Nom", lstViewData.Width - 400);
            lstViewData.Columns.Add("Role", 220);
            lstViewData.Columns.Add("Etat", 130);
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            DrawListView();

            cmbType.Items.AddRange(types.Cast<object>().ToArray());
            cmbRole.Items.AddRange(roles.Cast<object>().ToArray());

            cmbType.SelectedIndex = 0;
            cmbRole.SelectedIndex = 0;

            LoadUser();
        }

        async Task LoadUser()
        {
            lstViewData.Items.Clear();

            users = await Task.Run(() => new Dao.UserDao().GetAllAsync());

            lblCount.Text = string.Format("({0})", users.Count);

            Add();
        }

        void Add(User user = null)
        {
            var list = new List<User>();

            if (user == null)
                foreach (var row in users)
                {
                    lstViewData.Items.Add(new ListViewItem(row.data));
                }
            else
            {
                user.Number = users.Count == 0 ? 1 : users.FindLast(s => s.Number > 0).Number + 1;
                lstViewData.Items.Add(new ListViewItem(user.data));
                users.Add(user);

                lblCount.Text = string.Format("({0})", users.Count);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            var motif = ((TextBox)sender).Text.Trim().ToLower().NoAccent();
            if (motif == null)
                return;

            lstViewData.Items.Clear();

            lstViewData.Items.AddRange(users.Where(i => string.IsNullOrEmpty(motif) || i.Name.ToLower().Trim().NoAccent().StartsWith(motif) || i.Name.ToLower().Trim().NoAccent().Contains(motif))
                .Select(c => new ListViewItem(c.data)).ToArray());
        }
    }
}
