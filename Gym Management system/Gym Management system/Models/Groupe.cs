using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Groupe
    {
        public string nom { get; set; }
        public string description { get; set; }


        int createGroupe(string nom, string description)
        {
            return DBAccess.Affect("INSERT INTO groupes VALUES(, '" + nom + "', '" + description + "')");
        }

        int updateGroupe(int id, string nom, string description)
        {
            return DBAccess.Affect("UPDATE groupes SET nom = '" + nom + "', description = '" + description + "' WHERE id = " + id);
        }

        int deleteGroupe(int id)
        {
            return DBAccess.Affect("DELETE FROM groupes WHERE id = " + id);
        }

    }
}