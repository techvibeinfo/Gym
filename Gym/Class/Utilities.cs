using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml;


namespace Gym.Class
{
    class Utilities
    {   
        //UnHandled Exceptions
        public static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            if (MessageBox.Show("Sorry Something Went Wrong.\nDo you want to send this error to developer ?", "Report Error", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
            {
                using (new Utilities.WaitCursor())
                {
                    //String AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EduWare\\";
                    String ErrorMsg = e.StackTrace;
                    File.WriteAllText("Errorlog.txt", ErrorMsg);
                    if (CheckInternet())
                        SendMail("Gym", "Error Report", "Errorlog.txt");

                    System.Diagnostics.Process.Start(@"Gym.exe");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }

        }

        public static bool CheckInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Unable to connect to the Internet");
                return false;
            }
        }

        public static void AsgnRno(String Class, String Batch)
        {
            int rollno = 0;
            MySqlFunctions fun = new MySqlFunctions();
            //fun.strProvider = fun.MySQLXML();
            DataTable dt = fun.MySQLSelectAda("SELECT `AdmissionNo` FROM `students` WHERE `TuitionClass`='" + Class + "' && `Batch`= '" + Batch + "' ORDER BY `students`.`Name` ASC;");
            foreach (DataRow dr in dt.Rows)
            {
                rollno++;
                fun.MySQLWork("UPDATE `students` SET `Rollno`=" + rollno + " WHERE `AdmissionNo`='" + dr["AdmissionNo"].ToString() + "' ;", null);
            }
        }

        //Send Email
        public static void SendMail(String Center, String Content, String AttachPath)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Timeout = 50000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("techvibecreations@gmail.com", "999589439037");
                    MailMessage msg = new MailMessage();
                    msg.To.Add("vaisakhbeypore@gmail.com");
                    msg.From = new MailAddress("techvibecreations@gmail.com");

