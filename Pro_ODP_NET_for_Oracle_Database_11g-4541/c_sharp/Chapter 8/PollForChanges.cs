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
    public partial class PollForChanges : Form
    {
        private static OracleDependency _globalDep;
        public PollForChanges()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT * FROM Products";
                OracleDependency.Port = 1200;
                _globalDep = new OracleDependency(_cmdObj);
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Change Notification Registered!");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //Start a timer to keep polling for changes in the table every 1 second
            timer1.Tick += new EventHandler(TimerTick);
            timer1.Start();
        }
        
        //The timer tick event handler. Show a message if a change is detected
        private static void TimerTick(object sender, EventArgs e)
        {
            if (_globalDep.HasChanges)
            {
                MessageBox.Show("Change detected!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj2 = new OracleConnection(_connstring);
                _connObj2.Open();
                OracleTransaction _txn = _connObj2.BeginTransaction();
                string _sql = "INSERT INTO Products(ID, Name, Price) VALUES('AZ1','Test Product',300)";
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
