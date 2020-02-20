using Gym.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gym
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        readonly MySqlFunctions fun = new MySqlFunctions();
        public login()
        {
            InitializeComponent();
            txtUsr.Focus();
        }

        private void LogN()
        {
            String User = fun.MySQLString("SELECT `username` FROM  `login` WHERE `username`='" + txtUsr.Text + "';");
            String UPass = fun.MySQLString("SELECT `pwd` FROM  `login` WHERE `pwd`='" + pwdPass.Password + "';");

            if (txtUsr.Text == User && pwdPass.Password == UPass)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
                txtErr.Text = "Invalid login";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LogN();
        }

        private void txtUsr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                pwdPass.Focus();
        }
        private void pwdPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                LogN();
        }

     
    }
}
