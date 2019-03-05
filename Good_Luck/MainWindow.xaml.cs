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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PointAddress p1 = Distance.PointFromAddress("בני ברק", "בר אילן", 28);
            PointAddress p2 = Distance.PointFromAddress("בני ברק", "בר אילן", 18);
            MessageBox.Show(Distance.distanceFromPoints(p1, p2).ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CalcRoute c = new CalcRoute();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            newContact n = new newContact();
            n.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ReadMails r = new ReadMails();
            r.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RouteToGroup r = new RouteToGroup();
            r.Show();
        }
    }
}
