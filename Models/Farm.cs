using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public partial class Farm
    {
        public Farm()
        {
            Unicorn = new HashSet<Unicorn>();
        }

        public int Id { get; set; }
        public int? BlueprintsId { get; set; }

        public Blueprints Blueprints { get; set; }
        public ICollection<Unicorn> Unicorn { get; set; }
    }
}