                    if (Center != null)
                        msg.Subject = "Error Message from " + Center + "";
                    if (AttachPath != null)
                    {
                        Attachment data = new Attachment(AttachPath);
                        msg.Attachments.Add(data);
                    }
                    msg.Body = Content;
                    client.Send(msg);
                }
                MessageBox.Show("Successfully Sent Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //CheckForUpdate
        public static String[] CheckForUpdate()
        {
            try
            {
                XmlTextReader XMLReader = new XmlTextReader(@"https://docs.google.com/uc?authuser=0&id=0B8136Hy2QnXfN0RwekNoS2FwOFk&export=download");
                String[] FParam = new String[4];
                String element = "";

                while (XMLReader.Read())
                {
                    if (XMLReader.NodeType == XmlNodeType.Element)
                        element = XMLReader.Name;
                    else if (XMLReader.NodeType == XmlNodeType.Text)
                    {
                        if (element == "Url") FParam[0] = XMLReader.Value;
                        if (element == "Version") FParam[1] = XMLReader.Value;
                        if (element == "Size") FParam[2] = XMLReader.Value;
                        if (element == "Changelog") FParam[3] = XMLReader.Value;
                    }
                }
                XMLReader.Close();
                return FParam;
            }
            catch { return null; }
        }

        //Waiting Cursor
        public class WaitCursor : IDisposable
        {
            private Cursor PrevCursor;
            public WaitCursor()
            {
                PrevCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;
            }

            #region IDisposable Members

            public void Dispose()
            {
                Mouse.OverrideCursor = PrevCursor;
            }

            #endregion
        }


        //Stopwatch
        //public void StopWatch()
        //{
        //    System.Diagnostics.Stopwatch stp = System.Diagnostics.Stopwatch.StartNew();
        //    stp.Stop();
        //    MessageBox.Show(stp.ElapsedMilliseconds + "");
        //}

        //Number to Words
        //public static String ConvertNumbertoWords(int number)
        //{
        //    if (number == 0)
        //        return "ZERO";
        //    if (number < 0)
        //        return "minus " + ConvertNumbertoWords(Math.Abs(number));
        //    string words = "";
        //    if ((number / 1000000) > 0)
        //    {
        //        words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
        //        number %= 1000000;
        //    }
        //    if ((number / 1000) > 0)
        //    {
        //        words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
        //        number %= 1000;
        //    }
        //    if ((number / 100) > 0)
        //    {
        //        words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
        //        number %= 100;
        //    }
        //    if (number > 0)
        //    {
        //        if (words != "")
        //            words += "AND ";
        //        var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        //        var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

        //        if (number < 20)
        //            words += unitsMap[number];
        //        else
        //        {
        //            words += tensMap[number / 10];
        //            if ((number % 10) > 0)
        //                words += " " + unitsMap[number % 10];
        //        }
        //    }
        //    return words;
        //}


        ////File Download
        //public void FileDownload()
        //{
        //    string url = @"http://st1.bollywoodlife.com/wp-content/uploads/2014/03/shreya-ghosal-1-120313130311184413.jpg";
        //    // Create an instance of WebClient
        //    System.Net.WebClient client = new System.Net.WebClient();
        //    // Hookup DownloadFileCompleted Event
        //    client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);

        //    // Start the download and copy the file to c:\temp
        //    client.DownloadFileAsync(new Uri(url), @"c:\shreya.jpg");
        //}
        //void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    MessageBox.Show("File downloaded");
        //}

            //private void ConStatus(TextBlock tbk)
        //{
        //    //CONNECTION TEST
        //    try
        //    {
        //        MySqlDataReader rs = fun.MySQLSelect("SHOW TABLES FROM " + fun.MySqlDB + "");
        //        if (rs.Read())
        //        {
        //            tbk.Text = "Connected";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        fun.connection.Close();
        //        DTimer.Stop();
        //        tbk.Text = "Not Connected";
        //    }
        //}

        //public override void Commit(!Dictionary savedState)
        //{
        //    if (!isMySQLInstalled)
        //    {
        //        // Starts the installation of the mysql community server                    
        //        Process p = new Process();
        //        p.StartInfo.FileName = "msiexec.exe";
        //        p.StartInfo.Arguments = string.Format(" /q /log install.txt /i " +
        //                                context.Parameters["TARGETDIR"].ToString() + "MySQL_Setup.exe" +
        //                                " datadir=\"C:\\Program Files\\MySQL\\MySQL Server 5.0\" " +
        //                                "installdir=\"C:\\Program Files\\MySQL\\MySQL Server 5.0\\data\"");
        //        p.Start();
        //        p.WaitForExit();

        //        // Starts the configuration of the mysql server
        //        p = new Process();
        //        p.StartInfo.FileName = "C:\\Program Files\\MySQL\\MySQL Server 5.0\\bin\\MySQLInstanceConfig.exe";
        //        p.StartInfo.Arguments = string.Format(" -i -q \"-lC:\\mysql_install_log.txt\" \"-nMySQL Server 5.0.51\" " +
        //                                            "\"-pC:\\Program Files\\MySQL\\MySQL Server 5.0\" -v5.0.51  " +
        //                                            "\"-tC:\\Program Files\\MySQL\\MySQL Server 5.0\\my-template.ini\" " +
        //                                            "\"-cC:\\Program Files\\MySQL\\MySQL Server 5.0\\mytest.ini\" " +
        //                                            "ServerType=DEVELOPMENT DatabaseType=MIXED " +
        //                                            "ConnectionUsage=DSS Port=3306 ServiceName=MySQL " +
        //                                            "RootPassword=nevermind AddBinToPath=yes");
        //        p.Start();
        //        p.WaitForExit();
        //    }

        //    if (!isMySQLODBCConnectorInstalled)
        //    {
        //        Process p = new Process();
        //        p.StartInfo.FileName = "msiexec.exe";
        //        p.StartInfo.Arguments = string.Format(" /q /log install.txt /i " +
        //                                context.Parameters["TARGETDIR"].ToString() + "mysql-connector-odbc-5.2.5-win32.msi");
        //        p.Start();
        //        p.WaitForExit();
        //    }
        //}

        //}

        //public void threa()
        //{
        //    // Create a thread
        //    Thread newWindowThread = new Thread(new ThreadStart(() =>
        //    {
        //        // Create our context, and install it:
        //        SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));

        //        LoadWindow tempWindow = new LoadWindow();
        //        // When the window closes, shut down the dispatcher
        //        tempWindow.Closed += (s, e) =>
        //           Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);

        //        tempWindow.Show();
        //        // Start the Dispatcher Processing
        //        System.Windows.Threading.Dispatcher.Run();
        //    }));
        //    // Setup and start thread as before

        //}

        //public static void ReceiveMail()
        //{
        //    var client = new POPClient();
        //    client.Connect("pop.gmail.com", 995, true);
        //    client.Authenticate("admin@bendytree.com", "YourPasswordHere");
        //    var count = client.GetMessageCount();
        //    Message message = client.GetMessage(count);
        //    Console.WriteLine(message.Headers.Subject);
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var rows = GetDataGridRows(dgdMarkNew);
        //    foreach (DataGridRow r in rows)
        //    {
        //        DataRowView rv = (DataRowView)r.Item;
        //        foreach (DataGridColumn c in dgdMarkNew.Columns)
        //        {
        //            if (c.GetCellContent(r) is TextBlock)
        //            {
        //                TextBlock cellcontent = c.GetCellContent(r) as TextBlock;
        //                MessageBox.Show(cellcontent + "");
        //            }
        //        }
        //    }
        //}
    }
}
