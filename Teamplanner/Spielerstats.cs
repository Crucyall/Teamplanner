using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamplanner
{
   public class Spielerstats
    {
        public string name { get; set; }
        public double kills { get; set; }
        public double deaths { get; set; }

        public string entry { get; set; }
        public double kpr { get; set; }

        public string map { get; set; }

        public int rounds { get; set; }

        public int matchid { get; set; }

        public int dbid { get; set; }

    }
}
