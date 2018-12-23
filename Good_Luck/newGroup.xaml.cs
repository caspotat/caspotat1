using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for newGroup.xaml
    /// </summary>
    public partial class newGroup : Window
    {
        newCaspotatdb3Entities5 db = new newCaspotatdb3Entities5();
        ObservableCollection<Student> studentsInGroup = new ObservableCollection<Student>();
        int leader;
        public newGroup()
        {
            InitializeComponent();
            cmbClasses.ItemsSource = new List<string>() { "א","ב","ג"};
            loadgrid();
        }
        private void loadgrid()
        {
            //dg1.DataContext = studentsInGroup;
            var data = db.Students.Where(r => r.LeaderId == null).ToList();
            dg1.ItemsSource = data.ToList();
            dg1.DataContext = studentsInGroup;
        }
        private void colorBK(object sender, SelectionChangedEventArgs e)
        {
            studentsInGroup.Add((e.Source as DataGrid).CurrentItem as Student);
        }

        private void dg1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void cmbClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selClass = cmbClasses.SelectedItem.ToString();
            List<Student> l = new List<Student>();
            l = db.Students.Where(r => r.Class == selClass && r.LeaderId == null).ToList();
            dg1.ItemsSource = l;
        }

       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            leader = int.Parse((dg1.SelectedItem as Student).StudentId.ToString());
        }
    }
}
