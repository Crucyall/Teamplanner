using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Teamplanner
{
    public class Spielec
    {
        public int index { get; set; }
        public string Team1 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public string Team2 { get; set; }
        public string players { get; set; }

        public string map { get; set; }
        public bool check { get; set; }
    }
}
