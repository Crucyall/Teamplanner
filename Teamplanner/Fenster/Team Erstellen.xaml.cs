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
            mains.test = true;
            Team team = new Team() { Name = Name.Text, Owner = Owner.Text };
            safe.indbspeichernteams(team);
            this.Close();
        }
    }
}
