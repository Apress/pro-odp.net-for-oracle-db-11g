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

    public partial class SelfUpdatingDatagrid : Form
    {
        private bool _BoundToDB = false;
        private int _globalID = 1;
        //The event handler for the change notification. Here we initiate a refresh of the grid data
        public void OnNotificationReceived(object src, OracleNotificationEventArgs arg)
        {
            RefreshGrid();
        }

        //Extra code to update the DataGridView control from a callback thread
        private delegate void RefreshGridDelegate();

        private void RefreshGrid()
        {
            if (this.InvokeRequired)
            {
                RefreshGridDelegate _displayDataFunc = new RefreshGridDelegate(RefreshGrid);
                this.BeginInvoke(_displayDataFunc);
                return;
            }
            //Write the code to populate the DataGridView control with latest data from the
            //Products table
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT * FROM Products";
                OracleDataAdapter _adapObj = new OracleDataAdapter (_cmdObj);
                DataSet _products = new DataSet();
                _adapObj.Fill(_products);
                dataGridView1.DataSource =_products.Tables[0];
                dataGridView1.Refresh();
                _cmdObj.Dispose();
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public SelfUpdatingDatagrid()
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
                OracleDependency _dep = new OracleDependency(_cmdObj);
                    //Set notification settings
                _dep.QueryBasedNotification = false;
                _cmdObj.Notification.IsNotifiedOnce = false;
                _dep.OnChange += new OnChangeEventHandler(OnNotificationReceived);
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Change Notification Registered!");
                _BoundToDB = true;
                //Populate the DataGridView with data from the Products table
                RefreshGrid();
                while (_BoundToDB == true)
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

        private void button2_Click(object sender, EventArgs e)
        {
            _BoundToDB = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            _globalID += 1;
            try
            {
                OracleConnection _connObj2 = new OracleConnection(_connstring);
                _connObj2.Open();
                OracleTransaction _txn = _connObj2.BeginTransaction();
                string _sql = "INSERT INTO Products(ID, Name, Price) VALUES('TP" + _globalID.ToString() + "','Test Product',100)";
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
