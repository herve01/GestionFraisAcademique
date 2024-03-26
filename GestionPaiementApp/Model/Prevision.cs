 using System;
 using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model 
{
	public class Prevision : ModelBase
	{
        public AnneeAcademique Annee { get; set; }
		public Niveau Niveau { get; set; }
        public DateTime Date { get; set; }
        public int NombreTranche { get; set; }
        public decimal Montant { get; set; }

        public List<Tranche> Tranches { get; set; }

        public Prevision()
        {
            Tranches = new List<Tranche>();
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), Annee.Annee, Niveau.Nom, MontantStr, Description};
        }

        public string MontantStr
        {
            get => Montant.ToString("N", System.Globalization.CultureInfo.GetCultureInfo("fr-FR")) + " $";
        }

        string Description
        {
            get
            {
                var _tranche = string.Empty;

                Tranches.ForEach(t => _tranche += t.Numero + "è Tranche ⇒ " + t.MontantStr + "   ");

                return string.Format("{0} Tranche(s) | {1}", NombreTranche.ToString(), _tranche);
            }
        }

        public override string ToString()
        {
            return MontantStr; 
        }
    }
}
