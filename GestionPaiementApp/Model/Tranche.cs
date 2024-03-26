using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionPaiementApp.Model
{
    public class Tranche : ModelBase
    {
        public Prevision Prevision { get; set; }
        public int Numero { get; set; }
        public decimal Montant { get; set; }

        public string MontantStr
        {
            get => Montant.ToString("N", System.Globalization.CultureInfo.GetCultureInfo("fr-FR")) +" $";
        }

        public override string ToString()
        {
            return string.Format("{0} è Tranche  ⇒ {1}", Numero, MontantStr);
        }
    }
}

