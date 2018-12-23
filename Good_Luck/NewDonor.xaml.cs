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
    /// Interaction logic for NewDonor.xaml
    /// </summary>
    public partial class NewDonor : Window
    {
        newCaspotatdb3Entities5 db = new newCaspotatdb3Entities5();
        public NewDonor()
        {
            this.DataContext = db;
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Donor d = new Donor();
            if (namep.Text == "" || lastn.Text == "" || phone.Text == "" || groupId.Text == "" || level.Text == "")
                MessageBox.Show("נא להכניס נתונים לכל השדות המסומנים בכוכבית");
            else
            {
                d.FirstName = this.namep.Text;
                d.LastName = this.lastn.Text;
                d.Phone = this.phone.Text;
                d.GroupId = int.Parse(this.groupId.Text);
                d.Level = short.Parse(this.level.Text);
                d.LastDonation = int.Parse(this.lastdo.Text);
                d.Comments = this.comments.Text;
                //d.CollectTime = this.collectime.Text;
                try
                {
                    db.Donors.Add(d);
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
