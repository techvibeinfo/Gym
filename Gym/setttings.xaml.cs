using Gym.Class;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for setttings.xaml
    /// </summary>
    public partial class setttings : Window
    {
        readonly MySqlFunctions fun = new MySqlFunctions();
        public setttings()
        {
            InitializeComponent();
            UsrGrid();
            rdMale.IsChecked = true;
            if (rdMale.IsChecked == true)
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='male'");
                if (dt.Rows.Count > 0)
                {
                    txtMthFee.Text = dt.Rows[0]["monthlyFee8"] + "";
                    txtAddFee.Text = dt.Rows[0]["addmissionFee"] + "";
                }
            }
            else
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='female'");
                if (dt.Rows.Count > 0)
                {
                    txtMthFee.Text = dt.Rows[0]["monthlyFee8"] + "";
                    txtAddFee.Text = dt.Rows[0]["addmissionFee"] + "";
                }
            }
                tbuser.IsSelected = true;
        }


        private void btnAddUsr_Click(object sender, RoutedEventArgs e)
        {
            if (txtUName.Text != "" && txtUsrname.Text != "" && txtPass.Text != "")
            {
                fun.MySQLWork("INSERT INTO `login`(`Name`, `username`, `pwd`) VALUES('" + txtUName.Text + "','" + txtUsrname.Text + "','" + txtPass.Text + "')", "User Created");
                UsrGrid();
            }
        }
        private void UsrGrid()
        {
            dgdSettUsrs.DataContext = fun.MySQLSelectAda("SELECT `slno` AS 'No',`Name`, `username` AS 'UserName', `pwd` AS 'Password' FROM `login` ORDER BY `no` ASC");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (rdMale.IsChecked == true)
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='male'");
                if (dt.Rows.Count > 0)
                {
                    fun.MySQLWork("UPDATE `feestructure` SET `addmissionFee`='" + txtAddFee.Text + "',`monthlyFee8`='" + txtMthFee.Text + "' WHERE `gender`='male'", "Fee Structure Updated");
                }
                else
                {
                    fun.MySQLWork("INSERT INTO `feestructure`( `addmissionFee`, `monthlyFee8`,`gender`) VALUES('" + txtAddFee.Text + "','" + txtMthFee.Text + "','male')", "Fee Structure Created");

                }
            }
            else
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='female'");
                if (dt.Rows.Count > 0)
                {
                    fun.MySQLWork("UPDATE `feestructure` SET `addmissionFee`='" + txtAddFee.Text + "',`monthlyFee8`='" + txtMthFee.Text + "' WHERE `gender`='female'", "Fee Structure Updated");
                }
                else
                {
                    fun.MySQLWork("INSERT INTO `feestructure`( `addmissionFee`, `monthlyFee8`,`gender`) VALUES('" + txtAddFee.Text + "','" + txtMthFee.Text + "','female')", "Fee Structure Created");

                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rdMale_Checked(object sender, RoutedEventArgs e)
        {
            if (rdMale.IsChecked == true)
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='male'");
                if (dt.Rows.Count > 0)
                {
                    txtMthFee.Text = dt.Rows[0]["monthlyFee8"] + "";
                    txtAddFee.Text = dt.Rows[0]["addmissionFee"] + "";
                }
            }
            else
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='female'");
                if (dt.Rows.Count > 0)
                {
                    txtMthFee.Text = dt.Rows[0]["monthlyFee8"] + "";
                    txtAddFee.Text = dt.Rows[0]["addmissionFee"] + "";
                }
            }
        }

        private void rdFemale_Checked(object sender, RoutedEventArgs e)
        {
            if (rdFemale.IsChecked == true)
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='female'");
                if (dt.Rows.Count > 0)
                {
                    txtMthFee.Text = dt.Rows[0]["monthlyFee8"] + "";
                    txtAddFee.Text = dt.Rows[0]["addmissionFee"] + "";
                }
            }
            else
            {
                DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='male'");
                if (dt.Rows.Count > 0)
                {
                    txtMthFee.Text = dt.Rows[0]["monthlyFee8"] + "";
                    txtAddFee.Text = dt.Rows[0]["addmissionFee"] + "";
                }
            }
        }
    }
}
