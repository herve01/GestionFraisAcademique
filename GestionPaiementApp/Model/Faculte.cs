using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
    public class Faculte : ModelBase, ICloneable
    {
        public string Nom { get; set; }

        public override string ToString()
        {
            return Nom;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var faculte = (Faculte)obj;

            return (!string.IsNullOrWhiteSpace(Id) && faculte.Id == Id) || (!string.IsNullOrWhiteSpace(Nom) && Nom.ToLower() == faculte.Nom);
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), Nom };
        }
    }
}
