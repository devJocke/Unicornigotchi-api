using System;
using System.Collections.Generic;

namespace UnicornigotchiApi.Models
{
    public partial class Care
    {
        public int Id { get; set; }
        public int? UnicornId { get; set; }

        public Unicorn Unicorn { get; set; }
    }
}
