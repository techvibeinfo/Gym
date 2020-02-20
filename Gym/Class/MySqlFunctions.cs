using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

namespace Gym.Class
{
    class MySqlFunctions : IDisposable
    {
        //MySqlDataAdapter adap;
        //DataSet ds;

        public MySqlConnection Conn;
        public String strProvider= "Data Source=localhost;Database=gym;User ID = root; Password=Conversion@2017!!;Convert Zero Datetime=True;", MySqlUser = "", MySqlPass = "", MySqlServer = "", MySqlDB = "";
        public void Dispose()
        {
            if (Conn != null)
            {
                Conn.Dispose();
                Conn = null;
            }
        }
        
        public DataTable MySQLSelectAda(String SelectSQL)
        {
            MySqlDataAdapter rs = null;
            try
            {
                Dispose();
                Conn = new MySqlConnection(strProvider);
                MySqlCommand cmd1 = new MySqlCommand(SelectSQL, Conn);
                rs = new MySqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                rs.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :1 " + ex.Message);
                return null;
            }
        }

        public MySqlDataReader MySQLSelect(String SelectSQL)
        {
            MySqlDataReader rs = null;
            try
            {
                Dispose();
                Conn = new MySqlConnection(strProvider);
                MySqlCommand command = Conn.CreateCommand();
                Conn.Open();
                command.CommandText = SelectSQL;
                rs = command.ExecuteReader();
                return rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return null;
            }
          
        }

        public void MySQLWork(String SQL, String msg)
        {
            try
            {
                Dispose();
                Conn = new MySqlConnection(strProvider);
                MySqlCommand command = Conn.CreateCommand();
                Conn.Open();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                if (msg != null)
                    MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        public String MySQLString(String SelectSQL)
        {
            MySqlDataReader rs = null;
            try
            {
                Dispose();
                Conn = new MySqlConnection(strProvider);
                MySqlCommand command = Conn.CreateCommand();
                Conn.Open();
                command.CommandText = SelectSQL;
                rs = command.ExecuteReader();
                if (rs.Read())
                {
                    String s = rs.GetString(0);
                    return s;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }

        public void MySQLBackupDB(String Path)
        {
            try
            {
                Dispose();
                MySqlConnection conn = new MySqlConnection(strProvider);
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mb = new MySqlBackup(cmd);
                cmd.Connection = conn;
                conn.Open();
                if (Path == null)
                    mb.ExportToFile(@"backup/" + DateTime.Now.ToString("dd-MM-") + "BackUp.sql");
                else
                    mb.ExportToFile(Path);
            }
            catch { }
        }

        public void CreateDB()
        {
            const String strAuth = "Data Source=localhost;User ID=root;Password=;";
            try
            {
                using (new Utilities.WaitCursor())
                {
                    Conn = new MySqlConnection(strAuth);
                    MySqlCommand command = Conn.CreateCommand();

                    Conn.Open();
                    command.CommandText = "CREATE DATABASE IF NOT EXISTS `" + MySqlDB + "`;";
                    command.ExecuteNonQuery();

                    MySqlDataReader rs = MySQLSelect("SHOW TABLES FROM " + MySqlDB + "");
                    if (!rs.Read())
                    {
                        MySqlConnection cnn = new MySqlConnection(strProvider);
                        MySqlCommand cmd = new MySqlCommand();
                        MySqlBackup mb = new MySqlBackup(cmd);
                        cmd.Connection = cnn;
                        cnn.Open();
                        mb.ImportFromFile(@"backup/BlankDB.sql");
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        //public void MySQLRestoreDB(String Path, String msg)
        //{
        //    try
        //    {
        //        Conn = new MySqlConnection(strProvider);
        //        MySqlCommand command = Conn.CreateCommand();
        //        MySqlBackup mb = new MySqlBackup(command);
        //        Conn.Open();
        //        command.CommandText = "DROP DATABASE IF EXISTS `" + MySqlDB + "`;CREATE DATABASE IF NOT EXISTS `" + MySqlDB + "`;";
        //        command.ExecuteNonQuery();
        //        mb.ImportFromFile(@"backup/BlankDB.sql");
        //        if (msg != null)
        //            MessageBox.Show(msg);
        //        Conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        //public void MySQLSelectDT()
        //{
        //    try
        //    {
        //        fun.connection = new MySqlConnection(strProvider);
        //        fun.connection.ConnectionString = "Data Source=localhost; Database=tuitioncenter; User ID=root; Password=;";
        //        fun.connection.Open();
        //        adap = new MySqlDataAdapter("select `Eid`,`Rollno`,`Name`,`Mark` from `students`  where `Batch`='" + cmbMrkEBth.Text + "'AND `TuitionClass`='" + cmbMrkECls.Text + "'ORDER BY `students`.`Rollno` ASC", fun.connection);
        //        ds = new DataSet();
        //        adap.Fill(ds, "Mark_Details");
        //        dgdMark.DataContext = ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //public DataSet MySQLSelectDataset(String SelectSQL)
        //{
        //    try
        //    {
        //        Conn = new MySqlConnection(strProvider);
        //        MySqlCommand cmd1 = new MySqlCommand(SelectSQL, Conn);
        //        MySqlDataAdapter rs = new MySqlDataAdapter(cmd1);
        //        DataSet dataSet1 = new DataSet("Tables");
        //        rs.Fill(dataSet1);
        //        return dataSet1;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error : " + ex.Message);
        //        return null;
        //    }
        //}

    }
}
