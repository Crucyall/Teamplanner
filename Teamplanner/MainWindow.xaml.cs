using System;
using System.Data.SQLite;
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
        public string version_temp;
     public   string version_aktuell;

        public MainWindow()
        {

            InitializeComponent();
            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "plannersave.db"))
                {
                    dbDownload(AppDomain.CurrentDomain.BaseDirectory + @"\plannersave.db");
                }
                else
                {
                    versionprüfung test = new();
                    test.version_prüfer(this);
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
                if(result == MessageBoxResult.OK)
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
            client.DownloadFile(new Uri(@"https://raw.githubusercontent.com/Crucyall/Teamplanner/master/plannersave.db"),pfad );
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

        private void Start_Closed(object sender, EventArgs e)
        {
            if (version_aktuell == version_temp)
            {

                File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"plannersavetemp.db");
            }
            else 
            {
                dbupdate dbupdate = new dbupdate();
                dbupdate.update(this);
            }

        }
    }
}
