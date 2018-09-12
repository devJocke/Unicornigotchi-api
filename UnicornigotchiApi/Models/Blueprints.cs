using System;
using System.Collections.Generic;

namespace UnicornigotchiApi.Models
{
    public partial class Blueprints
    {
        public Blueprints()
        {
            Farm = new HashSet<Farm>();
        }

        public int Id { get; set; }
        public bool? FishingShack { get; set; }
        public bool? Running { get; set; }

        public ICollection<Farm> Farm { get; set; }
    }
}
