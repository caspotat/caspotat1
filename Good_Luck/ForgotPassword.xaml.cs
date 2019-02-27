using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using System.Drawing;

namespace Good_Luck
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {    
        public ForgotPassword()
        {
            InitializeComponent();
        }


        public void SendEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("r7102079@gmail.com");
            mail.To.Add(txtEmail.Text.Trim());
            mail.Subject = "שחזור סיסמת מערכת";
            mail.Body = "1234";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("caspotat@gmail.com", "m0548485140");
            //SmtpServer.Credentials = cr;
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            MessageBox.Show("mail Send");
            this.Close();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SendEmail();
        }
    }
}
