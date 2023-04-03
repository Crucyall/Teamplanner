using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Teamplanner.Fenster
{
    /// <summary>
    /// Interaktionslogik für Spiele.xaml
    /// </summary>
    public partial class Spiele : Window
    {
        string[]? list;
        List<Spieler> spielers = new List<Spieler>();
        List<Spielec> spielec = new List<Spielec>();
        List<Spielec> delete = new List<Spielec>();

        MainWindow tests;
        ObservableCollection<Spieler> spielerlist = new ObservableCollection<Spieler>();
        ObservableCollection<Spielec> spielelist = new ObservableCollection<Spielec>();
        speichern speichern = new speichern();
        ObservableCollection<string> maplist = new ObservableCollection<string>()
        { "Bank", "Border", "Chalet", "Theme", "Oregon","Night","Kafe","Emeralde",
            "Outback","Favela","Skyscraper","Consulate","Coastline","Clubhouse","Villa" };
        public Spiele(List<Spieler> list, List<Spielec> spieleclist, MainWindow test)
        {
            InitializeComponent();
            spielec = spieleclist;
            spielers = list;

            listtoobser();
            listtoobserspieler();
            matches.ItemsSource = spielelist;
            tests = test;
            maps.ItemsSource = maplist;
            PickedPlayer.ItemsSource = spielerlist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string players = "";
            int i = 0;
            var test = maps.Text;
            if (maps.Text != "")
            {
                foreach (var spieler in spielerlist)
                {
                    if (spieler.check == true)
                    {
                        players += spieler.Name + ",";
                        i++;
                    }
                }
                if (players != "" && i == 5)
                {
                    spielelist.Add(new Spielec()
                    {
                        index = spielelist.Count + 1,
                        Team1 = Team1.Text,
                        Score1 = Convert.ToInt32(Score1.Text),
                        Score2 = Convert.ToInt32(Score2.Text),
                        Team2 = Team2.Text,
                        players = players,
                        map = maps.Text
                    });

                    matches.ItemsSource = spielelist;
                }
                else
                {

                    string message = "Sie haben nicht genug oder zu viele Spieler ausgewählt(max 5)";
                    string caption = "Fehler";
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, MessageBoxImage.Error);


                }
            }
            else
            {
                string message = "Bitte eine Karte wählen";
                string caption = "Fehler";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxImage.Error);

            }

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);

            }
        }


        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            speichern.indbspeichernspiele(spielelist);
        }
        private void listtoobser()
        {
            foreach (Spielec item in spielec)
            {
                spielelist.Add(item);
            }
        }
        private void listtoobserspieler()
        {
            foreach (Spieler item in spielers)
            {
                spielerlist.Add(item);
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            tests.Visibility = Visibility.Visible;
        }
        private void Löschen_Click(object sender, RoutedEventArgs e)
        {

            foreach (Spielec item in matches.ItemsSource)
            {
                if (item.check == true)
                {
                    delete.Add(item);
                }

            }
            foreach (Spielec item in delete)
            {
                speichern.indblöschenspiele(item);
                spielelist.Remove(item);
                matches.ItemsSource = spielelist;
            }
        }

    }
}
