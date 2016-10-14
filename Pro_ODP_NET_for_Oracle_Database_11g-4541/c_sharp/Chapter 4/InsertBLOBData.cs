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
    public partial class InsertBLOBData : Form
    {
        public InsertBLOBData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFilepath.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //We first read the full contents of the file into a byte array
            byte[] _fileContents = System.IO.File.ReadAllBytes(txtFilepath.Text);
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            int _recordsAffected;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "INSERT INTO ProductFiles(ProductID, FileAttachment) VALUES(:ProductID,:FileAttachment)";
                _cmdObj.Parameters.Add (new OracleParameter("ProductID",txtProductID.Text));
                OracleBlob _blob = new OracleBlob(_connObj);
                _blob.Write(_fileContents, 0, _fileContents.Length);
                _cmdObj.Parameters.Add(new OracleParameter ("FileAttachment",_blob));
                _recordsAffected = _cmdObj.ExecuteNonQuery();
                if (_recordsAffected == 1) { MessageBox.Show("File uploaded!"); }
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
