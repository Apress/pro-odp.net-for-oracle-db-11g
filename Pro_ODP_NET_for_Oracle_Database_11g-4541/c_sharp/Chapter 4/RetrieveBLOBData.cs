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
    public partial class RetrieveBLOBData : Form
    {
        public RetrieveBLOBData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //We first read the full contents of the file into a byte array
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleDataReader _rdrObj;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT FileAttachment FROM ProductFiles WHERE ProductID=:ProductID";
                _cmdObj.Parameters.Add(new OracleParameter("ProductID", txtProductID.Text));
                _rdrObj=_cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                {
                    if (_rdrObj.Read())
                    {
                        OracleBlob _blobObj =
                        _rdrObj.GetOracleBlob(_rdrObj.GetOrdinal("FileAttachment"));
                        picProductImage.Image = Image.FromStream(new System.IO.MemoryStream(_blobObj.Value));
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
