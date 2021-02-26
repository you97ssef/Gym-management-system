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


        int createPayment()
        {
            return DBAccess.Affect("INSERT INTO VALUES(,)");
        }

        int updatePayment()
        {
            return DBAccess.Affect("UPDATE SET WHERE ");
        }

        int deletePayment()
        {
            return DBAccess.Affect("DELETE FROM WHERE ");
        }
    }
}