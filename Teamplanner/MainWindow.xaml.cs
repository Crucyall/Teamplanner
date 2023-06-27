using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using Teamplanner.Fenster;
using Teamplanner.Windows;
namespace Teamplanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient client = new WebClient();

        ladebalken ladebalken;
        speichern speichern = new speichern();
        Team_Erstellen team;
        public string version_temp;
        public string version_aktuell;
        public bool test;
        List<Team> teamss;
        Team_Liste team_liste;
        public MainWindow()
        {

            InitializeComponent();
            test = false;
            teamss = speichern.teamladen();
            if (teamss.Count == 0)
            {
                while (test != true)
                {
                    team = new Team_Erstellen(this);
                    team.ShowDialog();
                    if (!test)
                    {
                        string message = "Sie müssen ein Team einrichten damit Sie weiter machen können.\nWollen sie das Programm Schliessen";
                        string caption = "Achtung";
                        MessageBoxButton buttons = MessageBoxButton.YesNo;
                        var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Error);
                        if (result == MessageBoxResult.Yes)
                        {
                            this.Close();
                            test = true;
                        }

                    }
                }
            }

            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "plannersave.db"))
                {
                    dbDownload(AppDomain.CurrentDomain.BaseDirectory + @"\plannersave.db");
                }
            }
            catch (Exception)
            {
                string message = "Bitte Stellen Sie sicher das Sie eine Verbindung zu dem Internet haben." +
                    "Wenn Sie einen Proxy benutzen stellen Sie bitte sicher das Das Programm diesen Nutzen kann" +
                    "Möchten Sie das Programm Schliessen?";
                string caption = "Achtung";
                MessageBoxButton buttons = MessageBoxButton.OK;
                var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Error);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
                throw;
            }


            //var test = speichern.dbladenspielerstats();
            //string stop = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spielerliste spielerliste = new(this);
            spielerliste.Activate();
            spielerliste.Show();
            this.Visibility = Visibility.Hidden;

        }

        public void dbDownload(string pfad)
        {
            client.DownloadFile(new Uri(@"https://raw.githubusercontent.com/Crucyall/Teamplanner/master/plannersave.db"), pfad);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Spiele spiele = new(speichern.dbladenplayer(), speichern.dbladenspiele(), this);
            spiele.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void SPStats_Click(object sender, RoutedEventArgs e)
        {
            Playerstats playert = new Playerstats(speichern.dbladenplayer(), speichern.dbladenspiele(), this, speichern.dbladenspielerstats());
            playert.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void teams_Click(object sender, RoutedEventArgs e)
        {
            team_liste = new Team_Liste(this);
            team_liste.Show();
        }
    }
}
