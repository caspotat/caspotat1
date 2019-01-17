using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for CalcRoute.xaml
    /// </summary>
    public partial class CalcRoute : Window
    {
        double x,x2,x3,x4,x5,x6;
        double y,y2,y3,y4,y5,y6;
        PointAddress pa = new PointAddress();
        PointAddress pa2 = new PointAddress();
        PointAddress pa3 = new PointAddress();
        PointAddress pa4 = new PointAddress();
        PointAddress pa5 = new PointAddress();
        PointAddress pa6 = new PointAddress();

        newCaspotatdb3Entities2 db = new newCaspotatdb3Entities2();
        public CalcRoute()
        {
  
            InitializeComponent();
            CreateRoutes();
        }
        private void CreateRoutes()
        {
            List<List<Adress>> routes = new List<List<Adress>>();
            List<Adress> temp = new List<Adress>();
            temp.AddRange(db.Adresses);
            //devide the addresses to routes.
            //each route has 6 addresses
            while (temp.Count / 6 > 0)
            {
                routes.Add(new List<Adress>());//create new route
                CreateRoute(temp, routes[routes.Count - 1], 6);//add addresses to the route
            }
            if (temp.Count > 0)//if there are still addresses
            {
                //put the address in the nearest route.
                foreach (Adress ad in temp)
                {
                    //עצם מסוג פוינט אדרס 
                    x = double.Parse(ad.X.ToString());
                    y = double.Parse(ad.Y.ToString());
                    pa.X = x;
                    pa.Y = y;
                    x2 = double.Parse(routes[0][0].X.ToString());
                    y2= double.Parse(routes[0][0].Y.ToString());
                
                    pa2.X = x2;
                    pa2.Y = y2;
                    double minDistance = Distance.distanceFromPoints(pa, pa2);
                    List<Adress> minRoute = routes[0];
                    foreach (List<Adress> route in routes)
                    {
                        x3 = double.Parse(route[0].X.ToString());
                        y3 = double.Parse(route[0].Y.ToString());
                     
                        pa3.X = x3;
                        pa3.Y = y3;
                        double distance = Distance.distanceFromPoints(pa, pa3);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            minRoute = route;
                        }
                    }
                    minRoute.Add(ad);
                }

            }

        }



        private void CreateRoute(List<Adress> adresses, List<Adress> route, int index)
        {
            if (index > 0)
            {
                if (route.Count==0)
                {
                    route.Add(adresses[0]);
                    adresses.RemoveAt(0);
                }
                else
                {
                    x4 = double.Parse(route[0].X.ToString());
                    y4 = double.Parse(route[0].Y.ToString());
                  
                    pa4.X = x4;
                    pa4.Y = y4;
                    x5 = double.Parse(adresses[0].X.ToString());
                    y5 = double.Parse(adresses[0].Y.ToString());
                 
                    pa5.X = x5;
                    pa5.Y = y5;
                    double distance = 0;
                    double minDistance = Distance.distanceFromPoints(pa4, pa5);
                    Adress minAdress = adresses[0];
                    foreach (Adress ad in adresses)
                    {
                        x6 = double.Parse(ad.X.ToString());
                        y6 = double.Parse(ad.Y.ToString());
                     
                        pa6.X = x6;
                        pa6.Y = y6;
                        distance = Distance.distanceFromPoints(pa4, pa6);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            minAdress = ad;
                        }
                    }
                    route.Add(minAdress);
                    adresses.Remove(minAdress);
                    CreateRoute(adresses, route, index - 1);
                }
            }
        }
    }
}

 
