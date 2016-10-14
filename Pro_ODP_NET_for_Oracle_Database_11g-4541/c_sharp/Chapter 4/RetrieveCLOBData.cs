using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Chapter_4
{
    public partial class RetrieveCLOBData : Form
    {
        public RetrieveCLOBData()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //We first read the full contents of the file into a byte array
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleDataReader _rdrObj;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT Remarks FROM ProductFiles WHERE ProductID=:ProductID";
                _cmdObj.Parameters.Add(new OracleParameter("ProductID", txtProductID.Text));
                _rdrObj=_cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                {
                    if (_rdrObj.Read())
                    {
                    OracleClob _clobObj = _rdrObj.GetOracleClob(_rdrObj.GetOrdinal("Remarks"));
                    txtRemarks.Text = _clobObj.Value;
                    }
                }
                else
                {
                    MessageBox.Show("An item with the matching product ID was not found!");
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
    }
}
