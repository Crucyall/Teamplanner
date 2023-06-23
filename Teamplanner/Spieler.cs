using System.Windows.Controls;

namespace Teamplanner
{
    public class Spieler
    {
        public int index { get; set; }
        public string Name { get; set; }
        public string TeamRolle { get; set; }
        public string Spielerrolle { get; set; }

        public bool check { get; set; }

        public string team { get; set; }

        //public Spieler()
        //{ }

        //public Spieler(string name, string teamRolle, string spielerrolle)
        //{
        //    this.name = name;
        //    TeamRolle = teamRolle;
        //    this.spielerrolle = spielerrolle;
        //}
    }
}
