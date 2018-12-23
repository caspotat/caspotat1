using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Configuration;

namespace Good_Luck
{
    /// <summary>
    /// Interaction logic for Donors2.xaml
    /// </summary>
    public partial class Donors2 : Window
    {
        newCaspotatdb3Entities5 db = new newCaspotatdb3Entities5();
        public Donors2()
        {
            InitializeComponent();
            loaddatagrid();
        }

        private void loaddatagrid()
        {
            var data = from r in db.Donors select r;
            dg1.ItemsSource = data.ToList();
        }

        private void Donor_Click(object sender, RoutedEventArgs e)
        {
            NewDonor n = new NewDonor();
            n.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            dg1.ItemsSource = db.Donors.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var donor_id = (dg1.SelectedItem as Donor).DonorId;
            Donor s = (from r in db.Donors where r.DonorId == donor_id select r).SingleOrDefault();
            db.Donors.Remove(s);
            db.SaveChanges();
            dg1.ItemsSource = db.Donors.ToList();
        }
      
        //private void binddatagrid()
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = ConfigurationManager.ConnectionStrings["newCaspotatdb3Entities51"].ConnectionString;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "select * from [Donors]";
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable("Donors");
        //    da.Fill(dt);
        //    dg1.ItemsSource = dt.DefaultView;


        //}

    }
}
