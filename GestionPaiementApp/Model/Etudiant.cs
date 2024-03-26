using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
    public class Etudiant : ModelBase
    {
        public string Nom { get; set; }
        public string Matricule { get; set; }
        public string Postnom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }

        public List<EtudiantEmpreinte> Empreintes { get; set; } = new List<EtudiantEmpreinte>(); 

        public string Name
        {
            get => string.Format("{0}  {1}  {2}", Nom?.ToString(), Postnom?.ToString(), FirstUpperCase(Prenom?.ToString()));
        }

        string FirstUpperCase(string value)
        {
            return value?.ToUpper().Substring(0, 1) + value?.ToLower().Substring(1);
        }
    }
}