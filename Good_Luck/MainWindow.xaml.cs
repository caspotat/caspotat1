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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
namespace Good_Luck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Donor_Click(object sender, RoutedEventArgs e)
        {
            NewDonor r = new NewDonor();
            r.Show();
        }
         private void Button_Click(object sender, RoutedEventArgs e)
        {
            Donation2 d = new Donation2();
            d.Show();
        }
        private void newDonation_Click(object sender, RoutedEventArgs e)
        {
            NewDonations d = new NewDonations();
            d.Show();
        }

      

        private void donors2(object sender, RoutedEventArgs e)
        {
            Donors2 r = new Donors2();
            r.Show();
        }
        private void Students_Click(object sender, RoutedEventArgs e)
        {
            Students s = new Students();
            s.Show();
        }
        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            Groups g = new Groups();
            g.Show();
        }
    }
}
