using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Chapter_6
{
    public partial class UpdatingDoubleByteData : Form
    {
        public UpdatingDoubleByteData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            int _recordsAffected;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "UPDATE Products SET RemarksInJapanese=:DblByteRemarks WHERE ID=:ProdID";
                _cmdObj.CommandType = CommandType.Text;
                OracleParameter _RemarksParam = new OracleParameter();
                _RemarksParam.ParameterName = "DblByteRemarks";
                _RemarksParam.OracleDbType = OracleDbType.NVarchar2;
                _RemarksParam.Direction = ParameterDirection.Input;
                _RemarksParam.Value = txtRemarks.Text;
                _cmdObj.Parameters.Add(_RemarksParam);
                OracleParameter _NameParam = new OracleParameter();
                _NameParam.ParameterName = "ProdID";
                _NameParam.OracleDbType = OracleDbType.Varchar2;
                _NameParam.Direction = ParameterDirection.Input;
                _NameParam.Value = txtProductID.Text;
                _cmdObj.Parameters.Add(_NameParam);
                _recordsAffected = _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Updating done!");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
