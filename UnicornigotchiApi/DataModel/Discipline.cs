using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnicornigotchiApi.DataModel {

    public class Discipline  {
        public int Id{ get; set; }
        public int? Angry { get; set; }
    }
} 