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
    public partial class Login : Window
    {
        static int misClick = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void pass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            if (pass.Text == "")
                MessageBox.Show("נא להכניס סיסמא");
            else
            {
                if (pass.Text.ToString().Equals("1234"))
                {
                    m.Show();
                    this.Close();
                }
                else
                {
                    if (misClick < 3)
                    {
                        MessageBox.Show("סיסמא שגויה, הקש שנית");
                        pass.Text = "";
                        misClick++;
                    }
                    else
                    {
                        MessageBox.Show("אינך רשאי להכנס למערכת, תודה ולהתראות");
                        this.Close();
                    }
                }
            }
        }
        
        
        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            f.Show();
            
        }
    }
}
