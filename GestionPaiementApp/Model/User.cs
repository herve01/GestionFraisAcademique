using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model
{
    public class User : ModelBase
    {
        public RoleType Role { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string UserName { get; set; }
        public UserType Type { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public UserEtat Etat { get; set; }

        public User()
        {
            Type = UserType.USER;
            Etat = UserEtat.FONCTIONNEL;
            Role = RoleType.TOUT;
        }

        public string RoleString
        {
            get
            {
                return Type == UserType.ADMIN ? "Administrateur" : "Utilisateur";
            }
        }

        public string Name
        {
            get => string.Format("{3} => {0} {1} | {2}", Prenom, Nom.ToUpper(), Email, RoleString);
        }

        public string[] data
        {
            get => new string[] { Number.ToString(), Name, Role.ToString(), Etat.ToString()};
        }
    }

    public enum RoleType
    {
        TOUT,
        FRAIS,
        INSCRIPTION,
        PARAMETRE,
        PARAMETRE_INSCRIPTION,
        PARAMETRE_FRAIS
    }

    public enum UserType
    {
        ADMIN,
        USER
    }

    public enum UserEtat
    {
        FONCTIONNEL,
        BLOQUE,
        CONNECTE
    }
}
