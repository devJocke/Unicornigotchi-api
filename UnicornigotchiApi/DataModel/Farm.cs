using System;
using System.Collections.Generic;

namespace UnicornigotchiApi.DataModel
{
    public partial class Farm
    {
        public int Id { get; set; }
        public int? BlueprintsId { get; set; }

        public Blueprints Blueprints { get; set; }
    }
}
