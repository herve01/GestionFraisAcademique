using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
    public class Departement : ModelBase
    {
        public Faculte Faculte { get; set; }
        public string Nom { get; set; }

        public Departement()
        {
            //Faculte = new Faculte();
        }

        public override string ToString()
        {
            return Nom;
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), Faculte.Nom, Nom };
        }
    }
}
