using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamBoatService.Resources {
    public class Variable {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public double Value { get; set; }
    }
}