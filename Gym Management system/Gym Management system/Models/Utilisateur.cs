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
            return DBAccess.Affect("INSERT INTO VALUES(,)");
        }

        int updateUtilisateur(string nom, string motdepasse)
        {
            return DBAccess.Affect("UPDATE SET WHERE ");
        }

        int deleteUtilisateur(string nom, string motdepasse)
        {
            return DBAccess.Affect("DELETE FROM WHERE ");
        }

    }
}