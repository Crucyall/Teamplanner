using System.Windows;

namespace Teamplanner.Fenster
{
    /// <summary>
    /// Interaktionslogik für Team_Erstellen.xaml
    /// </summary>
    public partial class Team_Erstellen : Window
    {
        MainWindow mains;
        speichern safe;
        public Team_Erstellen(MainWindow main)
        {
            InitializeComponent();
            mains = main;
            safe = new speichern();
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            var test = safe.teamladen();
            
            mains.test = true;
            Team team = new Team() { id = test.Count+1,Name = Name.Text, Owner = Owner.Text };
            safe.indbspeichernteams(team);
            this.Close();
        }
    }
}
