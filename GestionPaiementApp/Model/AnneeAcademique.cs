using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
	public class AnneeAcademique : ModelBase
	{
        public string Annee { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateCloture { get; set; }

        public override string ToString()
        {
            return Annee;
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), Annee, DateOuverture.ToString("dd/MM/yyyy"), DateCloture.ToString("dd/MM/yyyy") };
        }
    }
}
