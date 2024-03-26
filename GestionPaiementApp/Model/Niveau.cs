using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
	public class Niveau : ModelBase, ICloneable
	{
		public string Nom { get; set; }
        public int Ordre { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
