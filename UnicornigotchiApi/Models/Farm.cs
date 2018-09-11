using System;
using System.Collections.Generic;

namespace UnicornigotchiApi.Models
{
    public partial class Farm
    {
        public int Id { get; set; }
        public int? BlueprintsId { get; set; }

        public Blueprints Blueprints { get; set; }
    }
}
