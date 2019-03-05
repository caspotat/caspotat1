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

        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        public newAndUpdateStudent()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Student d = new Student();
            if (namep.Text == "" || lastn.Text == "" || Class.Text == "" || namep.Text.Any(char.IsDigit) || lastn.Text.Any(char.IsDigit) || Class.Text.Any(char.IsDigit) || phone.Text.Any(char.IsLetter))

            {
                if (namep.Text == "" || lastn.Text == "" || Class.Text == "")
                    MessageBox.Show("נא להכניס נתונים לכל השדות המסומנים בכוכבית");
                if (namep.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("נא להכניס שם באותיות בלבד");
                    namep.Text = "";
                }
                if (lastn.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("נא להכניס שם באותיות בלבד");
                    lastn.Text = "";
                }
                if (Class.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("נא להכניס ועד באות בלבד");
                    Class.Text = "";
                }
                if (phone.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("נא להכניס פלאפון בספרות בלבד");
                    phone.Text = "";
                }
            }
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
