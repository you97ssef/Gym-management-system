using System;
using System.Collections.Generic;

#nullable disable

namespace Gym_Core.Models
{
    public partial class Membre
    {
        public Membre()
        {
            Payements = new HashSet<Payement>();
        }

        public int Id { get; set; }
        public string NomMembre { get; set; }
        public string PrenomMembre { get; set; }
        public DateTime? DatenaissanceMembre { get; set; }
        public string ContactMembre { get; set; }
        public DateTime? DatejointureMembre { get; set; }
        public int? Groupe { get; set; }

        public virtual Groupe GroupeNavigation { get; set; }
        public virtual ICollection<Payement> Payements { get; set; }
    }
}
