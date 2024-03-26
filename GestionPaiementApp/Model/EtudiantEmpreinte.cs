using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
    public class EtudiantEmpreinte : ModelBase
    {
        public Etudiant Etudiant { get; set; }
        public byte[] Image { get; set; }
        public byte[] Template { get; set; }
        public int Size { get; set; }
        public Fingers Finger { get; set; }
    }

    public enum Fingers
    {
        LL,
        LR,
        LM,
        LI,
        LT,
        RT,
        RI,
        RM,
        RR,
        RL
    }
}
