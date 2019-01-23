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

namespace Good_Luck
{
    /// <summary>
    /// Interaction logic for NewDonations.xaml
    /// </summary>
    public partial class NewDonations : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        public NewDonations()
        {
            InitializeComponent();
        }

       
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Donation d = new Donation();
            if (donorId.Text == "" || amount.Text == "")
                MessageBox.Show("נא להכניס נתונים לכל השדות ");
            else
            {
                d.DonorId = int.Parse(this.donorId.Text);
                d.Amount = decimal.Parse(this.amount.Text);

                try
                {
                    db.Donations.Add(d);
                    db.SaveChanges();
                    MessageBox.Show("the data saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "warning");
                }
                this.Close();
            }
        }
    }
}
