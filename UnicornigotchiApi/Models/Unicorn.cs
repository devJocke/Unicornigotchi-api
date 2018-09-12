using System;
using System.Collections.Generic;

namespace UnicornigotchiApi.Models
{
    public partial class Unicorn
    {
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public int? FarmId { get; set; }
        public int? CareId { get; set; }

        public Care Care { get; set; }
    }
}
