using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public partial class Unicorn
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public int? UnicornCareId { get; set; }
        public int? FarmId { get; set; }

        public Farm Farm { get; set; }
        public Care UnicornCare { get; set; }
    } 

}
