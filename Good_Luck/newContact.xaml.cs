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
    /// Interaction logic for newContact.xaml
    /// </summary>
    public partial class newContact : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        public newContact()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contacts1 c = new Contacts1();
            c.DonorId = int.Parse(donorId.Text);
            c.StudentId = int.Parse(studentid.Text);
            c.KindOfContact = int.Parse(kindofcontact.Text);
            //d.CollectTime = this.collectime.Text;
            try
            {
                db.Contacts1.Add(c);
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
