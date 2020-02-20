using Gym.Class;
using MySql.Data.MySqlClient;
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
    /// Interaction logic for Custom.xaml
    /// </summary>
    public partial class Custom : Window
    {
        readonly MySqlFunctions fun = new MySqlFunctions();
        int no;
        string name;
        public Custom(int no,string name)
        {
            InitializeComponent();
            tb.Visibility = Visibility.Collapsed;
            tbExpCatgry.Visibility = Visibility.Collapsed;
            tbInc.Visibility = Visibility.Collapsed;
            tbIncrpt.Visibility = Visibility.Collapsed;
            tbPhysic.Visibility = Visibility.Collapsed;
            this.no = no;
            this.name = name;
            tbkAdNo.Text = no+"";
            tbkPName.Text = name;
            datePhydate.Text = DateTime.Now.ToString();
        }
        public Custom()
        {
            InitializeComponent();
            tb.Visibility = Visibility.Collapsed;
            tbExpCatgry.Visibility = Visibility.Collapsed;
            tbInc.Visibility = Visibility.Collapsed;
            tbIncrpt.Visibility = Visibility.Collapsed;
            tbPhysic.Visibility = Visibility.Collapsed;
            cmbCtgry.Items.Clear();
            expTypeLoad();
        }

        private void btnCtgryAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtCtgry.Text.Length != 0)
            {
                fun.MySQLWork("INSERT INTO `expnccategory`(`Type`) VALUES ('" + txtCtgry.Text + "')", "Added Successfully");
            }
            txtCtgry.Text = "";
            MainWindow mw = new MainWindow();
            mw.expTypeLoad();
        }

        private void btnCtgryShw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbCtgry.Text.Length != 0)
                {
                    dgdCstm.DataContext = null;
                    dgdCstm.DataContext = fun.MySQLSelectAda("SELECT `Id`, DATE_FORMAT(`Date`, '%d/%m/%Y'),`Amount`,`Description` FROM `expenses` WHERE `Type` ='" + cmbCtgry.Text + "'");

                    DataGridColumn c0 = dgdCstm.Columns[0];
                    DataGridColumn c1 = dgdCstm.Columns[1];

                    c0.Visibility = Visibility.Collapsed;
                    c1.Header = "Date";
                    c1.MaxWidth = 120;

                    tbkExpTotal.Text = fun.MySQLString("SELECT  COALESCE(SUM(`Amount`),0) FROM `expenses` WHERE `Type` ='" + cmbCtgry.Text + "'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": Error");
            }
        }
        public void expTypeLoad()
        {
            MySqlDataReader rs = fun.MySQLSelect("SELECT DISTINCT `Type` FROM `expnccategory`;");
            while (rs.Read())
            {
                cmbCtgry.Items.Add(rs.GetString("Type"));
            }

            MySqlDataReader rs1 = fun.MySQLSelect("SELECT DISTINCT `Type` FROM `incomecategory`;");
            while (rs1.Read())
            {
                cmbIncCtgry.Items.Add(rs1.GetString("Type"));
            }
        }

        private void btnCtgryShwDt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtpExpncdteFrm.Text.Length != 0 && dtpExpncdteTo.Text.Length != 0)
                {
                    String DateFrm = dtpExpncdteFrm.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    String DateTo = dtpExpncdteTo.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    dgdCstm.DataContext = null;
                    dgdCstm.DataContext = fun.MySQLSelectAda("SELECT `Id`, DATE_FORMAT(`Date`, '%d/%m/%Y'),`Amount`,`Type`,`Description` FROM `expenses` WHERE  `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'AND `Type` ='" + cmbCtgry.Text + "'");

                    DataGridColumn c0 = dgdCstm.Columns[0];
                    DataGridColumn c1 = dgdCstm.Columns[1];

                    c0.Visibility = Visibility.Collapsed;
                    c1.Header = "Date";
                    c1.MaxWidth = 120;

                    tbkExpTotal.Text = fun.MySQLString("SELECT  COALESCE(SUM(`Amount`),0) FROM `expenses` WHERE `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'AND `Type` ='" + cmbCtgry.Text + "';");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": Error");
            }
        }

        private void btnIncCtgryAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtIncCtgry.Text.Length != 0)
            {
                fun.MySQLWork("INSERT INTO `incomecategory`(`Type`) VALUES ('" + txtIncCtgry.Text + "')", "Added Successfully");
            }
            txtIncCtgry.Text = "";
            MainWindow mw = new MainWindow();
            mw.incTypeLoad();
        }

        private void btnIncCtgryShwDt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtpIncdteFrm.Text.Length != 0 && dtpIncdteTo.Text.Length != 0)
                {
                    String DateFrm = dtpIncdteFrm.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    String DateTo = dtpIncdteTo.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    dgdIncCstm.DataContext = null;
                    dgdIncCstm.DataContext = fun.MySQLSelectAda("SELECT `Id`, DATE_FORMAT(`Date`, '%d/%m/%Y'),`Amount`,`Type`,`Description` FROM `income` WHERE  `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'AND `Type` ='" + cmbIncCtgry.Text + "'");

                    DataGridColumn c0 = dgdIncCstm.Columns[0];
                    DataGridColumn c1 = dgdIncCstm.Columns[1];

                    c0.Visibility = Visibility.Collapsed;
                    c1.Header = "Date";
                    c1.MaxWidth = 120;

                    tbkIncTotal.Text = fun.MySQLString("SELECT  COALESCE(SUM(`Amount`),0) FROM `income` WHERE `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'AND `Type` ='" + cmbIncCtgry.Text + "';");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": Error");
            }
        }

        private void btnPSave_Click(object sender, RoutedEventArgs e)
        {
                String recdate = datePhydate.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            if (datePhydate.Text.Length!=0 && txtHeight.Text.Length != 0||txtWeight.Text.Length != 0||txtAbs.Text.Length != 0|| txtChest.Text.Length != 0||txtBiceps.Text.Length!=0 || txtHamstring.Text.Length != 0 || txtGludes.Text.Length != 0)
            {
                fun.MySQLWork("INSERT INTO `physic`( `AdmissionNo`, `Name`, `Height`, `Weight`, `Chest`, `Abs`,`Hamstring`, `Biceps`, `Gludes`,`date`) VALUES (" + tbkAdNo.Text+",'"+tbkPName.Text+"',"+txtHeight.Text+","+txtWeight.Text+","+txtChest.Text+","+txtAbs.Text+","+txtHamstring.Text+","+txtBiceps.Text+","+txtGludes.Text+",'"+ recdate + "')", "Added Successfully");
            }
            txtHeight.Text = "";
            txtWeight.Text = "";
            txtAbs.Text = "";
            txtChest.Text = "";
            txtGludes.Text = "";
            txtBiceps.Text = "";
            txtHamstring.Text = "";
            
        }

        private void BtnPCancel_Click(object sender, RoutedEventArgs e)
        {
            txtHeight.Text = "";
            txtWeight.Text = "";
            txtAbs.Text = "";
            txtChest.Text = "";
            txtGludes.Text = "";
            txtBiceps.Text = "";
            txtHamstring.Text = "";
        }
    }
}
