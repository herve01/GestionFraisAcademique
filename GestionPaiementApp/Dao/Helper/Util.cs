using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Dao.Helper
{
    public class Util
    {
        public static VacationType ToVacationType(string value)
        {

            switch (value)
            {
                case "MATIN":
                    return VacationType.MATIN;
                case "MIDI":
                    return VacationType.MIDI;
                case "SOIR":
                    return VacationType.SOIR;

                default:
                    return VacationType.MATIN;
            }
        }

        public static Fingers ToFingers(string value)
        {
            switch (value)
            {
                case "LL":
                case "Auriculaire gauche":
                    return Fingers.LL;
                case "LR":
                case "Annulaire gauche":
                    return Fingers.LR;
                case "LM":
                case "Majeur gauche":
                    return Fingers.LM;
                case "LI":
                case "Index gauche":
                    return Fingers.LI;
                case "LT":
                case "Pouce gauche":
                    return Fingers.LT;
                case "RT":
                case "Pouce droit":
                    return Fingers.RT;
                case "RI":
                case "Index droit":
                    return Fingers.RI;
                case "RM":
                case "Majeur droit":
                    return Fingers.RM;
                case "RR":
                case "Annulaire droit":
                    return Fingers.RR;
                case "RL":
                case "Auriculaire droit":
                    return Fingers.RL;
                default:
                    return Fingers.RT;
            }
        }

        public static PaiementType ToPaiementType(string value)
        {
            switch (value)
            {
                case "TRANCHE":
                    return PaiementType.TRANCHE;
                case "PREVISION":
                    return PaiementType.PREVISION;

                default:
                    return PaiementType.TRANCHE;
            }
        }
    }
}
