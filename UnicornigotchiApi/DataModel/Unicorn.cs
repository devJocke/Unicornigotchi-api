using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnicornigotchiApi.DataModel
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
