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
    class ListToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            newCaspotatdb3Entities5 db = new newCaspotatdb3Entities5();
            ObservableCollection<Student> s = value as ObservableCollection<Student>;
            int? studentId = parameter as int?;
            if(studentId!=null&&s!=null)
            {
                Student st = db.Students.Single(r => r.StudentId == studentId);
                if (s.Contains(st))
                    return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
