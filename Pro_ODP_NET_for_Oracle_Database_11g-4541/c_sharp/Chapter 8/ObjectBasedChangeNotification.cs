using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace Chapter_8
{
    public partial class ObjectBasedChangeNotification : Form
    {
        private static bool _NotificationRaised = false;
        public ObjectBasedChangeNotification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                //Register the change notification
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT * FROM Products";
                OracleDependency.Port = 1200;
                OracleDependency _dep = new OracleDependency(_cmdObj);
                _dep.QueryBasedNotification = false;
                _dep.OnChange += new OnChangeEventHandler(OnNotificationReceived);
                _cmdObj.ExecuteNonQuery();
                //Wait in a loop for the notification
                while (_NotificationRaised==false)
                {
                Application.DoEvents();
                }
                    _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //The event handler for the change notification
        public static void OnNotificationReceived(object src, OracleNotificationEventArgs arg)
        {
            DataTable changeDetails = arg.Details;
            _NotificationRaised = true;
            MessageBox.Show("Table has changed: " + changeDetails.Rows[0]["ResourceName"]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj2 = new OracleConnection(_connstring);
                _connObj2.Open();
                OracleTransaction _txn = _connObj2.BeginTransaction();
                //Insert a new record into the table
                string _sql = "INSERT INTO Products (ID, Price, Name) VALUES('ZL1', 300, 'TestProduct')";
                OracleCommand _cmdObj2 = new OracleCommand(_sql, _connObj2);
                _cmdObj2.ExecuteNonQuery();
                _txn.Commit();
                _connObj2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
