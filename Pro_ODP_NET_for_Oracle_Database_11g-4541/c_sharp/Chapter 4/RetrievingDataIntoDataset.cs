using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Chapter_4
{
    public partial class RetrievingDataIntoDataset : Form
    {
        public RetrievingDataIntoDataset()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                DataSet _ds = new DataSet();
                _connObj.Open();
                _sql = "SELECT * FROM Products";
                OracleDataAdapter _adapterObj = new OracleDataAdapter(_sql, _connObj);
                _adapterObj.Fill(_ds);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                dataGridView1.DataSource = _ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
