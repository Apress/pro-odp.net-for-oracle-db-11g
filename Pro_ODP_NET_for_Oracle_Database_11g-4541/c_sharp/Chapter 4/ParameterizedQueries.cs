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
    public partial class ParameterizedQueries : Form
    {
        public ParameterizedQueries()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            OracleDataReader _rdrObj;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                DataSet _ds = new DataSet();
                _connObj.Open();
                _sql = "SELECT * FROM Products WHERE ID=:IDValue";
                OracleCommand _cmdObj = new OracleCommand(_sql, _connObj);
                OracleParameter _idParam = _cmdObj.CreateParameter();
                _idParam.ParameterName = "IDValue";
                _idParam.OracleDbType = OracleDbType.Varchar2;
                _idParam.Value = txtID.Text;
                _cmdObj.Parameters.Add(_idParam);
                _rdrObj = _cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                {
                    if (_rdrObj.Read())
                    {
                        txtName.Text = _rdrObj.GetString(_rdrObj.GetOrdinal("Name"));
                        txtRemarks.Text = _rdrObj.GetString(_rdrObj.GetOrdinal("Remarks"));
                        numPrice.Value = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Price"));
                    }
                } 
                else
                {
                    MessageBox.Show("A record with a matching ID was not found");
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
