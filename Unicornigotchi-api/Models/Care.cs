using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public partial class Care
    {
        public Care()
        {
            Unicorn = new HashSet<Unicorn>();
        }

        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public int ToiletId { get; set; }
        public int PlayId { get; set; }

        public Discipline Discipline { get; set; }
        public Play Play { get; set; }
        public Toilet Toilet { get; set; }
        public ICollection<Unicorn> Unicorn { get; set; }
    }
}
