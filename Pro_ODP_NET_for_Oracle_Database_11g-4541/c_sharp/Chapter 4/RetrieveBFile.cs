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
    public partial class RetrieveBFile : Form
    {
        public RetrieveBFile()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //We first read the full contents of the file into a byte array
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            byte[] _fileContents;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleDataReader _rdrObj;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT FileAttachment2 FROM ProductFiles WHERE ProductID=:ProductID";
                _cmdObj.Parameters.Add(new OracleParameter("ProductID", txtProductID.Text));
                _rdrObj = _cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                {
                    if (_rdrObj.Read())
                    {
                        OracleBFile _bfileObj = _rdrObj.GetOracleBFile(_rdrObj.GetOrdinal("FileAttachment2"));
                        if (_bfileObj.FileExists)
                        {
                            _fileContents = _bfileObj.Value;
                            //_fileContents now holds the array of bytes //representing the BFILE
                            MessageBox.Show("The name of the file is: " + _bfileObj.FileName + "\nThe length of the file is :" + _bfileObj.Length);
                        }
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
