using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnicornigotchiApi.DataModel
{
    public partial class Care
    {
        public Care()
        { 
        }

        public int Id { get; set; } 
        public int? DisciplineId { get; set; }
        public int? PlayId { get; set; }
        public int? ToiletId { get; set; }

        public Discipline Discipline { get; set; }
        public Play Play { get; set; }
        public Toilet Toilet { get; set; } 
    }
}
