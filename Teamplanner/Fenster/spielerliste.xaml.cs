using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Teamplanner.Fenster;

namespace Teamplanner.Windows
{
    /// <summary>
    /// Interaktionslogik für spielerliste.xaml
    /// </summary>
    public partial class spielerliste : Window
    {
        Spieler? spieler;
        public ObservableCollection<Spieler> spielerList = new();
        List<Spieler> spielers = new List<Spieler>();
        List<Spieler> delete = new List<Spieler>();

        speichern speichern = new speichern();

        bool gespeichert;

        MainWindow tests;
        public spielerliste(MainWindow test)
        {
            InitializeComponent();
            gespeichert = false;
            spielers = speichern.dbladenplayer();
            listtoobser();
            Spieler_Liste.ItemsSource = spielerList;
            tests = test;
            ObservableCollection<string> teamname= new ObservableCollection<string>();
            foreach(Team item in speichern.teamladen())
            {
                teamname.Add(item.Name);
            }
            teamlists.ItemsSource = teamname;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spielerList = addplayer();
            Spieler_Liste.ItemsSource = spielerList;



        }

        private ObservableCollection<Spieler> addplayer()
        {
            string spielerrolle = "";
            string teamrolle = "";
            int index = spielerList.Count + 1;
            if (teamlists.Text != "")
            {
                foreach (RadioButton item in stackPanel.Children)
                {
                    if (item.IsChecked == true)
                    {
                        spielerrolle = item.Content as string;
                    }
                }
                foreach (RadioButton item in stack2.Children)
                {
                    if (item.IsChecked == true)
                    {
                        teamrolle = item.Content as string;
                    }
                }
                if (teamrolle != "Coach")
                {
                    spielerList.Add(new Spieler()
                    {
                        index = index,

                        Name = Name.Text,
                        Spielerrolle = spielerrolle,
                        TeamRolle = teamrolle,
                        check = false,
                        team = teamlists.Text
                    });
                    spielers.Add(new Spieler()
                    {
                        index = index,
                        Name = Name.Text,
                        Spielerrolle = spielerrolle,
                        TeamRolle = teamrolle,
                        check = false,
                        team = teamlists.Text

                    });
                }
                else
                {
                    spielerList.Add(new Spieler()
                    {
                        index = index,

                        Name = Name.Text,
                        Spielerrolle = teamrolle,
                        TeamRolle = teamrolle,
                        check = false,
                        team = teamlists.Text

                    });
                    spielers.Add(new Spieler()
                    {
                        index = index,
                        Name = Name.Text,
                        Spielerrolle = teamrolle,
                        TeamRolle = teamrolle,
                        check = false,
                        team = teamlists.Text

                    });

                }
            }
            else
            {
                string message = "Bitte eine Team auswählen";
                string caption = "Fehler";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxImage.Error);

            }
            return spielerList;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            speichern.indbspeichernplayer(spielers);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            foreach (RadioButton item in stackPanel.Children)
            {
                if (item.IsChecked == true || radioButton.Content.ToString() == "Coach")
                {
                    Eintragen.IsEnabled = true;
                    if (radioButton.Content.ToString() == "Coach")
                    {
                        stackPanel.IsEnabled = false;
                    }

                }
                else
                {
                    stackPanel.IsEnabled = true;


                }
            }

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton item in stack2.Children)
            {
                if (item.IsChecked == true)
                {
                    Eintragen.IsEnabled = true;
                }
            }

        }
        private void listtoobser()
        {
            foreach (Spieler item in spielers)
            {
                spielerList.Add(item);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tests.Visibility = Visibility.Visible;

        }

        private void Löschen_Click(object sender, RoutedEventArgs e)
        {

            foreach (Spieler item in Spieler_Liste.ItemsSource)
            {
                if (item.check == true)
                {
                    delete.Add(item);
                }

            }
            foreach (Spieler item in delete)
            {
                speichern.indblöschennplayer(item);
                spielerList.Remove(item);
                Spieler_Liste.ItemsSource = spielerList;
            }
        }

        private void ändern_Click(object sender, RoutedEventArgs e)
        {
            int nränderungen = 0;
            foreach (Spieler item in Spieler_Liste.ItemsSource)
            {
                if (item.check == true)
                {
                    Spieleredit spieleredit = new(this);
                    spieleredit.Show();
                    item.check = false;
                    this.Visibility = Visibility.Hidden;
                    break;

                }

            }

        }
    }
}
