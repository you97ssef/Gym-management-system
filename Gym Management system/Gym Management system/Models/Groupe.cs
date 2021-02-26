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


        int createGroupe(string nom, string motdepasse)
        {
            return DBAccess.Affect("INSERT INTO VALUES(,)");
        }

        int updateGroupe(string nom, string motdepasse)
        {
            return DBAccess.Affect("UPDATE SET WHERE ");
        }

        int deleteGroupe(string nom, string motdepasse)
        {
            return DBAccess.Affect("DELETE FROM WHERE ");
        }

    }
}