using DevExpress.Xpf.Charts;
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
    /// Interaction logic for physic.xaml
    /// </summary>
    public partial class physic : Window
    {
        readonly MySqlFunctions fun = new MySqlFunctions();
        int no;
        string name;
        public physic(int no,string name)
        {
            InitializeComponent();
            this.no = no;
            this.name = name;
            tbkAdNo.Text = no+"";
            tbkName.Text = name;
            tbAbs.Visibility = Visibility.Collapsed;
            tbBiceps.Visibility = Visibility.Collapsed;
            tbChest.Visibility = Visibility.Collapsed;
            tbGludes.Visibility = Visibility.Collapsed;
            tbHamstring.Visibility = Visibility.Collapsed;
            tbHeight.Visibility = Visibility.Collapsed;
            tbWeight.Visibility = Visibility.Collapsed;
            tbWeight.IsSelected = true;
            chart();
        }
        public void chart()
        {
            try
            {
                DataTable dt = fun.MySQLSelectAda("SELECT  `Height`, `Weight`, `Chest`, `Abs`,`Hamstring`, `Biceps`, `Gludes`, DATE_FORMAT(date,'%d/%m/%Y')AS date FROM `physic` WHERE `AdmissionNo`=" + tbkAdNo.Text + ";");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        chartWeight.Diagram.Series[0].Points.Add(new SeriesPoint(dr["date"] + "", Convert.ToInt16(dr["Weight"])));
                        chartHeight.Diagram.Series[0].Points.Add(new SeriesPoint(dr["date"] + "", Convert.ToInt16(dr["Height"])));
                        chartChest.Diagram.Series[0].Points.Add(new SeriesPoint(dr["date"] + "", Convert.ToInt16(dr["Chest"])));
                        chartAbs.Diagram.Series[0].Points.Add(new SeriesPoint(dr["date"] + "", Convert.ToInt16(dr["Abs"])));
                        chartHamstring.Diagram.Series[0].Points.Add(new SeriesPoint(dr["date"] + "", Convert.ToInt16(dr["Hamstring"])));
                        chartBiceps.Diagram.Series[0].Points.Add(new SeriesPoint(dr["date"] + "", Convert.ToInt16(dr["Biceps"])));
                        chartGludes.Diagram.Series[0].Points.Add(new SeriesPoint(dr["date"] + "", Convert.ToInt16(dr["Gludes"])));
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void grdWeight_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbWeight.IsSelected = true;
            chart();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Custom cst = new Custom(Convert.ToInt16(tbkAdNo.Text), tbkName.Text);
            cst.tbPhysic.IsSelected = true;
            cst.Title = "Update";
            cst.txtHeight.Focus();
            cst.ShowDialog();
            chart();
        }

        private void grdHeight_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbHeight.IsSelected = true;
        }

        private void grdChest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbChest.IsSelected = true;
        }

        private void grdAbs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbAbs.IsSelected = true;
        }

        private void grdHamstring_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbHamstring.IsSelected = true;
        }

        private void grdBiceps_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbBiceps.IsSelected = true;
        }

        private void grdGludes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbGludes.IsSelected = true;
        }
    }
}
