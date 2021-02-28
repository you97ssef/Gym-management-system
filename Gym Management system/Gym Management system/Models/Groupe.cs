using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Groupe
    {
        public int id { get; set; }
        public string nom_groupe { get; set; }
        public string description_groupe { get; set; }


        int createGroupe(string nom, string description)
        {
            return DBAccess.Affect("INSERT INTO groupes(id, nom_groupe, description_groupe) VALUES((ISNULL((SELECT MAX(id) + 1 FROM achteurs),1)), '" + nom + "', '" + description + "')");
        }

        int updateGroupe(int id, string nom, string description)
        {
            return DBAccess.Affect("UPDATE groupes SET nom_groupe = '" + nom + "', description_groupe = '" + description + "' WHERE id = " + id);
        }

        int deleteGroupe(int id)
        {
            return DBAccess.Affect("DELETE FROM groupes WHERE id = " + id);
        }

        DataTable Groupes()
        {
            return DBAccess.Read("SELECT * FROM groupes");
        }

        DataTable GroupeMembres(int groupe)
        {
            return DBAccess.Read("SELECT * FROM membres WHERE groupe = " + groupe);
        }

        public void getGroupe(int id)
        {
            DataRow dr = DBAccess.Read("SELECT * FROM groupes WHERE id = " + id).Rows[0];
            if (dr != null)
            {
                this.nom_groupe = dr["nom_groupe"].ToString();
                this.description_groupe = dr["description_groupe"].ToString();
                this.id = id;
            }
        }
    }
}