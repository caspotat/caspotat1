﻿using System;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Good_Luck
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();
        public Students()
        {
            InitializeComponent();
            loadgrid();
        }

        private void loadgrid()
        {
            var data = from r in db.Students select r;
            dg1.ItemsSource = data.ToList();
        }
      
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var student_id = (dg1.SelectedItem as Student).StudentId;
            Student s = (from r in db.Students where r.StudentId == student_id select r).SingleOrDefault();
            db.Students.Remove(s);
            db.SaveChanges();
            dg1.ItemsSource = db.Students.ToList();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {          
            db.SaveChanges();
            dg1.ItemsSource = db.Students.ToList();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItem != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        Student s = (Student)dgr.Item;
                        int id = int.Parse(s.StudentId.ToString());
                        ViewStudentDetails vd = new ViewStudentDetails(id);
                        vd.Show();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void new_Click(object sender, RoutedEventArgs e)
        {
            newAndUpdateStudent n = new newAndUpdateStudent();
            n.Show();
        }
        int index = 0;
        private void dg1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }
    }
}
