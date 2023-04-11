using System;
using System.Collections.Generic;
using System.Linq;
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
using static System.Net.Mime.MediaTypeNames;
using System.IO;


namespace Teamplanner.Fenster
{
    /// <summary>
    /// Interaktionslogik für ladebalken.xaml
    /// </summary>
    public partial class ladebalken : Window
    {
        versionprüfung versionprüfung=new();
        MainWindow main;
        public ladebalken(MainWindow test)
        {
            InitializeComponent();
            main = test;
        }

    }
}
