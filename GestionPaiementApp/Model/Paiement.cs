using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
	public class Paiement : ModelBase
	{
        public object Unit { get; set; }
        public Inscription Inscription { get; set; }
        public bool EstPayeTotalite { get; set; }
        public PaiementType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }

        public Prevision Prevision
        {
            get
            {
                if (Type == PaiementType.PREVISION)
                    return (Prevision)Unit;

                return null;
            }
        }

        public Tranche Tranche
        {
            get
            {
                if (Type == PaiementType.TRANCHE)
                    return (Tranche)Unit;

                return null;
            }
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), Inscription.Etudiant.Name, Date.ToString("dd/MM/yyyy"), string.Format("{0} | {1}",Inscription.Annee.Annee, Inscription.Promotion.ToString()), 
                string.Format("{0} {1}", Type.ToString(), Type == PaiementType.PREVISION ? MontantStr +" / "+ Prevision?.MontantStr :
                  Tranche.ToString()+"  "+  MontantStr )};
        }


        public string MontantStr
        {
            get => Montant.ToString("N", System.Globalization.CultureInfo.GetCultureInfo("fr-FR")) + " $";
        }
    }

    public enum PaiementType
    {
        TRANCHE,
        PREVISION
    }
}
