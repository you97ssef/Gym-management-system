using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_Core.Models
{
    public class MembreNonPayee
    {
        public int MembreId { get; set; }
        public string MembreNom { get; set; }
        public string MembrePrenom { get; set; }
        public double LastpayementIn { get; set; }
    }
}
