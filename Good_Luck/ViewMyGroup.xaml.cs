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
    /// Interaction logic for ViewMyGroup.xaml
    /// </summary>
    public partial class ViewMyGroup : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();

        public ViewMyGroup()
        {
            InitializeComponent();
        }
        public ViewMyGroup(int id)
        {
            InitializeComponent();
            Student s= db.Students.FirstOrDefault(x => x.StudentId == id);
            string str = s.FirstName + " " + s.LastName;
            studentName.Text = str;
            int lId = int.Parse(s.LeaderId.ToString());
            Student l = db.Students.FirstOrDefault(y => y.StudentId == lId);
            leaderName.Text = l.FirstName + " " + l.LastName;
            foreach(Student one_s in db.Students)
            {
                
                if(one_s.LeaderId==lId && one_s.StudentId!=id)
                {
                    str = one_s.FirstName + " " + one_s.LastName;
                    studentsingroup.Items.Add(str);
                }
            }
            
        }
    }
}
