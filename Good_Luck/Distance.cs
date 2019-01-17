using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Good_Luck
{
    public class Distance
    {
        public static PointAddress PointFromAddress(string city, string street, int? number)
        {
            PointAddress p = new PointAddress();
            //try
            {
                string num = number.ToString();
                var address = city + " " + street + " " + num;
                //var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDLO0nK1YvUnBAC_4xI5QJeIXJOQpADlMk&address=={0}Dallas&sensor=true", Uri.EscapeDataString(address));
                var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false" + "&key=" + "AIzaSyDuZZg8oQp6liOE-dBQDb1S9XolPRk7A50", Uri.EscapeDataString(address));
                var request = System.Net.WebRequest.Create(requestUri);
                var response = request.GetResponse();
                var xdoc = System.Xml.Linq.XDocument.Load(response.GetResponseStream());
                //var xdoc = System.Xml.Linq.XDocument.Load(response.GetResponseStream());
                var result = xdoc.Element("GeocodeResponse").Element("result");
                var locationElement = result.Element("geometry").Element("location");
                var lat = locationElement.Element("lat");
                var lng = locationElement.Element("lng");
                p.X = (double)lat;
                p.Y = (double)lng;
                return p;
            }

            //catch (Exception)
            //{
            //    string num = number.ToString();
            //    var address = " חברון 12 בני ברק";
            //    var requestUri =
            //    string.Format(" http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sens or = false ", Uri.EscapeDataString(address));
            //    var request = System.Net.WebRequest.Create(requestUri);
            //    var response = request.GetResponse();
            //    var xdoc =
            //    System.Xml.Linq.XDocument.Load(response.GetResponseStream());
            //    var result = xdoc.Element("GeocodeResponse").Element("result");
            //    var locationElement = result.Element("geometry").Element("location");
            //    var lat = locationElement.Element("lat");
            //    var lng = locationElement.Element("lng");
            //    p.X = (Double)lat;
            //    p.Y = (Double)lng;
            //    return p;
            //}

        }
        public static double distanceFromPoints(PointAddress p1, PointAddress p2)
        {
            double x1, x2, y1, y2;
            x1 = (Double)p1.X;
            x2 = (Double)p2.X;
            y1 = (Double)p1.Y;
            y2 = (Double)p2.Y;
            var temp1 = Math.Pow((x1 - x2), 2);
            var temp2 = Math.Pow((y1 - y2), 2);
            var result = Math.Sqrt(temp1 + temp2);
            return result;

        }
    }
}



