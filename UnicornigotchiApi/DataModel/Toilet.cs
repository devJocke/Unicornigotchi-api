using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnicornigotchiApi.DataModel
{
     public partial class Toilet  {
        public Toilet()  { }
        public int Id { get; set; }

        public int? Flush { get; set; }
        
    }
}
