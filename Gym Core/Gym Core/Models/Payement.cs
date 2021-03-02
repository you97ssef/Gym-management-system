using System;
using System.Collections.Generic;

#nullable disable

namespace Gym_Core.Models
{
    public partial class Payement
    {
        public int Id { get; set; }
        public DateTime? DatePayement { get; set; }
        public decimal? MontantPayement { get; set; }
        public string DescriptionPayement { get; set; }
        public int? Membre { get; set; }

        public virtual Membre MembreNavigation { get; set; }
    }
}
