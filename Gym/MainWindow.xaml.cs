using DevExpress.Xpf.Charts;
using Gym.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MySqlFunctions fun = new MySqlFunctions();
        System.Drawing.Printing.PrinterSettings PrintSett = new System.Drawing.Printing.PrinterSettings();
        public MainWindow()
        {
            InitializeComponent();
            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(Utilities.MyHandler);
            tbHome.Visibility = Visibility.Collapsed;
            tbNew.Visibility = Visibility.Collapsed;
            tbFee.Visibility = Visibility.Collapsed;
            tbView.Visibility = Visibility.Collapsed;
            tbLstView.Visibility = Visibility.Collapsed;
            tbExpnc.Visibility = Visibility.Collapsed;
            tbRpt.Visibility = Visibility.Collapsed;
            tbFeeRpt.Visibility = Visibility.Collapsed;
            tbBnk.Visibility = Visibility.Collapsed;
            lstHmSrch.Visibility = Visibility.Collapsed;
            tbIncome.Visibility = Visibility.Collapsed;
            loadHome();
            LoadDateTime();
            tbHome.IsSelected = true;
        }

        private void LoadDateTime()
        {
            DispatcherTimer DTimer = new DispatcherTimer();
            tbkStsDate.Text = DateTime.Now.ToShortDateString() + "   ";
            DTimer.Tick += new EventHandler(Tick);
            DTimer.Interval = new TimeSpan(0, 0, 0, 0);
            DTimer.Start();
        }


        private void DigitOnly(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Char c = Convert.ToChar(e.Text);
                if (Char.IsNumber(c))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch { e.Handled = true; }
        }
        private void DigitOnlyDot(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Char c = Convert.ToChar(e.Text);
                if (Char.IsNumber(c) || Char.Equals(c, '.'))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch { e.Handled = true; }
        }
        private void DigitWithComma(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Char c = Convert.ToChar(e.Text);
                if (Char.IsNumber(c) || Char.Equals(c, ','))
                    e.Handled = false;
                else
                    e.Handled = true;

            }
            catch { e.Handled = true; }
        }
        private void NoSpace(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void Tick(object sender, EventArgs e)
        {
            tbkStsTime.Text = DateTime.Now.ToLongTimeString();
        }

        //load Home page grids
        private void loadHome()
        {
            try
            {
                tbkHmNwAdCnt.Text = fun.MySQLString("SELECT count(*) FROM  `newaddmission`WHERE  MONTH(JoingDate) = MONTH(CURDATE()) AND YEAR(JoingDate) = YEAR(CURDATE());");
                tbkHmFPCnt.Text = fun.MySQLString("SELECT count(*) FROM  `fees`WHERE  MONTH(BillDate) = MONTH(CURDATE()) AND YEAR(BillDate) = YEAR(CURDATE()) AND !(`AdmissionNo`=0) AND `Balance`=0;");
                tbkHmNwAdMth.Text = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);

                int a = Convert.ToInt32(fun.MySQLString("SELECT COALESCE(SUM(`AdmFee`),0) FROM  `newaddmission`WHERE  DATE(JoingDate) = DATE(CURDATE());"));
                int b = Convert.ToInt32(fun.MySQLString("SELECT COALESCE(SUM(`AmountPaid`),0) FROM  `fees`WHERE  DATE(BillDate) = DATE(CURDATE());"));
                int sum = a + b;
                tbkHmIncom.Text = sum + "";

                tbkHmExp.Text = fun.MySQLString("SELECT COALESCE(SUM(`Amount`),0)Amount FROM `expenses`WHERE  DATE(Date) = DATE(CURDATE());");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void bdrHom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbHome.IsSelected = true;
            loadHome();
        }
        private void grdNew_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbkNAdm.Text = fun.MySQLString("SELECT COALESCE(MAX(AdmissionNo),1000)+1 FROM  `newaddmission`;");
            btnNCan_Click(sender, null);
            tbNew.IsSelected = true;
            DataTable dt = fun.MySQLSelectAda("SELECT * FROM feestructure");
            if (dt.Rows.Count > 0)
            {
                txtNAdmFee.Text = dt.Rows[0]["addmissionFee"] + "";
            }
        }
        private void grdFee_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btnFeeCan_Click(sender, null);
            tbFee.IsSelected = true;
        }
        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            if (imgCptr.Source != null)
                imgCptr.Source = null;
            Capture c = new Capture();
            c.Show();
        }

        private void txtNewSav_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (imgCptr.Source != null)
                {
                    if (System.IO.File.Exists(@"Images/" + tbkNAdm.Text + ".jpg"))
                        System.IO.File.Delete(@"Images/" + tbkNAdm.Text + ".jpg");

                    var encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgCptr.Source));
                    using (System.IO.FileStream stream = new System.IO.FileStream(@"Images/" + tbkNAdm.Text + ".jpg", System.IO.FileMode.Create))
                        encoder.Save(stream);
                }
                // Database Insertion
                String Gender = (rdNGndrM.IsChecked == true) ? "Male" : "Female";
                String Time = (rdNTimM.IsChecked == true) ? "Morning" : "Evening";
                String Date = dtpAdmDate.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                if (txtNName.Text.Length != 0 && txtNAddr.Text.Length != 0 && txtNAge.Text.Length != 0 && txtNMob.Text.Length != 0 &&  dtpAdmDate.Text.Length != 0)
                {
                    String AdmNo = fun.MySQLString("SELECT `AdmissionNo` FROM  `newaddmission` WHERE `AdmissionNo`='" + tbkNAdm.Text + "';");
                    if (AdmNo != null)
                        fun.MySQLWork("UPDATE `newaddmission` SET `AdmissionNo`='" + tbkNAdm.Text + "',`Name`='" + txtNName.Text + "',`Address`='" + txtNAddr.Text + "',`Gender`='" + Gender + "',`Age`='" + txtNAge.Text + "',`Mob`='91" + txtNMob.Text + "',`Job`='" + txtNJob.Text + "',`BloodGroup`='" + cmbNBlood.Text + "',`Sugar`='" + txtNSgr.Text + "',`Pressure`='" + txtNBP.Text + "',`Cholesterol`='" + txtNCol.Text + "',`OtherDiseases`='" + ((bool)chkNDis.IsChecked ? "1" : "0") + "',`MatrialArts`='" + ((bool)chkNMrtlArts.IsChecked ? "1" : "0") + "',`Development`='" + cmbNDvlpmnt.Text + "',`Time`='" + Time + "',`JoingDate`='" + Date + "',`AdmFee`='" + txtNAdmFee.Text + "',`Notes`='"+txtNNote.Text+"' WHERE AdmissionNo='" + tbkNAdm.Text + "'", "Data Updated Successfully");
                    else
                    {
                        fun.MySQLWork("INSERT INTO `newaddmission`(`AdmissionNo`, `Name`, `Address`, `Gender`, `Age`, `Mob`, `Job`, `BloodGroup`, `Sugar`, `Pressure`, `Cholesterol`, `OtherDiseases`, `MatrialArts`, `Development`, `Time`, `JoingDate`, `AdmFee`,`Notes`) VALUES ('" + tbkNAdm.Text + "','" + txtNName.Text + "','" + txtNAddr.Text + "','" + Gender + "','" + txtNAge.Text + "','91" + txtNMob.Text + "','" + txtNJob.Text + "','" + cmbNBlood.Text + "','" + txtNSgr.Text + "','" + txtNBP.Text + "','" + txtNCol.Text + "','" + ((bool)chkNDis.IsChecked ? "1" : "0") + "','" + ((bool)chkNMrtlArts.IsChecked ? "1" : "0") + "','" + cmbNDvlpmnt.Text + "','" + Time + "','" + Date + "','" + txtNAdmFee.Text + "','"+txtNNote.Text+"')", "Data added Successfully");
                        //fun.MySQLWork("INSERT INTO `feerpt`(`AdmNo`) VALUES ('" + tbkNAdm.Text + "')", null);
                        grdNew_MouseLeftButtonUp(sender, null);
                        NewAdmClear();
                        physic ph = new physic(Convert.ToInt16(tbkNAdm.Text), txtNName.Text);
                        ph.ShowDialog();
                    }
                    grdNew_MouseLeftButtonUp(sender, null);
                    NewAdmClear();
                }
                else
                    MessageBox.Show("Please fill Mandatory fields", "Alert");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "Unable to insert", "Error"); }
        }

        private void NewAdmClear()
        {
            dtpAdmDate.Text = DateTime.Now.ToShortDateString();
            txtNName.Text = "";
            txtNAddr.Text = "";
            rdNGndrM.IsChecked = true;
            txtNAge.Text = "";
            txtNMob.Text = "";
            txtNJob.Text = "";
            cmbNBlood.Text = "";
            txtNSgr.Text = "";
            txtNBP.Text = "";
            txtNCol.Text = "";
            chkNDis.IsChecked = false;
            txtNHgt.Text = "";
            txtNWgt.Text = "";
            txtNChst.Text = "";
            txtNAbs.Text = "";

            txtNHgt.Text = "";
            txtNWgt.Text = "";
            txtNChst.Text = "";
            txtNAbs.Text = "";
            cmbNDvlpmnt.Text = "";
            txtNNote.Text = "";
            chkNMrtlArts.IsChecked = false;
            rdNTimM.IsChecked = true;
            imgCptr.Source = null;

        }
        private void btnNCan_Click(object sender, RoutedEventArgs e)
        {
            NewAdmClear();
            tbHome.IsSelected = true;
        }

        private void grdView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbLstView.IsSelected = true;
        }

        //Fee
        private void txtFeeSrch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstFeeSrch.Items.Clear();
            int n;
            bool isNumeric = int.TryParse(txtFeeSrch.Text, out n);
            //search by id
            DataTable dt = null;
            if (isNumeric == true)
                dt = fun.MySQLSelectAda("SELECT `AdmissionNo`,`Name` FROM `newaddmission` WHERE `AdmissionNo` like '" + txtFeeSrch.Text + "%';");
            else
                dt = fun.MySQLSelectAda("SELECT `AdmissionNo`,`Name` FROM `newaddmission` WHERE `Name` like '" + txtFeeSrch.Text + "%';");
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstFeeSrch.SelectedIndex = 0;
                    lstFeeSrch.Visibility = Visibility.Visible;
                    String NameList =dr["AdmissionNo"] + " " + dr["Name"];
                    lstFeeSrch.Items.Add(NameList);
                    if (txtFeeSrch.Text.Length == 0)
                        lstFeeSrch.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void txtFeeSrch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                lstFeeSrch.Focus();
                lstFeeSrch.SelectedIndex = 0;
            }
            if (e.Key == Key.Enter)
                if (lstFeeSrch.SelectedItem != null || txtFeeSrch.Text.Length != 0)
                    btnFeeSrch_Click(sender, e);
        }
        private void lstFeeSrch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lstFeeSrch.SelectedItem != null)
            {
                txtFeeSrch.Text = lstFeeSrch.SelectedItem.ToString();
                btnFeeSrch_Click(sender, e);
            }
            lstFeeSrch.Visibility = Visibility.Collapsed;
        }
        private void lstFeeSrch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (lstFeeSrch.SelectedItem != null)
                {
                    txtFeeSrch.Text = lstFeeSrch.SelectedItem.ToString();
                    btnFeeSrch_Click(sender, e);
                }
            if (e.Key == Key.Up && lstFeeSrch.SelectedIndex == 0)
            {
                txtFeeSrch.Focus();
                lstFeeSrch.Items.Refresh();
            }
        }
        private void cmbBilMnth_DropDownClosed(object sender, EventArgs e)
        {
            int mnthFee = 0;
            if (cmbBilMnth.Text.Length != 0&&cmbYr.Text.Length!=0)
            {
                int PaidAmnt = Convert.ToInt16(fun.MySQLString("SELECT COALESCE(SUM(`AmountPaid`),0) FROM `fees` WHERE `AdmissionNo`= '" + tbkFeeAdNo.Text + "' AND `BillMonth`='"+cmbBilMnth.Text+ "'AND `year`='"+cmbYr.Text+"'"));
                tbkFeePaid.Text = PaidAmnt.ToString();

                DataTable dt = fun.MySQLSelectAda("SELECT DISTINCT `feeToPay` FROM `fees` WHERE `AdmissionNo`= '" + tbkFeeAdNo.Text + "' AND `BillMonth`='" + cmbBilMnth.Text + "'AND `year`='" + cmbYr.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    mnthFee = Convert.ToInt16(dt.Rows[0][0] + "");
                }
                else
                {
                    if(tbkgndr.Text=="Male")
                    {
                        DataTable dt1 = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='male'");
                        if (dt1.Rows.Count > 0)
                        {
                            mnthFee = Convert.ToInt16(dt1.Rows[0]["monthlyFee8"] + "");
                        }
                    }
                    else
                    {
                        DataTable dt1 = fun.MySQLSelectAda("SELECT * FROM feestructure WHERE `gender`='female'");
                        if (dt1.Rows.Count > 0)
                        {
                            mnthFee = Convert.ToInt16(dt1.Rows[0]["monthlyFee8"] + "");
                        }
                    }
                   
                }

                
                tbkFee2Pay.Text = (mnthFee - PaidAmnt).ToString();
                if (mnthFee - PaidAmnt == 0)
                {
                    txtFeePayNw.IsEnabled = false;
                    MessageBox.Show("Fee already paid for " + cmbBilMnth.Text);
                }
            }
        }

        public int monthNum(int num)
        {
            if (num == 0)
                return 12;
            else if (num == -1)
                return 11;
            else if (num == -2)
                return 10;
            else return num;
        }
        private void btnFeeSrch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int AddmfM =  Convert.ToInt16(fun.MySQLString("SELECT DISTINCT`addmissionFee` FROM  `feestructure` WHERE `gender`='male' ;"));
                int AddmfF = Convert.ToInt16(fun.MySQLString("SELECT DISTINCT`addmissionFee` FROM  `feestructure` WHERE `gender`='female' ;"));
                btnFeeCan_Click(sender, e);

               
                txtFeePayNw.IsEnabled = true;
                String AdmNo = fun.MySQLString("SELECT `AdmissionNo` FROM  `newaddmission` WHERE `AdmissionNo`='" + txtFeeSrch.Text + "' or `Name`='" + txtFeeSrch.Text + "';");

                cmbBilMnth.Items.Clear();
                cmbMonth(cmbBilMnth);


                DataTable dt = fun.MySQLSelectAda("SELECT `AdmissionNo`, `Name`,`Address`,`Mob`,`AdmFee`,`Gender` FROM `newaddmission` WHERE `AdmissionNo`='" + txtFeeSrch.Text + "' or `Name`='" + txtFeeSrch.Text + "';");
                if (AdmNo != null)
                {
                    Int16 AdmFee = Convert.ToInt16(dt.Rows[0]["AdmFee"] + "");
                    if (AdmFee == AddmfM || AdmFee == AddmfF)
                    {

                        tbkgndr.Text = dt.Rows[0]["Gender"] + "";
                        if (dt.Rows[0]["Gender"] + ""=="Male")
                        {
                            tbkFeeNTot.Text = fun.MySQLString("SELECT DISTINCT`monthlyFee8` FROM  `feestructure` WHERE `gender`='male';");
                        }
                        else
                        {
                            tbkFeeNTot.Text = fun.MySQLString("SELECT DISTINCT`monthlyFee8` FROM  `feestructure` WHERE `gender`='female' ;");
                        }
                        cmbYr.SelectedIndex = 1;
                        tbkFeeAdNo.Text = dt.Rows[0]["AdmissionNo"] + "";
                        tbkFeeName.Text = dt.Rows[0]["Name"] + "";
                        tbkFeeAddr.Text = dt.Rows[0]["Address"] + "";
                        tbkFeeMob.Text = dt.Rows[0]["Mob"] + "";

                        DataTable dtBill = fun.MySQLSelectAda("SELECT `BillNo`,DATE_FORMAT(BillDate,'%d/%m/%y'),`BillMonth`,`AmountPaid` FROM `fees` WHERE `AdmissionNo`=" + tbkFeeAdNo.Text + "");
                        lstNFeeList.Items.Clear();
                        if (dtBill.Rows.Count != 0)
                        {
                            foreach (DataRow dr in dtBill.Rows)
                            {
                                String FeeList = "   " + dr["BillNo"] + "            " + dr["DATE_FORMAT(BillDate,'%d/%m/%y')"] + "                      " + dr["AmountPaid"] + "                            " + dr["BillMonth"];
                                lstNFeeList.Items.Add(FeeList);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Sorry Admission fee not completed");
                }
            }
            catch (Exception) { }
            lstFeeSrch.Visibility = Visibility.Collapsed;
            txtFeeSrch.Text = "";
        }
        private String FeeMonthName(int MonthNo)
        {
            String FeeClmn = "";
            if (dtpBillDate.Text.Length != 0)

                if (MonthNo == 01)
                    FeeClmn = "January";
                else if (MonthNo == 02)
                    FeeClmn = "February";
                else if (MonthNo == 03)
                    FeeClmn = "March";
                else if (MonthNo == 04)
                    FeeClmn = "April";
                else if (MonthNo == 05)
                    FeeClmn = "May";
                else if (MonthNo == 06)
                    FeeClmn = "June";
                else if (MonthNo == 07)
                    FeeClmn = "July";
                else if (MonthNo == 08)
                    FeeClmn = "Auguest";
                else if (MonthNo == 09)
                    FeeClmn = "September";
                else if (MonthNo == 10)
                    FeeClmn = "October";
                else if (MonthNo == 11)
                    FeeClmn = "November";
                else if (MonthNo == 12)
                    FeeClmn = "December";
            return FeeClmn;
        }
        private String FeeMonthClm(String FeeMonth)
        {
            String FeeClmn = "";
            if (cmbBilMnth.Text.Length != 0)
            {
                if (FeeMonth == "January")
                    FeeClmn = "Jan";
                else if (FeeMonth == "February")
                    FeeClmn = "Feb";
                else if (FeeMonth == "March")
                    FeeClmn = "Mar";
                else if (FeeMonth == "April")
                    FeeClmn = "Apr";
                else if (FeeMonth == "May")
                    FeeClmn = "May";
                else if (FeeMonth == "June")
                    FeeClmn = "Jun";
                else if (FeeMonth == "July")
                    FeeClmn = "Jul";
                else if (FeeMonth == "Auguest")
                    FeeClmn = "Aug";
                else if (FeeMonth == "September")
                    FeeClmn = "Sep";
                else if (FeeMonth == "October")
                    FeeClmn = "Oct";
                else if (FeeMonth == "November")
                    FeeClmn = "Nov";
                else if (FeeMonth == "December")
                    FeeClmn = "Decm";
            }
            return FeeClmn;
        }
        private void cmbMonth(ComboBox cmb)
        {
            cmb.Items.Add("January");
            cmb.Items.Add("February");
            cmb.Items.Add("March");
            cmb.Items.Add("April");
            cmb.Items.Add("May");
            cmb.Items.Add("June");
            cmb.Items.Add("July");
            cmb.Items.Add("Auguest");
            cmb.Items.Add("September");
            cmb.Items.Add("October");
            cmb.Items.Add("November");
            cmb.Items.Add("December");
        }


        private void btnFeeCan_Click(object sender, RoutedEventArgs e)
        {
            dtpBillDate.Text = DateTime.Now.ToShortDateString();
            tbkBillNo.Text = fun.MySQLString("SELECT COALESCE(MAX(BillNo),99)+1 FROM  `fees`;");
            tbkFeeAdNo.Text = "";
            tbkFeeName.Text = "";
            tbkFeeAddr.Text = "";
            tbkFeeMob.Text = "";
            tbkFeeNTot.Text = "000";
            tbkFeePaid.Text = "000";
            tbkFee2Pay.Text = "000";
            txtFeePayNw.Text = "";
            lstNFeeList.Items.Clear();
            cmbBilMnth.Items.Clear();
        }

        private void btnFeeSbmt_Click(object sender, RoutedEventArgs e)
        {
            if (tbkBillNo.Text.Length != 0 && tbkFeeAdNo.Text.Length != 0 && tbkFeeName.Text.Length != 0 && tbkFeeNTot.Text.Length != 0 && txtFeePayNw.Text.Length != 0 && cmbBilMnth.Text.Length != 0)
            {
                if (tbkBillNo.Text != null)
                {
                    Int32 Fee = Convert.ToInt32(txtFeePayNw.Text);
                    Int32 Fee2Pay = Convert.ToInt32(tbkFee2Pay.Text);

                    int feeTotal = 0;
                    if (tbkgndr.Text == "Male")
                    {
                        feeTotal = Convert.ToInt16(fun.MySQLString("SELECT DISTINCT`monthlyFee8` FROM  `feestructure` WHERE `gender`='male';"));
                    }
                    else
                    {
                        feeTotal = Convert.ToInt16(fun.MySQLString("SELECT DISTINCT`monthlyFee8` FROM  `feestructure` WHERE `gender`='female' ;"));
                    }
                    if (Fee <= Fee2Pay)
                    {
                        Double FeeBlnc = Convert.ToInt32(tbkFeeNTot.Text) - (Convert.ToInt32(tbkFeePaid.Text) + Fee);
                        String BillDate = dtpBillDate.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                        fun.MySQLWork("INSERT INTO `fees`(`BillNo`,`BillDate`,`BillMonth`,`AdmissionNo`, `Name`, `AmountPaid`, `Balance`,`year`,`feeToPay`) VALUES (" + tbkBillNo.Text + ",'" + BillDate + "','" + cmbBilMnth.Text + "','" + tbkFeeAdNo.Text + "','" + tbkFeeName.Text + "'," + Fee + "," + FeeBlnc + ",'"+cmbYr.Text+"','"+ feeTotal + "')", "Fees Paid Successfully....!");
                       // System.Threading.Thread.Sleep(200);
                        //MySqlDataReader rs1 = fun.MySQLSelect("SELECT SUM(AmountPaid) FROM `fees` WHERE `AdmissionNo`= " + tbkFeeAdNo.Text + "  AND BillMonth = '" + cmbBilMnth.Text + "'");
                        //if (rs1.Read())
                        //{
                        //    int PaidAmnt = (rs1.IsDBNull(0)) ? 0 : rs1.GetInt32(0);
                        //    fun.MySQLWork("UPDATE `feerpt` SET `" + FeeMonthClm(cmbBilMnth.Text) + "`='" + PaidAmnt + "' WHERE AdmNo=" + tbkFeeAdNo.Text + "", "Fees Paid Successfully....!");
                        //}
                        grdFee_MouseLeftButtonUp(sender, null);
                    }
                    else
                        MessageBox.Show("Amound OverLoaded");
                }
                else
                    MessageBox.Show("Invalid Bill Number");
            }
            else
                MessageBox.Show("Select Bill Month");
        }

        private void btnViwLst_Click(object sender, RoutedEventArgs e)
        {
            if (dtpViwFrm.Text.Length != 0 && dtpViwTo.Text.Length != 0)
            {
                try
                {
                    String DateFrm = dtpViwFrm.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    String DateTo = dtpViwTo.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                    dgdListView.DataContext = null;
                    dgdListView.DataContext = fun.MySQLSelectAda("SELECT `AdmissionNo`, `Name`, `Age`, `Mob`, DATE_FORMAT(JoingDate, '%d/%m/%Y') , `BloodGroup`,`AdmFee` FROM `newaddmission` WHERE  `JoingDate` BETWEEN '" + DateFrm + "' AND '" + DateTo + "';");

                    DataGridColumn c0 = dgdListView.Columns[0];
                    DataGridColumn c2 = dgdListView.Columns[2];
                    DataGridColumn c3 = dgdListView.Columns[3];
                    DataGridColumn c4 = dgdListView.Columns[4];
                    DataGridColumn c5 = dgdListView.Columns[5];
                    DataGridColumn c6 = dgdListView.Columns[6];
                    c4.Header = "Joing Date";
                    c4.IsReadOnly = true;
                    c0.MaxWidth = 90;
                    c2.MaxWidth = 60;
                    c3.MaxWidth = 100;
                    c4.MaxWidth = 100;
                    c5.MaxWidth = 80;
                    c6.Header = "Admission Fee";
                    c6.MaxWidth = 120;

                    txtLstViwTotl.Text = fun.MySQLString("SELECT COUNT(*) FROM `newaddmission` WHERE  `JoingDate` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'; ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ": Error");
                }
            }
        }


        private void lstHmSrch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (lstHmSrch.SelectedItem != null)
                {
                    txtHmSrch.Text = lstHmSrch.SelectedItem.ToString();
                    btnFeeSrch_Click(sender, e);
                }
            if (e.Key == Key.Up && lstHmSrch.SelectedIndex == 0)
            {
                txtHmSrch.Focus();
                lstHmSrch.Items.Refresh();
            }
        }

        private void btnHmSrch_Click(object sender, RoutedEventArgs e)
        {
           
            String AdmNo = fun.MySQLString("SELECT `AdmissionNo` FROM  `newaddmission` WHERE `AdmissionNo`='" + txtHmSrch.Text + "' or `Name`='" + txtHmSrch.Text + "';");
            DataTable dt = fun.MySQLSelectAda("SELECT `AdmissionNo`, `Name`,`Address`,`Age`,`Job`,`BloodGroup`,`Mob`,`Time` FROM `newaddmission` WHERE `AdmissionNo`='" + txtHmSrch.Text + "' or `Name`='" + txtHmSrch.Text + "';");
            if (AdmNo != null)
            {
                tbkAdNoSR.Text = dt.Rows[0]["AdmissionNo"] + "";
                tbkNameSR.Text = dt.Rows[0]["Name"] + "";
                tbkAdrsSR.Text = dt.Rows[0]["Address"] + "";
                tbkAgeSR.Text = dt.Rows[0]["Age"] + "";
                tbkJobSR.Text = dt.Rows[0]["Job"] + "";
                tbkBGSR.Text = dt.Rows[0]["BloodGroup"] + "";
                tbkTimeSR.Text = dt.Rows[0]["Time"] + "";
                tbkMobSR.Text = dt.Rows[0]["Mob"] + "";
                tbView.IsSelected = true;

            }
            lstSFee.Items.Clear();
            MySqlDataReader rs = fun.MySQLSelect("SELECT `BillNo`,DATE_FORMAT(BillDate,'%d/%m/%y'),`AmountPaid` FROM `fees` WHERE `AdmissionNo`=" + tbkAdNoSR.Text + "");
            while (rs.Read())
            {
                String FeeList = "   " + rs.GetString("BillNo") + "                       " + rs.GetString("DATE_FORMAT(BillDate,'%d/%m/%y')") + "                                   " + rs.GetString("AmountPaid");
                lstSFee.Items.Add(FeeList);
            }

            lstHmSrch.Visibility = Visibility.Collapsed;
            txtHmSrch.Text = "";
        }

        private void txtHmSrch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                lstHmSrch.Focus();
                lstHmSrch.SelectedIndex = 0;
            }
            if (e.Key == Key.Enter)
                if (lstHmSrch.SelectedItem != null || txtHmSrch.Text.Length != 0)
                    btnHmSrch_Click(sender, e);
        }

        private void txtHmSrch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstHmSrch.Items.Clear();
            int n;
            bool isNumeric = int.TryParse(txtHmSrch.Text, out n);
            //search by id
            DataTable dtSearch = null;
            if (isNumeric == true)
                dtSearch = fun.MySQLSelectAda("SELECT `AdmissionNo`,`Name` FROM `newaddmission` WHERE `AdmissionNo` like '" + txtHmSrch.Text + "%';");
            else
                dtSearch = fun.MySQLSelectAda("SELECT `AdmissionNo`,`Name` FROM `newaddmission` WHERE `Name` like '" + txtHmSrch.Text + "%';");
            if (dtSearch.Rows.Count != 0)
            {
                foreach (DataRow dr in dtSearch.Rows)
                {
                    lstHmSrch.SelectedIndex = 0;
                    lstHmSrch.Visibility = Visibility.Visible;
                    String NameList =dr["AdmissionNo"] + " " + dr["Name"];
                    lstHmSrch.Items.Add(NameList);
                    if (txtHmSrch.Text.Length == 0)
                        lstHmSrch.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void lstHmSrch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (lstHmSrch.SelectedItem != null)
            {
                txtHmSrch.Text = lstHmSrch.SelectedItem.ToString();
                btnHmSrch_Click(sender, e);
            }
            lstHmSrch.Visibility = Visibility.Collapsed;
        }

        private void btnViewDlt_Click(object sender, RoutedEventArgs e)
        {
            if (tbkAdNoSR.Text.Length != 0)
                if (MessageBox.Show("Are you sure want delete ?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                {
                    try
                    {
                        fun.MySQLWork("DELETE FROM `newaddmission` WHERE `AdmissionNo`='" + tbkAdNoSR.Text + "'", " Deleted");
                        fun.MySQLWork("DELETE FROM `fees` WHERE `AdmissionNo`='" + tbkAdNoSR.Text + "'", null);

                        string destinationFile = @"Images/" + tbkAdNoSR.Text + ".jpg";
                        File.Delete(destinationFile);

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    tbHome.IsSelected = true;
                    txtHmSrch.Text = "";
                    lstHmSrch.Visibility = Visibility.Collapsed;
                }
        }

        private void btnSrchEdt_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (new Utilities.WaitCursor())
                {
                    NewAdmClear();
                    DataTable dt = fun.MySQLSelectAda("SELECT `AdmissionNo`, `Name`, `Address`, `Gender`, `Age`, `Mob`, `Job`, `BloodGroup`, `Sugar`, `Pressure`, `Cholesterol`, `OtherDiseases`, `MatrialArts`, `Development`, `Time`,`AdmFee`,`JoingDate`,Notes  FROM `newaddmission` WHERE `AdmissionNo`='" + tbkAdNoSR.Text + "';");
                    if (dt != null)
                    {
                        tbkNAdm.Text = dt.Rows[0]["AdmissionNo"] + "";
                        txtNName.Text = dt.Rows[0]["Name"] + "";
                        txtNAddr.Text = dt.Rows[0]["Address"] + "";
                        if (dt.Rows[0]["Gender"] + "" == "Male")
                            rdNGndrM.IsChecked = true;
                        else
                            rdNGndrF.IsChecked = true;
                        txtNAge.Text = dt.Rows[0]["Age"] + "";
                        txtNMob.Text = (dt.Rows[0]["Mob"] + "").Remove(0, 2);
                        txtNJob.Text = dt.Rows[0]["Job"] + "";
                        cmbNBlood.Text = dt.Rows[0]["BloodGroup"] + "";
                        txtNSgr.Text = dt.Rows[0]["Sugar"] + "";
                        txtNBP.Text = dt.Rows[0]["Pressure"] + "";
                        txtNCol.Text = dt.Rows[0]["Cholesterol"] + "";
                        if (dt.Rows[0]["OtherDiseases"] + "" == "0")
                            chkNDis.IsChecked = false;
                        else
                            chkNDis.IsChecked = true;

                       
                        dtpAdmDate.Text = dt.Rows[0]["JoingDate"] + "";
                        txtNAdmFee.Text = dt.Rows[0]["AdmFee"] + "";

                        if (dt.Rows[0]["MatrialArts"] + "" == "0")
                            chkNMrtlArts.IsChecked = false;
                        else
                            chkNMrtlArts.IsChecked = true;

                        cmbNDvlpmnt.Text = dt.Rows[0]["Development"] + "";
                        if (dt.Rows[0]["Time"] + "" == "Morning")
                            rdNTimM.IsChecked = true;
                        else
                            rdNTimE.IsChecked = true;
                        txtNNote.Text = dt.Rows[0]["Notes"] + "";
                    }
                    String ImgPath = System.IO.Directory.GetCurrentDirectory();
                    if (System.IO.File.Exists(@"" + ImgPath + "\\Images\\" + tbkNAdm.Text + ".jpg"))
                    {
                        BitmapImage bmi = new BitmapImage();
                        bmi.BeginInit();
                        bmi.CacheOption = BitmapCacheOption.OnLoad;
                        bmi.UriSource = new Uri(@"" + ImgPath + "\\Images\\" + tbkNAdm.Text + ".jpg");
                        bmi.EndInit();
                        imgCptr.Source = bmi;
                    }
                }
                tbNew.IsSelected = true;

            }
            catch (Exception)
            { }
        }

        private void txtFeePayNw_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txtFeePayNw.Text.Length != 0)
                {
                    btnFeeSbmt_Click(sender, e);
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            fun.MySQLBackupDB(null);
            Environment.Exit(Environment.ExitCode);
            System.Threading.Thread.Sleep(900);
        }

        private void btnViwEdt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgdListView.SelectedItems.Count >= 1)
                {
                    DataRowView row = (DataRowView)dgdListView.SelectedItems[0];
                    tbkAdNoSR.Text = row[0].ToString();
                    btnSrchEdt_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViwDlt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgdListView.SelectedItems.Count >= 1)
                {
                    if (MessageBox.Show("Are you sure want delete ?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                    {
                        DataRowView row = (DataRowView)dgdListView.SelectedItems[0];
                        String ID = row[0].ToString();

                        fun.MySQLWork("DELETE FROM `newaddmission` WHERE `AdmissionNo`='" + ID + "'", null);
                        btnViwLst_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void expTypeLoad()
        {
            DataTable dtType = fun.MySQLSelectAda("SELECT DISTINCT `Type` FROM `expnccategory`;");
            foreach (DataRow dr in dtType.Rows)
                cmbExpnc.Items.Add(dr["Type"] + "");
        }


        public void incTypeLoad()
        {
            DataTable dtType = fun.MySQLSelectAda("SELECT DISTINCT `Type` FROM `incomecategory`;");
            foreach (DataRow dr in dtType.Rows)
                cmbIncome.Items.Add(dr["Type"] + "");
        }

        private void grdEpnc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dtpExpncdte.Text = DateTime.Now.ToShortDateString();
            tbExpnc.IsSelected = true;
            cmbExpnc.Items.Clear();
            expTypeLoad();
        }
        private void btnExpncTyp_Click(object sender, RoutedEventArgs e)
        {
            Custom cst = new Custom();
            cst.tbExpCatgry.IsSelected = true;
            cst.Title = "Add Category";
            cst.Height = 160;
            cst.Width = 340;
            cst.txtCtgry.Focus();
            cst.ShowDialog();
        }
        public void expncGrd()
        {
            try
            {
                String Date = dtpExpncdte.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                dgdExpnc.DataContext = null;
                dgdExpnc.DataContext = fun.MySQLSelectAda("SELECT `Id`, DATE_FORMAT(`Date`, '%d/%m/%Y'), `Type`, `Amount`, `Description` FROM `expenses` WHERE Date ='" + Date + "'");

                DataGridColumn c0 = dgdExpnc.Columns[0];
                DataGridColumn c1 = dgdExpnc.Columns[1];
                DataGridColumn c2 = dgdExpnc.Columns[2];
                DataGridColumn c3 = dgdExpnc.Columns[3];

                c0.Visibility = Visibility.Collapsed;
                c1.Header = "Date";
                c1.MaxWidth = 120;
                c2.MaxWidth = 300;
                c3.MaxWidth = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": Error");
            }
        }

        public void IncomeGrd()
        {
            try
            {
                String Date = dtpIncomdte.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                dgdIncome.DataContext = null;
                dgdIncome.DataContext = fun.MySQLSelectAda("SELECT `Id`, DATE_FORMAT(`Date`, '%d/%m/%Y'), `Type`, `Amount`, `Description` FROM `income` WHERE Date ='" + Date + "'");

                DataGridColumn c0 = dgdIncome.Columns[0];
                DataGridColumn c1 = dgdIncome.Columns[1];
                DataGridColumn c2 = dgdIncome.Columns[2];
                DataGridColumn c3 = dgdIncome.Columns[3];

                c0.Visibility = Visibility.Collapsed;
                c1.Header = "Date";
                c1.MaxWidth = 120;
                c2.MaxWidth = 300;
                c3.MaxWidth = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": Error");
            }
        }


        private void btnExpncAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String Date = dtpExpncdte.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                if (dtpExpncdte.Text.Length != 0 && cmbExpnc.Text.Length != 0 && txtExpncAmt.Text.Length != 0)
                {
                    String id = fun.MySQLString("SELECT `Id` FROM `expenses` WHERE  `Id`='" + txtExpId.Text + "';");
                    if (id != null)
                    {
                        fun.MySQLWork("UPDATE `expenses` SET `Date`='" + Date + "',`Type`='" + cmbExpnc.Text + "',`Amount`=" + txtExpncAmt.Text + ",`Description`='" + txtExpdes.Text + "' WHERE `Id`='" + txtExpId.Text + "'", "Added Successfully");

                        dtpExpncdte.Text = DateTime.Now.ToShortDateString();
                        cmbExpnc.Text = "";
                        txtExpncAmt.Text = "";
                        txtExpdes.Text = "";
                    }
                    else
                    {
                        fun.MySQLWork("INSERT INTO `expenses`( `Date`, `Type`, `Amount`, `Description`) VALUES ('" + Date + "','" + cmbExpnc.Text + "'," + txtExpncAmt.Text + ",'" + txtExpdes.Text + "')", "Added Successfully");

                        dtpExpncdte.Text = DateTime.Now.ToShortDateString();
                        cmbExpnc.Text = "";
                        txtExpncAmt.Text = "";
                        txtExpdes.Text = "";
                    }
                }
                else
                    MessageBox.Show("Please fill Mandatory fields", "Alert");
                expncGrd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }

        private void btnExpncVwR_Click(object sender, RoutedEventArgs e)
        {
            expncGrd();
        }

        private void grdrRpts_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbRpt.IsSelected = true;
        }

        private void btnRptGen_Click(object sender, RoutedEventArgs e)
        {
            tbkRptAdFee.Text = "0";
            tbkRptMthFee.Text = "0";
            tbkRptOthr.Text = "0";
            tbkRptTotBal.Text = "0";
            tbkRptTotExp.Text = "0";
            tbkRptTotExplst.Text = "0";
            tbkRptTotFee.Text = "0";
            tbkRptTotIncm.Text = "0";
            if (dtpRptFrm.Text.Length != 0 && dtpRptTo.Text.Length != 0)
            {
                String DateFrm = dtpRptFrm.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                String DateTo = dtpRptTo.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                //incom calculation
                int ad = 0, mt = 0, ot = 0;
                try
                {
                    tbkRptAdFee.Text = fun.MySQLString("SELECT  COALESCE(SUM(`AdmFee`),0) FROM `newaddmission` WHERE `JoingDate` BETWEEN '" + DateFrm + "' AND '" + DateTo + "';");
                    ad = Convert.ToInt32(tbkRptAdFee.Text);

                    tbkRptMthFee.Text = fun.MySQLString("SELECT  COALESCE(SUM(`AmountPaid`),0) FROM `fees` WHERE !(`AdmissionNo`=0) AND `BillDate` BETWEEN '" + DateFrm + "' AND '" + DateTo + "';");
                    mt = Convert.ToInt32(tbkRptMthFee.Text);

                    tbkRptOthr.Text = fun.MySQLString("SELECT COALESCE(SUM(`Amount`),0)Amount FROM `income`  WHERE `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'");
                    ot = Convert.ToInt32(tbkRptOthr.Text);

                    dtRptIncome.DataContext = null;
                    dtRptIncome.DataContext = fun.MySQLSelectAda("SELECT  DATE_FORMAT(`Date`, '%d/%m/%Y') Date, `Type`, SUM(`Amount`)Amount FROM `income`  WHERE `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'GROUP BY `Type`;");

                    DataGridColumn c0 = dtRptIncome.Columns[0];
                    DataGridColumn c1 = dtRptIncome.Columns[2];
                    c0.MaxWidth = 100;
                    c1.MaxWidth = 80;
                  // tbkRptTotExplst.Text = fun.MySQLString("SELECT COALESCE(SUM(`Amount`),0)Amount FROM `income`  WHERE `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'");


                    int sum = ad + mt + ot;
                    tbkRptTotFee.Text = sum + "";
                    // expences
                    dgdRpt.DataContext = null;
                    dgdRpt.DataContext = fun.MySQLSelectAda("SELECT  DATE_FORMAT(`Date`, '%d/%m/%Y') Date, `Type`, SUM(`Amount`)Amount FROM `expenses`  WHERE `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'GROUP BY `Type`;");

                    DataGridColumn d0 = dgdRpt.Columns[0];
                    DataGridColumn d1 = dgdRpt.Columns[2];
                    d0.MaxWidth = 100;
                    d1.MaxWidth = 80;
                    tbkRptTotExplst.Text = fun.MySQLString("SELECT COALESCE(SUM(`Amount`),0)Amount FROM `expenses`  WHERE `Date` BETWEEN '" + DateFrm + "' AND '" + DateTo + "'");

                    tbkRptTotIncm.Text = tbkRptTotFee.Text;
                    tbkRptTotExp.Text = tbkRptTotExplst.Text;
                    int a = Convert.ToInt32(tbkRptTotIncm.Text);
                    int b = Convert.ToInt32(tbkRptTotExp.Text);
                    int bal = a - b;
                    tbkRptTotBal.Text = bal + "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExpDlt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgdExpnc.SelectedItems.Count >= 1)
                {
                    if (MessageBox.Show("Are you sure want delete ?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                    {
                        DataRowView row = (DataRowView)dgdExpnc.SelectedItems[0];
                        String ID = row[0].ToString();

                        fun.MySQLWork("DELETE FROM `expenses` WHERE `Id`='" + ID + "'", null);
                        btnViwLst_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFeeOtSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtFeeOtAmt.Text.Length != 0 && txtFeeOtName.Text.Length != 0)
            {
                String BillDate = dtpBillDate.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                fun.MySQLWork("INSERT INTO `fees`(`BillNo`,`BillDate`,`Name`, `AmountPaid`) VALUES (" + tbkBillNo.Text + ",'" + BillDate + "','" + txtFeeOtName.Text + "'," + txtFeeOtAmt.Text + ")", null);
                txtFeeOtName.Text = "";
                txtFeeOtAmt.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnExpLdgr_Click(object sender, RoutedEventArgs e)
        {
            Custom cst = new Custom();
            cst.tb.IsSelected = true;
            cst.Title = "Expences";
            // cst.Height = 160;
            cst.txtCtgry.Focus();
            cst.ShowDialog();
        }

        private void btnExpEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgdExpnc.SelectedItems.Count >= 1)
                {
                    DataRowView row = (DataRowView)dgdExpnc.SelectedItems[0];
                    txtExpId.Text = row[0].ToString();

                    DataTable dt = fun.MySQLSelectAda("SELECT `Id`, `Date`, `Type`, `Amount`, `Description` FROM `expenses` WHERE  `id`='" + txtExpId.Text + "';");
                    if (dt != null)
                    {
                        dtpExpncdte.Text = dt.Rows[0]["Date"] + "";
                        cmbExpnc.Text = dt.Rows[0]["Type"] + "";
                        txtExpncAmt.Text = dt.Rows[0]["Amount"] + "";
                        txtExpdes.Text = dt.Rows[0]["Description"] + "";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFeeRptLst_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFeeRpt.Text.Length != 0)
            {
                try
                {
                    dgdFeeRpt.DataContext = null;
                    dgdFeeRpt.DataContext = fun.MySQLSelectAda("SELECT `AdmissionNo`, `Name`, DATE_FORMAT(BillDate, '%d/%m/%Y') , `AmountPaid` FROM `fees` WHERE  `BillMonth`='" + cmbFeeRpt.Text + "' AND YEAR(BillDate) ="+ cmbFeeRptYr.Text + ";");

                    DataGridColumn c0 = dgdFeeRpt.Columns[0];
                    DataGridColumn c2 = dgdFeeRpt.Columns[2];
                    DataGridColumn c3 = dgdFeeRpt.Columns[3];
                    c2.Header = "Date of payment";
                    c0.MaxWidth = 90;
                    c2.MaxWidth = 120;
                    c3.MaxWidth = 100;

                    txtLstFeeRptTotl.Text = fun.MySQLString("SELECT  COALESCE(SUM(`AmountPaid`),0)FROM `fees`  WHERE  `BillMonth`='" + cmbFeeRpt.Text + "'  AND YEAR(BillDate) =" + cmbFeeRptYr.Text + ";");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ": Error");
                }
            }
        }

        private void textBlock9_Copy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbFeeRpt.IsSelected = true;
            cmbMonth(cmbFeeRpt);
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            setttings ss = new setttings();
            ss.ShowDialog();
        }

        private void btnViewPrint_Click(object sender, RoutedEventArgs e)
        {
            using (new Utilities.WaitCursor())
            {
                try
                {
                    if (dgdListView.DataContext != null)
                    {
                        String DateFrm = dtpViwFrm.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                        String DateTo = dtpViwTo.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                        DataTable dt = fun.MySQLSelectAda("SELECT `AdmissionNo`, `Name`, `Age`, `Mob`, DATE_FORMAT(JoingDate, '%d/%m/%Y') AS 'JoiningDate', `BloodGroup`,`AdmFee` FROM `newaddmission` WHERE  `JoingDate` BETWEEN '" + DateFrm + "' AND '" + DateTo + "';");
                        using (cryMemberList std1 = new cryMemberList())
                        {
                            std1.SetDataSource(dt);
                            std1.SummaryInfo.ReportTitle = "Member Details";
                            std1.PrintOptions.PrinterName = PrintSett.PrinterName;
                            std1.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        private void btnFeePrint_Click(object sender, RoutedEventArgs e)
        {
            using (new Utilities.WaitCursor())
            {
                try
                {
                    if (dgdFeeRpt.DataContext != null)
                    {
                        DataTable dt = fun.MySQLSelectAda("SELECT `AdmissionNo`, `Name`, DATE_FORMAT(BillDate, '%d/%m/%Y') AS 'BillDate', `AmountPaid` FROM `fees` WHERE  `BillMonth`='" + cmbFeeRpt.Text + "' AND YEAR(BillDate) = YEAR(CURDATE());");
                        using (cryFeeReport std1 = new cryFeeReport())
                        {
                            std1.SetDataSource(dt);
                            std1.SummaryInfo.ReportTitle = "Fee Details";
                            std1.PrintOptions.PrinterName = PrintSett.PrinterName;
                            std1.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        private void grdIncome_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbIncome.IsSelected = true;
        }

        private void btnIncTyp_Click(object sender, RoutedEventArgs e)
        {
            Custom cst = new Custom();
            cst.tbInc.IsSelected = true;
            cst.Title = "Add income Category";
            cst.Height = 160;
            cst.Width = 340;
            cst.txtIncCtgry.Focus();
            cst.ShowDialog();
        }

        private void btnIncomAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String Date = dtpIncomdte.SelectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                if (dtpIncomdte.Text.Length != 0 && cmbIncome.Text.Length != 0 && txtIncomAmt.Text.Length != 0)
                {
                    String id = fun.MySQLString("SELECT `Id` FROM `income` WHERE  `Id`='" + txtIncId.Text + "';");
                    if (id != null)
                    {
                        fun.MySQLWork("UPDATE `income` SET `Date`='" + Date + "',`Type`='" + cmbIncome.Text + "',`Amount`=" + txtIncomAmt.Text + ",`Description`='" + txtIncomdes.Text + "' WHERE `Id`='" + txtIncId.Text + "'", "Added Successfully");

                        dtpIncomdte.Text = DateTime.Now.ToShortDateString();
                        cmbIncome.Text = "";
                        txtIncomAmt.Text = "";
                        txtIncomdes.Text = "";
                    }
                    else
                    {
                        fun.MySQLWork("INSERT INTO `income`( `Date`, `Type`, `Amount`, `Description`) VALUES ('" + Date + "','" + cmbIncome.Text + "'," + txtIncomAmt.Text + ",'" + txtIncomdes.Text + "')", "Added Successfully");

                        dtpIncomdte.Text = DateTime.Now.ToShortDateString();
                        cmbIncome.Text = "";
                        txtIncomAmt.Text = "";
                        txtIncomdes.Text = "";
                    }
                }
                else
                    MessageBox.Show("Please fill Mandatory fields", "Alert");
                IncomeGrd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }

        private void btnExpLdgr1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIncLdgr_Click(object sender, RoutedEventArgs e)
        {
            Custom cst = new Custom();
            cst.tbIncrpt.IsSelected = true;
            cst.Title = "Ledger";
            cst.txtCtgry.Focus();
            cst.ShowDialog();
        }

        private void grdIncome_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            dtpIncomdte.Text = DateTime.Now.ToShortDateString();
            tbIncome.IsSelected = true;
            cmbIncome.Items.Clear();
            incTypeLoad();
        }

        private void btnIncVwR_Click(object sender, RoutedEventArgs e)
        {
            IncomeGrd();
        }

        private void btnIncDlt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgdIncome.SelectedItems.Count >= 1)
                {
                    if (MessageBox.Show("Are you sure want delete ?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                    {
                        DataRowView row = (DataRowView)dgdIncome.SelectedItems[0];
                        String ID = row[0].ToString();

                        fun.MySQLWork("DELETE FROM `income` WHERE `Id`='" + ID + "'", null);
                        btnViwLst_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdtPhysic_Click(object sender, RoutedEventArgs e)
        {
            physic ph = new physic(Convert.ToInt16( tbkAdNoSR.Text),tbkNameSR.Text);
            ph.ShowDialog();
        }

       
    }
}

