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
    /// Interaction logic for ViewStudentDetails.xaml
    /// </summary>
    public partial class ViewStudentDetails : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        int sId;
        public ViewStudentDetails()
        {
            InitializeComponent();
        }
        public ViewStudentDetails(int id)
        {
            InitializeComponent();
            sId = id;
            Student s = db.Students.FirstOrDefault(x => x.StudentId == id);
            string str = s.FirstName + " " + s.LastName;
            fn.Text = str;
            phone.Text = s.Phone;
            cl.Text = s.Class;

        }

        private void mygroup(object sender, RoutedEventArgs e)
        {
            ViewMyGroup vm = new ViewMyGroup(sId);
            vm.Show();
        }

    }
}
