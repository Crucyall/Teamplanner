using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Teamplanner.Fenster
{
    /// <summary>
    /// Interaktionslogik für Playerstats.xaml
    /// </summary>
    public partial class Playerstats : Window
    {
        MainWindow tests;
        ObservableCollection<Spielerstats> spikes = new();
        List<Spielec> spielelist;
        List<Spielerstats>? statlist;
        List<Spielerstats>? stat2list;
        ObservableCollection<Spielerstats> playerst = new();
        speichern speichern = new speichern();

        bool vorhanden = false;
        bool änderungvorhanden;

        int matchid= 0;
        public Playerstats(List<Spieler> list, List<Spielec> spieleclist, MainWindow test, List<Spielerstats> testlist)
        {
            InitializeComponent();
            spielelist = spieleclist;
            statlist= testlist;
            foreach (Spieler spieler in list)
            {
                Button testButton = new Button();
                testButton.Content = spieler.Name;
                testButton.Name = spieler.Name;
                testButton.Click += new RoutedEventHandler(button_Click);
                SP.Children.Add(testButton);

            }
            tests = test;
            //if (testlist.Count == 0)
            //{
            //    foreach (Spielec item in spieleclist)
            //    {
            //        if (item.players.Contains(button.Name))
            //        {
            //            Spielerstats spieler = new() { name = button.Name, kills = 0, deaths = 0, entry = "", kpr = 0.00 };
            //            spikes.Add(spieler);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (Spielerstats spielerstats in statlist)
            //    {
            //        spikes.Add(spielerstats);
            //    }

            //}
            stats.ItemsSource = spikes;
        }
        void button_Click(object sender, RoutedEventArgs e)
        {
            stat2list = new();
            Button test = (Button)sender;
            Button matchbutton = new Button();

            if (!änderungvorhanden)
            {
                Matches.Children.Clear();
              
                    newstat:
                    spikes = new();
                foreach (Spielerstats testiem in statlist)
                {
                    if (testiem.name == test.Name)
                    {
                        stat2list.Add(testiem);
                        vorhanden = true;
                    }
                }

                if (stat2list.Count == 0 || !vorhanden)
                {
                    foreach (Spielec item in spielelist)
                    {
                        if (item.players.Contains(test.Name))
                        {


                            matchbutton = new Button();
                            Spielerstats spieler = new() { name = test.Name, kills = 0, deaths = 0, entry = "", kpr = 0.00, map = item.map, rounds = item.Score2 + item.Score1, matchid = item.index };
                            spikes.Add(spieler);
                            matchbutton.Content = item.index;
                            matchbutton.Name = "Match" + item.index;
                            matchbutton.Width = 25;
                            matchbutton.Click += new RoutedEventHandler(matchbutton_Click);
                            Matches.Children.Add(matchbutton);

                        }
                    }
                }
                else
                {

                    foreach (Spielerstats spielerstats in stat2list)
                    {
                      
                           
                            matchbutton = new Button();
                            spikes.Add(spielerstats);
                            matchbutton.Content = spielerstats.matchid;
                            matchbutton.Name = "Match" + spielerstats.matchid;
                            matchbutton.Width = 25;
                            matchbutton.Click += new RoutedEventHandler(matchbutton_Click);
                            Matches.Children.Add(matchbutton);
                        
                        
                        
                    }
                    foreach (Spielerstats spielerstats in stat2list)
                    {
                        if (spielelist.Count > stat2list.Count)
                        {
                            int i = 1;
                            foreach (Spielec item in spielelist)
                            {
                                if (item.players.Contains(test.Name) && item.index != spielerstats.matchid && i > stat2list.Count && i > spikes.Count)
                                {


                                    matchbutton = new Button();
                                    Spielerstats spieler = new() { name = test.Name, kills = 0, deaths = 0, entry = "", kpr = 0.00, map = item.map, rounds = item.Score2 + item.Score1, matchid = item.index };
                                    spikes.Add(spieler);
                                    matchbutton.Content = item.index;
                                    matchbutton.Name = "Match" + item.index;
                                    matchbutton.Width = 25;
                                    matchbutton.Click += new RoutedEventHandler(matchbutton_Click);
                                    Matches.Children.Add(matchbutton);

                                }
                                i++;
                            }

                        }
                    }

                }

                stats.ItemsSource = spikes;
            }
            else
            {
                string message = "Es existiren noch Ungespeicherte änderungen\n\rBitte vorher speichern";
                string caption = "Achtung";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxImage.Warning);

            }
        }
        void matchbutton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            matchid = Convert.ToInt32(button.Content.ToString());

            Eintragen.IsEnabled = true;
            foreach (Spielerstats item in stats.ItemsSource as ObservableCollection<Spielerstats>)
            {
                if (Convert.ToInt32(button.Content) == item.matchid)
                {
                    Deaths.Text = item.deaths.ToString();
                    Entry.Text = item.entry.ToString();
                    KPR.Text = item.kpr.ToString();
                    Map.Text = item.map.ToString();
                    Rounds.Text = item.rounds.ToString();
                    Kills.Text = item.kills.ToString();
                }
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            tests.Visibility = Visibility.Visible;

        }

        private void stats_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            foreach (Spielerstats item in stats.ItemsSource as ObservableCollection<Spielerstats>)
            {
                playerst.Add(item);
            }
            änderungvorhanden = false;

            stats.ItemsSource = spikes;
            speichern.indbspeichernspielerstats(playerst);
        }

        private void Eintragen_Click(object sender, RoutedEventArgs e)
        {
             spikes = stats.ItemsSource as ObservableCollection<Spielerstats>;

            spikes[matchid - 1].kills = Convert.ToInt32( Kills.Text);
            spikes[matchid - 1].deaths = Convert.ToInt32(Deaths.Text);
            spikes[matchid - 1].entry = Entry.Text;
            spikes[matchid - 1].kpr = Math.Round( Convert.ToDouble(Kills.Text)/ spikes[matchid-1].rounds,2);

            stats.ItemsSource = null;
            stats.ItemsSource = spikes;
            stats.Focus();
            änderungvorhanden = true;

        }

        private void Kills_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((char.IsControl(((char)e.Key)) || char.IsLetter(((char)e.Key)) || ((char)e.Key) == ' ')) 
            {

                return;
            }
            else
            {
                string message = "Bitte nur Zahlen";
                string caption = "Fehler";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxImage.Error);

            }
            e.Handled = true;

        }

        private void Kills_text(object sender, TextChangedEventArgs e)
        {
            var test = sender as TextBlock;
            if (Kills.Text != "0" && Kills.Text !="")

            {

                KPR.Text = Math.Round(Convert.ToDouble(Kills.Text) / Convert.ToDouble(Rounds.Text), 2).ToString();



            }
            e.Handled = true;

        }
    }
}
