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
    /// Interaction logic for Donation2.xaml
    /// 
    /// </summary>
    public partial class Donation2 : Window
    {
        newCaspotatdb3Entities2 db = new newCaspotatdb3Entities2();
        public Donation2()
        {
            InitializeComponent();
            loaddatagrid();
        }

        private void loaddatagrid()
        {
           
                var data = from r in db.Donations select r;
                dg1.ItemsSource = data.ToList();
            
        }

        private void binddatagrid()
        {
            SqlConnection con =  new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["newCaspotatdb3Entities51"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from [Donations]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Donations");
            da.Fill(dt);
            
            dg1.ItemsSource = dt.DefaultView;


        }

      

        private void new_Donation(object sender, RoutedEventArgs e)
        {
            NewDonations n = new NewDonations();
            n.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();        
            dg1.ItemsSource = db.Donations.ToList();
        }
    }
}
