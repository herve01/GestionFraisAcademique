using GestionPaiementApp.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
    public class Inscription : ModelBase
    {
        public Etudiant Etudiant { get; set; }
        public VacationType Vacation { get; set; }
        public AnneeAcademique Annee { get; set; }
        public Promotion Promotion { get; set; }
        public byte[] Photo { get; set; }
        public List<PaiementDetail> Paiements { get; set; }

        public Faculte Faculte { get; set; }

        public Inscription()
        {
            Paiements = new List<PaiementDetail>();
            Etudiant = new Etudiant();
        }

        public PaiementType Type
        {
            get 
            {
                var paiement = Paiements.Find(p => p.Montant > 0);

                return paiement?.Type ?? PaiementType.TRANCHE;
            }
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), Etudiant?.Name, Etudiant?.Sexe, Etudiant?.Telephone, Etudiant?.Adresse, Vacation.ToString(), Faculte?.ToString(), Promotion?.ToString() };
        }
    }

    public enum VacationType
    {
        MATIN,
        MIDI,
        SOIR
    }
}
