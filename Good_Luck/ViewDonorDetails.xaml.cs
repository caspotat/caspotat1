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
    /// Interaction logic for ViewDonorDetails.xaml
    /// </summary>
    public partial class ViewDonorDetails : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        public ViewDonorDetails()
        {
            InitializeComponent();
        }
        public ViewDonorDetails(int id)
        {
            InitializeComponent();
            Donor donor = db.Donors.FirstOrDefault(x => x.DonorId == id);
            string dn = donor.FirstName + " " + donor.LastName;
            fn.Text = dn;     
            Adress a = db.Adresses.FirstOrDefault(y => y.AdressId == donor.AdressId);
            alladdress.Text = a.Street + " " + a.NumBuilding + ", " + a.City;
            phone.Text = donor.Phone;
            level.Text = donor.Level.ToString();
            gr.Text = donor.GroupId.ToString();
            ld.Text = donor.LastDonation.ToString();
            comment.Text = donor.Comments;
            ct.Text = donor.CollectTime;
            //Contacts1 c = db.Contacts1.FirstOrDefault(r => r.DonorId == id);
            //Student s = db.Students.FirstOrDefault(l => l.StudentId == c.StudentId);
            //string names=s.FirstName+" "+s.LastName;
           //allcontact.Text = c.KindOfContact.ToString() + " של " + names;
        }
    }
}
