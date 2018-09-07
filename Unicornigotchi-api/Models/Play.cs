using System;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public partial class Play
    {
        public Play()
        {
            Care = new HashSet<Care>();
        }

        public int Id { get; set; }
        public bool? Hockey { get; set; }
        public bool? Football { get; set; }

        public ICollection<Care> Care { get; set; }
    }
}
