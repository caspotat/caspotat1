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
    /// Interaction logic for ViewRoute.xaml
    /// </summary>
    public partial class ViewRoute : Window
    {
        newCaspotatdb3Entities3 db = new newCaspotatdb3Entities3();

        public ViewRoute()
        {
            InitializeComponent();
        }
        public ViewRoute(int group)
        {
            InitializeComponent();
            labelofgroup.Content = "המסלול של קבוצה מס  " + group;
            string str = "";
            Adress a = new Adress();
            foreach (Donor d in db.Donors)
            {

                if (d.GroupId==group)
                {
                    a = db.Adresses.FirstOrDefault(u => u.AdressId == d.AdressId);
                    str = a.Street + " " + a.NumBuilding + " ," + a.City;
                    adresses.Items.Add(str);
                }
            }
        }
    }
}
