using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using System.Xml;
using System.Net;
using System.Web;
using System.IO;
using Microsoft.VisualBasic;
using System.Collections;

namespace Good_Luck
{
    /// <summary>
    /// Interaction logic for ReadMails.xaml
    /// </summary>
    public partial class ReadMails : Window
    {
        string message_object;
        string message_author;
        string tagline;
        string message_summary;

        public ReadMails()
        {
            InitializeComponent();
        }
        public void GetAlleMails()
        {
            System.Net.WebClient objclient = new System.Net.WebClient();
            string response = null;
            XmlDocument xdoc = new XmlDocument();

            try
            {
                objclient.Credentials = new System.Net.NetworkCredential(textbox1.Text.Trim(), textbox2.Text.Trim());
                response = Encoding.UTF8.GetString(objclient.DownloadData("https://mail.google.com/mail/feed/atom"));
                response = response.Replace("<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\">", "<feed>");
                xdoc.LoadXml(response);
                if(Variables.mailcount>0)
                    {
                    foreach (XmlNode node1 in xdoc.SelectNodes("feed/entry"))
                        listbox1.Items.Add(node1.SelectSingleNode("title").InnerText);
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetFeed()
        {
            System.Net.WebClient objclient = new System.Net.WebClient();
            XmlNodeList nodelist = default(XmlNodeList);
            XmlNode node = default(XmlNode);
            XmlNode node2 = default(XmlNode);
            string response = null;
            XmlDocument xdoc = new XmlDocument();

            try
            {
          
                objclient.Credentials = new System.Net.NetworkCredential("m0548485140@gmail.com", "0548485140", "smtp.gmail.com");


                response = Encoding.UTF8.GetString(objclient.DownloadData("http://mail.google.com/mail/feed/atom"));
                response.Replace("<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\">", "<feed>");
                xdoc.LoadXml(response);
                node = xdoc.SelectSingleNode("/feed/fullcount");
                Variables.mailcount = Convert.ToInt16(node.InnerText);
                MessageBox.Show("currently we have " + Variables.mailcount + " emails");
                tagline = xdoc.SelectSingleNode("/feed/tagline").InnerText;
                MessageBox.Show("sir, you have " + tagline);
                if(Variables.mailcount>0)
                {
                    node2 = xdoc.SelectSingleNode("feed").SelectSingleNode("entry");
                    message_object = node2.SelectSingleNode("title").InnerText;
                    message_author = node2.SelectSingleNode("author").SelectSingleNode("name").InnerText;
                    message_summary = node2.SelectSingleNode("summary").InnerText;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //edlshtein@arachim.org

        }

       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetFeed();
        }

        private void GetAllMails(object sender, RoutedEventArgs e)
        {
            GetAlleMails();
        }
    }
}
