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
    /// Interaction logic for newAndUpdateStudent.xaml
    /// </summary>
    public partial class newAndUpdateStudent : Window
    {

        newCaspotatdb3Entities2 db = new newCaspotatdb3Entities2();
        public newAndUpdateStudent()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Student d = new Student();
            if (namep.Text == "" || lastn.Text == "" || Class.Text == "")
                MessageBox.Show("נא להכניס נתונים לכל השדות המסומנים בכוכבית");
            else
            {

                d.FirstName = this.namep.Text;
                d.LastName = this.lastn.Text;
                d.Phone = this.phone.Text;
                d.Class = this.Class.Text;
                if (leaderId.Text?.Length > 1)
                    d.LeaderId = int.Parse(this.leaderId.Text);


                try
                {
                    db.Students.Add(d);
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
