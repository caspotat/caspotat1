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

        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        ObservableCollection<Student> studentsInGroup = new ObservableCollection<Student>();
        int leader;
        static int misClicks = 0;

        public int Leader
        {
            get { return (int)GetValue(LeaderProperty); }
            set { SetValue(LeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Leader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeaderProperty =
            DependencyProperty.Register("Leader", typeof(int), typeof(newGroup), new PropertyMetadata(0));


        

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
            studentsInGroup.Add((e.Source as DataGrid).SelectedItem as Student);
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
                dg1.IsEnabled = true;
                choose.Visibility = Visibility.Hidden;
                buildGroup.Visibility = Visibility.Visible;
                MessageBox.Show("נא לבחור ראש קבוצה");
            
            

        }

       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Leader = int.Parse((dg1.SelectedItem as Student).StudentId.ToString());
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            labelLeader.Visibility = Visibility.Visible;
            try
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItem != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        Student d = (Student)dgr.Item;
                        string name = d.FirstName+" "+d.LastName;
                        listToGroup.Items.Add(name);                        
                        if(misClicks==0)//אם זה ראש הקבוצה
                        {
                            leader = int.Parse(d.StudentId.ToString());
                            ledName.Content = d.FirstName + " " + d.LastName;
                            misClicks++;
                        }
                        d.LeaderId = leader;
                        db.SaveChanges();
                       
                        //dg1.Items.Remove(grid.SelectedItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        if (listToGroup.Items.Count > 0)
        {
            Group g = new Group();
            g.StudentId = leader;
            db.Groups.Add(g);
            db.SaveChanges();
            Group newgroup = db.Groups.Where(r => r.StudentId == leader).SingleOrDefault();
            int misgroup = int.Parse(newgroup.GroupId.ToString());
            MessageBox.Show("הקבוצה נוצרה בהצלחה, מספר הקבוצה: " + misgroup);
            this.Close();
        }
        else
          
            MessageBox.Show("לא נבחר אף בחור לקבוצה זו");
    }
    }
}
