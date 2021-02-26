using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Membre
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime datenaissance { get; set; }
        public string contact { get; set; }
        public DateTime datejointure { get; set; }
        public int groupe { get; set; }


        int createMembre()
        {
            return DBAccess.Affect("INSERT INTO VALUES(,)");
        }

        int updateMembre()
        {
            return DBAccess.Affect("UPDATE SET WHERE ");
        }

        int deleteMembre()
        {
            return DBAccess.Affect("DELETE FROM WHERE ");
        }

    }
}