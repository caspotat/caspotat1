using System;
using System.Collections.Generic;
using System.Data;
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
        DataTable dt;
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        public NewDonor()
        {
            this.DataContext = db;
            
            InitializeComponent();
            getCitiesAndStreets();
        }
        public void getCitiesAndStreets()
        {
            DataSet dataSet = new DataSet();

            dataSet.ReadXml(@"C:\Users\מלכי ג'דה\Desktop\Good_Luck\City.xml");
            
            dt = dataSet.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                City.Items.Add(row[2]);
            }
            

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
                Adress a = new Adress();
                a.City = this.City.SelectedItem.ToString();
                a.Street = this.Street.SelectedItem.ToString();
                a.NumBuilding = short.Parse(this.misBuilding.Text);
                a.X = float.Parse(this.x.Text);
                a.Y = float.Parse(this.y.Text);
                d.Adress = a;
                //d.CollectTime = this.collectime.Text;
                try
                {
                    db.Adresses.Add(a);
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

        private void City_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Street.Items.Clear();
            Street.IsEnabled = true;
            DataSet dataSet2 = new DataSet();
            dataSet2.ReadXml(@"C:\Users\מלכי ג'דה\Desktop\Good_Luck\Street.xml");
            dt = dataSet2.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                if (row[2].ToString().Contains(City.SelectedItem.ToString()))
                    Street.Items.Add(row[4]);
            }
        }
    }
}
