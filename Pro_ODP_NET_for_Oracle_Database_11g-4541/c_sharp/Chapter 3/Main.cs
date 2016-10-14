using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data.Common;

namespace Chapter_3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "Data Source=localhost/NEWDB;User ID=SYSTEM;Password=admin";
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "Data Source = " +
            "(DESCRIPTION = " +
            " (ADDRESS_LIST = " +
            " (ADDRESS = (PROTOCOL = TCP)" +
            " (HOST = 127.0.0.1) " +
            " (PORT = 1521) " +
            " )" +
            " )" +
            " (CONNECT_DATA = " +
            " (SERVICE_NAME = NEWDB)" +
            " )" +
            ");" +
            "User Id=SYSTEM;" +
            "password=admin;";
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "Data Source=EDZEHOO-PC:1521/NEWDB;User ID=SYSTEM;Password=admin";
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "Data Source=localhost/NEWDB;" + 
            "User ID=SYSTEM;"  +
            "Password=admin;" +
            "Min Pool Size=10;" +
            "Max Pool Size=100;" +
            "Connection Lifetime=120;" +
            "Connection Timeout=60;" +
            "Incr Pool Size=3;" +
            "Decr Pool Size=1;";
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "Data Source=localhost/NEWDB;User ID=/;";
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "User Id=SYSTEM;Password=admin;" +
            "DBA Privilege=SYSDBA;Data Source=localhost/NEWDB;";
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int _counter;
            DataTable _table = System.Data.Common.DbProviderFactories.GetFactoryClasses();
            for (_counter = 0; _counter <= _table.Rows.Count - 1; _counter++)
            {
                if (String.Compare (_table.Rows[_counter]["Name"].ToString (),"Oracle Data Provider for .NET",true)==0)
                {
                    MessageBox.Show("ODP.NET exists");
                    return;
                }
            }
            MessageBox.Show("ODP.NET does not exist");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OracleConnectionStringBuilder _conn = new OracleConnectionStringBuilder();
            _conn.DataSource = "NEWDB";
            _conn.DecrPoolSize = 5;
            _conn.IncrPoolSize = 10;
            _conn.Pooling = true;
            _conn.MaxPoolSize = 100;
            _conn.MinPoolSize = 5;
            _conn.ConnectionLifeTime = 120;
            _conn.ConnectionTimeout = 60;
            _conn.UserID = "SYSTEM";
            _conn.Password = "admin";
            MessageBox.Show(_conn.ConnectionString);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DbProviderFactory _ftry;
            _ftry=DbProviderFactories.GetFactory("Oracle.DataAccess.Client");
            DbDataSourceEnumerator _datasourceEnum = _ftry.CreateDataSourceEnumerator();
            DataTable _datasources = _datasourceEnum.GetDataSources();
            int _counter;
            for (_counter = 0; _counter <= _datasources.Rows.Count - 1; _counter++)
            {
                MessageBox.Show(_datasources.Rows[_counter]["ServiceName"].ToString ());
            }
        }
    }
}
