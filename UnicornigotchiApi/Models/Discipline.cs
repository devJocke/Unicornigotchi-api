using System;
using System.Collections.Generic;
using UnicornigotchiApi.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            Care = new HashSet<Care>();
        }

        public int Id { get; set; }
        public bool? Angry { get; set; }

        public ICollection<Care> Care { get; set; }
    }
}
