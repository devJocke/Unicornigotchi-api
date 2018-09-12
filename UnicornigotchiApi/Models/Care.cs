using System;
using System.Collections.Generic;

namespace UnicornigotchiApi.Models
{
    public partial class Care
    {
        public Care()
        {
            Unicorn = new HashSet<Unicorn>();
        }

        public int Id { get; set; }

        public ICollection<Unicorn> Unicorn { get; set; }
    }
}
