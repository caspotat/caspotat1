using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Good_Luck.Converters
{
    class ListToBoolConverter : IMultiValueConverter
    {
       

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            newCaspotatdb3Entities2 db = new newCaspotatdb3Entities2();
            ObservableCollection<Student> s = values[0] as ObservableCollection<Student>;
            int studentId;
            Student stu = values[2] as Student;
            //int.TryParse(values[2].ToString(),out studentId);

            if (stu!=null&&s != null)
            {
               // Student st = db.Students.Single(r => r.StudentId == studentId);
                if (s.Contains(stu))
                    return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
