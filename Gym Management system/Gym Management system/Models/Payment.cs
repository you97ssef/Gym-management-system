using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Payment
    {
        public int id { get; set; }
        public DateTime date_payement { get; set; }
        public decimal montant_payement { get; set; }
        public string description_payement { get; set; }
        public Membre membre { get; set; }


        int createPayment(decimal montant, string description, int membre)
        {
            return DBAccess.Affect("INSERT INTO payments(id, date_payement, montant_payement, description_payement, membre) " +
                "VALUES((ISNULL((SELECT MAX(id) + 1 FROM achteurs),1)), '" + DateTime.Now + "', '" + montant + "', '" + description + "', " + membre + ")");
        }

        int updatePayment(int id, decimal montant, string description, int membre)
        {
            return DBAccess.Affect("UPDATE payments SET membre = " + membre + ", date_payement = '" + DateTime.Now + "', montant_payement = '" + montant + "', description_payement = '" + description + "' WHERE id = " + id);
        }

        int deletePayment(int id)
        {
            return DBAccess.Affect("DELETE FROM payments WHERE id = " + id);
        }

        void getPayement(int id)
        {
            DataRow dr = DBAccess.Read("SELECT * FROM payments WHERE id = '" + id + "'").Rows[0];
            if (dr != null)
            {
                this.date_payement = DateTime.Parse(dr["date_payement"].ToString());
                this.montant_payement = decimal.Parse(dr["montant_payement"].ToString());
                this.description_payement = dr["description_payement"].ToString();
                this.membre.getMembre(int.Parse(dr["membre"].ToString()));
                this.id = id;
            }
        }

        DataTable Payments()
        {
            return DBAccess.Read("SELECT * FROM payments");
        }
    }
}