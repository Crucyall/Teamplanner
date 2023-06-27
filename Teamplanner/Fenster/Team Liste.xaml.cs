using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Teamplanner.Fenster
{
    /// <summary>
    /// Interaktionslogik für Team_Liste.xaml
    /// </summary>
    public partial class Team_Liste : Window
    {
        MainWindow main;
        speichern speichern = new speichern();
        Team_Erstellen team_Erstellen;
        public Team_Liste(MainWindow mains)
        {
            InitializeComponent();
            main = mains;
            teamlist.ItemsSource = speichern.teamladen();
            team_Erstellen = new Team_Erstellen(main);
        }

        private void erstellen_Click(object sender, RoutedEventArgs e)
        {
            team_Erstellen.ShowDialog();

            teamlist.ItemsSource = speichern.teamladen();
            team_Erstellen = new Team_Erstellen(main);

        }
    }
}
