using System;
using System.Collections.Generic;

#nullable disable

namespace Gym_Core.Models
{
    public partial class Groupe
    {
        public Groupe()
        {
            Membres = new HashSet<Membre>();
        }

        public int Id { get; set; }
        public string NomGroupe { get; set; }
        public string DescriptionGroupe { get; set; }

        public virtual ICollection<Membre> Membres { get; set; }
    }
}
