using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Chapter_4
{
    public partial class InsertCLOBData : Form
    {
        public InsertCLOBData()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            int _recordsAffected;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "INSERT INTO ProductFiles(ProductID, Remarks) VALUES(:ProductID,:Remarks)";
                _cmdObj.Parameters.Add(new OracleParameter("ProductID", txtProductID.Text));
                OracleClob _clobObj = new OracleClob(_connObj);
                _clobObj.Write(txtRemarks.Text.ToCharArray(), 0, txtRemarks.Text.Length);
                _cmdObj.Parameters.Add(new OracleParameter("Remarks", _clobObj));
                _recordsAffected = _cmdObj.ExecuteNonQuery();
                if (_recordsAffected == 1) { MessageBox.Show("CLOB saved!"); }
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
