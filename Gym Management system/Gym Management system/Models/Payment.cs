using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class Payment
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public decimal montant { get; set; }
        public string description { get; set; }


        int createPayment(decimal montant, string description, int membre)
        {
            return DBAccess.Affect("INSERT INTO payments VALUES(, '" + DateTime.Now + "', '" + montant + "', '" + description + "', " + membre + ")");
        }

        int updatePayment(int id, decimal montant, string description, int membre)
        {
            return DBAccess.Affect("UPDATE payments SET membre = " + membre + ", date = '" + DateTime.Now + "', montant = '" + montant + "', description = '" + description + "' WHERE id = " + id);
        }

        int deletePayment(int id)
        {
            return DBAccess.Affect("DELETE FROM payments WHERE id = " + id);
        }
    }
}