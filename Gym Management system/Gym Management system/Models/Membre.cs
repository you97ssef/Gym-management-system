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


        int createMembre(string nom, string prenom, DateTime datenaissance, string contact, int groupe)
        {
            return DBAccess.Affect("INSERT INTO membres VALUES(,'" + nom + "','" + prenom + "','" + datenaissance + "','" + contact + "','" + DateTime.Now + "'," + groupe + ")");
        }

        int updateMembre(int id, string nom, string prenom, DateTime datenaissance, DateTime datejointure, string contact, int groupe)
        {
            return DBAccess.Affect("UPDATE membres SET nom = '" + nom + "', prenom = '" + prenom + "', datenaissance = '" + datenaissance + "', contact = '" + contact + "', datejointure = '" + datejointure + "', groupe = " + groupe + " WHERE id = " + id);
        }

        int deleteMembre(int id)
        {
            return DBAccess.Affect("DELETE FROM membres WHERE id = " + id);
        }

    }
}