using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model.POCO
{
    public class PaiementDetail
    {
        public decimal Paiement { get; set; }
        public int Numero { get; set; }
        public decimal Montant { get; set; }
        public PaiementType Type { get; set; }

        public decimal Reste
        {
            get => Montant - Paiement;
        }

        public override string ToString()
        {
            return Type == PaiementType.PREVISION ? 
                string.Format("$ {0} | ${1}", Paiement, Montant) :
                string.Format("{0}è ⇒ ${1} / ${2} ", Numero, Paiement, Montant)
                ;
        }
    }
}
