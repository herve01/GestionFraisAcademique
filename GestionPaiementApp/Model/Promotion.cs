using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
    public class Promotion : ModelBase
    {
        public Niveau Niveau { get; set; }
        public Departement Departement { get; set; }
        public string Filiere { get; set; }

        public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();

        public override string ToString()
        {
            return string.Format("{0} {1}", Niveau?.Nom, Filiere);
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), ToString() };
        }
    }
}

