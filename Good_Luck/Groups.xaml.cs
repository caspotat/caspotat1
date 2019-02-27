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
    /// Interaction logic for Groups.xaml
    /// </summary>
    public partial class Groups : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
       
        public Groups()
        {
            InitializeComponent();
            loaddatagrid();
        }
        private void loaddatagrid()
        {

            var data = from r in db.Groups select r;
            dg1.ItemsSource = data.ToList();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var group_id = (dg1.SelectedItem as Group).GroupId;
            Group s = (from r in db.Groups where r.GroupId == group_id select r).SingleOrDefault();
            db.Groups.Remove(s);
            db.SaveChanges();
            dg1.ItemsSource = db.Groups.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            dg1.ItemsSource = db.Groups.ToList();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            newGroup n = new newGroup();
            n.Show();
           
        }

        private void dg1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    string stam = "";
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItem != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        Group s = (Group)dgr.Item;
                        int id = int.Parse(s.StudentId.ToString());
                        int groupid= int.Parse(s.GroupId.ToString());
                        ViewMyGroup vd = new ViewMyGroup(id,groupid);
                        vd.Show();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
