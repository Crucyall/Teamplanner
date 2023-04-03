using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Teamplanner.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Teamplanner.Fenster
{
    /// <summary>
    /// Interaktionslogik für Spieleredit.xaml
    /// </summary>
    public partial class Spieleredit
    {
        List<Spieler> spielerList;
        spielerliste list;
        public Spieleredit(spielerliste spieler)
        {
            InitializeComponent();

            spielerList = spieler.spielerList.ToList();
            list = spieler;
            foreach (Spieler item in spielerList)
            {
                if (item.check == true)
                {
                    foreach (RadioButton radio in stackPanel.Children)
                    {
                        if (radio.Content.ToString() == item.Spielerrolle.ToString())
                        {
                            radio.IsChecked = true;
                            break;
                        }
                    }
                    foreach (RadioButton radio in stack2.Children)
                    {
                        if (radio.Content.ToString() == item.TeamRolle.ToString())
                        {
                            radio.IsChecked = true;
                        }
                    }
                    Name.Text = item.Name;
                }
            }
        }


        private void ändern_Click(object sender, RoutedEventArgs e)
        {
            foreach (Spieler item in list.spielerList)
            {
                if (item.check == true)
                {
                    foreach (RadioButton radio in stackPanel.Children)
                    {
                        if (radio.IsChecked == true)
                        {
                            item.Spielerrolle = radio.Content.ToString();
                        }
                    }
                    foreach (RadioButton radio in stack2.Children)
                    {
                        if (radio.IsChecked == true)
                        {
                            item.TeamRolle = radio.Content.ToString();
                        }
                    }
                    item.Name = Name.Text;

                }
            }
            list.Spieler_Liste.ItemsSource = null;
            list.Spieler_Liste.ItemsSource = list.spielerList;
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton item in stackPanel.Children)
            {
                if (item.IsChecked == true)
                {
                }
            }

        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton item in stack2.Children)
            {
                if (item.IsChecked == true)
                {
                }
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            list.Visibility = Visibility.Visible;
        }
    }
}

