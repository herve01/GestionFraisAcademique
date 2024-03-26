using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp.Modules
{
    public class Functions
    {
        public static void InitTextBox(Control parent)
        {
            foreach (var control in parent.Controls.OfType<TextBox>())
            {
                if (control.Text != string.Empty)
                    control.Text = string.Empty;
            }
        }


        public static bool IsEmptyTextBox(Control parent)
        {
            foreach (var control in parent.Controls.OfType<TextBox>())
            {
                if (control.Text == string.Empty)
                    return true;
            }

            return false;
        }
    }
}
