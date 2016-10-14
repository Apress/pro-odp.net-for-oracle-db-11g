using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Chapter_5
{
    public partial class UpdateRecordViaAnonymousPLSQL : Form
    {
        public UpdateRecordViaAnonymousPLSQL()
        {
            InitializeComponent();
        }

        private void UpdateRecordViaAnonymousPLSQL_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "BEGIN" +
                " UPDATE Products SET Price=Price + :1 " +
                " WHERE Name = :2;" +
                "END;";
                OracleParameter _PriceParam = new OracleParameter();
                _PriceParam.ParameterName = ":1";
                _PriceParam.OracleDbType = OracleDbType.Int32;
                _PriceParam.Direction = ParameterDirection.Input;
                _PriceParam.Value = numPriceIncrement.Value;
                _cmdObj.Parameters.Add(_PriceParam);
                OracleParameter _NameParam = new OracleParameter();
                _NameParam.ParameterName = ":2";
                _NameParam.OracleDbType = OracleDbType.Varchar2;
                _NameParam.Direction = ParameterDirection.Input;
                _NameParam.Value = txtProductName.Text;
                _cmdObj.Parameters.Add(_NameParam);
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Updating done!");
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
