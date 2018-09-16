using System;
using System.Collections.Generic;

namespace UnicornigotchiApi.DataModel
{
    public partial class Play
    {
        public Play()
        { 
        }

        public int Id { get; set; }
        public bool? Hockey { get; set; }
        public bool? Football { get; set; }
         
    }
}
