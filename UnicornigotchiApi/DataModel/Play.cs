using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnicornigotchiApi.DataModel
{
     public partial class Play   {
        public Play()
        { 
        }
                 public int Id { get; set; } 
        public bool? Hockey { get; set; }
        public bool? Football { get; set; } 
    }
}
