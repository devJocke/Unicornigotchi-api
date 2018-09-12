using System;
using System.Collections.Generic;
using UnicornigotchiApi.Models;

namespace UnicornigotchiApi.Models {

    public partial class Discipline
    {
        public Discipline()
        {
            Care = new HashSet<Care>();
        }

        public int Id { get; set; }
        public bool? Angry { get; set; }

        public ICollection<Care> Care { get; set; }
    }
}
