using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Utilisateur
    {
        public string nom_utilisateur { get; set; }
        public string motdepasse_utilisateur { get; set; }

        public int createUtilisateur(string nom, string motdepasse)
        {
            return DBAccess.Affect("INSERT INTO utilisateurs(nom_utilisateur, motdepasse_utilisateur) VALUES('" + nom + "','" + motdepasse + "')");
        }

        public int updateUtilisateur(string nom, string motdepasse, string nvnom)
        {
            return DBAccess.Affect("UPDATE utilisateurs SET nom_utilisateur = '" + nvnom + "', motdepasse_utilisateur = '" + motdepasse + "' WHERE nom_utilisateur = '" + nom + "'");
        }

        public int deleteUtilisateur(string nom)
        {
            return DBAccess.Affect("DELETE FROM utilisateurs WHERE nom_utilisateur = '" + nom + "'");
        }

        public void getUtilisateur(string nom)
        {
            DataRow dr = DBAccess.Read("SELECT * FROM utilisateurs WHERE nom_utilisateur = '" + nom + "'").Rows[0];
            if(dr != null)
            {
                this.nom_utilisateur = dr["nom_utilisateur"].ToString();
                this.motdepasse_utilisateur = dr["motdepasse_utilisateur"].ToString();
            }
        }

        DataTable Utilisateurs()
        {
            return DBAccess.Read("SELECT * FROM utilisateurs");
        }

    }
}