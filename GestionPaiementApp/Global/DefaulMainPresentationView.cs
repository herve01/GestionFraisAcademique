using GestionPaiementApp.Model;
using GestionPaiementApp.Modules.Finance.View;
using GestionPaiementApp.Modules.Inscription.View;
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

namespace GestionPaiementApp.Global
{
    public partial class DefaulMainPresentationView : UserControl
    {
        CtrlFinanceView ctrlFinanceView;
        CtrlInscriptionView ctrlInscriptionView;
        CtrlParametres ctrlParametres;

        public DefaulMainPresentationView()
        {
            ctrlFinanceView = new CtrlFinanceView();
            ctrlInscriptionView = new CtrlInscriptionView();
            ctrlParametres = new CtrlParametres();
            InitializeComponent();
        }

        private void DefaulMainPresentationView_Load(object sender, EventArgs e)
        {
            int X = (this.Width - flowLayoutPanel1.Width) / 2;
            int Y = (this.Height - flowLayoutPanel1.Height) / 2;

            flowLayoutPanel1.Location = new Point(X, Y);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            MainForm.Instance.AddViewIn(ctrlParametres);
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            MainForm.Instance.AddViewIn(ctrlInscriptionView);
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            MainForm.Instance.AddViewIn(ctrlFinanceView);
        }

        public void ActiveOption()
        {
            if (Model.App.AppConfig.CurrentUser == null)
            {
                panelActivation(null);
            }
            else
            {
                var role = Model.App.AppConfig.CurrentUser.Role;
                List<RoleType> roles = new List<RoleType>();

                if (role.ToString().Contains("_"))
                    role.ToString().Split('_').ToList().ForEach(r => 
                    {
                        RoleType _type;
                        if (Enum.TryParse<RoleType>(r, true, out _type))
                            roles.Add(_type);
                    });
                else
                    roles.Add(role);

                panelActivation(roles);

            }
        }

        void panelActivation(List<RoleType> roles)
        {
            foreach (var panel in flowLayoutPanel1.Controls.OfType<Panel>())
            {
                if(roles == null)
                    panel.Enabled = false;
                else
                {
                    panel.Enabled = false;

                    if(roles.Contains(RoleType.TOUT))
                        panel.Enabled = true;
                    else
                    {
                        var name = panel.Name.Trim().Split('_')[1];

                        RoleType _type;
                        if (Enum.TryParse<RoleType>(name, true, out _type) & roles.Count >= 1)
                        {
                            if (roles.Contains(_type))
                                panel.Enabled = true;
                        }
                    }              
                }
            }
        }


        public void ResizePanle()
        {
            int X = (this.ClientSize.Width - flowLayoutPanel1.Width) / 2;
            int Y = (this.ClientSize.Height - flowLayoutPanel1.Height) / 2;

            flowLayoutPanel1.Location = new Point(X, Y);
        }
    }
}
