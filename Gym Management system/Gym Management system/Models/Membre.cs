using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Membre
    {
        public int id { get; set; }
        public string nom_membre { get; set; }
        public string prenom_membre { get; set; }
        public DateTime datenaissance_membre { get; set; }
        public string contact_membre { get; set; }
        public DateTime datejointure_membre { get; set; }
        public Groupe groupe { get; set; }


        int createMembre(string nom, string prenom, DateTime datenaissance, string contact, int groupe)
        {
            return DBAccess.Affect("INSERT INTO membres(id, nom_membre, prenom_membre, datenaissance_membre, contact_membre, datejointure_membre, groupe) " +
                "VALUES((ISNULL((SELECT MAX(id) + 1 FROM achteurs),1)),'" + nom + "','" + prenom + "','" + datenaissance + "','" + contact + "','" + DateTime.Now + "'," + groupe + ")");
        }

        int updateMembre(int id, string nom, string prenom, DateTime datenaissance, DateTime datejointure, string contact, int groupe)
        {
            return DBAccess.Affect("UPDATE membres SET nom_membre = '" + nom + "', prenom_membre = '" + prenom + "', datenaissance_membre = '" + datenaissance + "', contact_membre = '" + contact + "', datejointure_membre = '" + datejointure + "', groupe = " + groupe + " WHERE id = " + id);
        }

        int deleteMembre(int id)
        {
            return DBAccess.Affect("DELETE FROM membres WHERE id = " + id);
        }


        DataTable Membres()
        {
            return DBAccess.Read("SELECT * FROM membres");
        }

        DataTable MembrePayments(int membre)
        {
            return DBAccess.Read("SELECT * FROM payments WHERE membre = " + membre);
        }

        public void getMembre(int id)
        {
            DataRow dr = DBAccess.Read("SELECT * FROM membres WHERE id = " + id).Rows[0];
            if (dr != null)
            {
                this.nom_membre = dr["nom_membre"].ToString();
                this.prenom_membre = dr["prenom_membre"].ToString();
                this.datejointure_membre = DateTime.Parse(dr["datejointure_membre"].ToString());
                this.datenaissance_membre = DateTime.Parse(dr["datenaissance_membre"].ToString());
                this.contact_membre = dr["contact_membre"].ToString();
                this.groupe.getGroupe(int.Parse(dr["groupe"].ToString()));
                this.id = id;
            }
        }
    }
}