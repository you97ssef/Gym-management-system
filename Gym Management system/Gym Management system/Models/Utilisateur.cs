using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Utilisateur
    {
        public string nom { get; set; }
        public string motdepasse { get; set; }

        int createUtilisateur(string nom, string motdepasse)
        {
            return DBAccess.Affect("INSERT INTO utilisateurs VALUES('" + nom + "','" + motdepasse + "')");
        }

        int updateUtilisateur(string nom, string motdepasse, string nvnom)
        {
            return DBAccess.Affect("UPDATE utilisateurs SET nom = '" + nvnom + "', motdepasse = '" + motdepasse + "' WHERE nom='" + nom + "'");
        }

        int deleteUtilisateur(string nom)
        {
            return DBAccess.Affect("DELETE FROM utilisateurs WHERE nom = '" + nom + "'");
        }

    }
}