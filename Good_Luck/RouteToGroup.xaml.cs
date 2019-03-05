using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for RouteToGroup.xaml
    /// </summary>
    public partial class RouteToGroup : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        ObservableCollection<string> adresses = new ObservableCollection<string>();
        ObservableCollection<string> students = new ObservableCollection<string>();
        public RouteToGroup()
        {
            InitializeComponent();
            ad.DataContext = adresses;
            stu.DataContext = students;
            loaddatagrid();
        }

        private void loaddatagrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GroupId", typeof(int));
            dt.Columns.Add("StudentName", typeof(string));
            db.Groups.ToList().ForEach(v => dt.Rows.Add(Convert.ToInt32(v.GroupId), db.Students.Single(stu => stu.StudentId == v.StudentId).FirstName + " " + db.Students.Single(stu => stu.StudentId == v.StudentId).LastName));
            dg1.ItemsSource = dt.DefaultView;


            //load data grid routes

            if (db.Routes.ToList().Count == 0)
            {
                CalcRoute routes = new CalcRoute();
                List<List<Adress>> r = routes.CreateRoutes();
                foreach (List<Adress> item in r)
                {
                    int routeId = db.Routes.ToList().Count == 0 ? 1 : Convert.ToInt32(db.Routes.ToList().Max(b => b.RouteId)) + 1;
                    db.Routes.Add(new Route { RouteId = routeId, level = GetLevel(item) });
                    foreach (Adress ad in item)
                    {
                        Adress a = db.Adresses.Single(b => b.AdressId == ad.AdressId);
                        a.RouteId = routeId;
                    }
                }
            }
            db.SaveChanges();

            dg2.ItemsSource = db.Routes.ToList();

        }

        private int GetLevel(List<Adress> item)
        {
            //todo: calculate level by addresses level
            return 0;
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            Route route = dg2.SelectedItem as Route;
            Group group = dg1.SelectedItem as Group;
            if (route.GroupId > 0)
            {
                MessageBoxResult result = MessageBox.Show("למסלול זה כבר מחוברת קבוצה. האם אתה בטוח שברצונך להחליף?", "החלפת מסלול לקבוצה", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }
            route.GroupId = group.GroupId;
            db.SaveChanges();
            loaddatagrid();
        }

        private void dg1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Group group = dg1.SelectedItem as Group;
            var x = db.Students.Where(s => s.LeaderId == group.StudentId).ToList();
            students.Clear();
            x.Select(p => p.FirstName + " " + p.LastName).ToList().ForEach(v => students.Add(v));

        }

        private void dg2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Route route = dg2.SelectedItem as Route;
            adresses.Clear();
            route.Adresses.Select(p => p.Street + " " + p.NumBuilding + ", " + p.City).ToList().ForEach(v => adresses.Add(v));
        }

        private void dg1_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var group = dg1.SelectedItem as DataRowView;

            int groupId = Convert.ToInt32(group.Row["GroupId"]);
            var x = db.Students.Where(s => s.LeaderId == groupId).ToList();
            students.Clear();
            x.Select(p => p.FirstName + " " + p.LastName).ToList().ForEach(v => students.Add(v));
            x.Select(p => p.FirstName + " " + p.LastName).ToList().ForEach(v => students.Add(v));

        }
    }
}
