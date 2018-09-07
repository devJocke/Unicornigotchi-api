using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public partial class Toilet
    {
        public Toilet()
        {
            Care = new HashSet<Care>();
        }

        public int Id { get; set; }
        public bool? Flush { get; set; }

        public ICollection<Care> Care { get; set; }
    }
}
