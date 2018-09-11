using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnicornigotchiApi.Models {
    public partial class Unicorn {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public int? FarmId { get; set; }

    }
}
