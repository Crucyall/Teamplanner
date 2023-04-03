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
        
        
        speichern speichern = new speichern();


        public MainWindow()
        {
            
            InitializeComponent();
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "plannersave.db"))
            {
                dbDownload();
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

        private void dbDownload()
        {
            client.DownloadFile(new Uri(@"https://raw.githubusercontent.com/Crucyall/map/main/plannersave.db"), AppDomain.CurrentDomain.BaseDirectory + @"\plannersave.db");
            SQLiteConnection connection = new SQLiteConnection("Data Source = plannersave.db");
            connection.Open();
            connection.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Spiele spiele = new(speichern.dbladenplayer(),speichern.dbladenspiele(),this);
            spiele.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void SPStats_Click(object sender, RoutedEventArgs e)
        {
            Playerstats playert = new Playerstats(speichern.dbladenplayer(), speichern.dbladenspiele(), this, speichern.dbladenspielerstats());
            playert.Show();
            this.Visibility = Visibility.Hidden;

        }
    }
}
