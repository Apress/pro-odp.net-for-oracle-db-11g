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
    public partial class InsertBFILE : Form
    {
        public InsertBFILE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFilename.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //We first read the full contents of the file into a byte array
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            int _recordsAffected;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "INSERT INTO ProductFiles(ProductID, FileAttachment2) VALUES(:ProductID,BFILENAME('PRODUCTFILESFOLDER',:FileName))";
                _cmdObj.Parameters.Add (new OracleParameter ("ProductID",txtProductID.Text));
                _cmdObj.Parameters.Add(new OracleParameter("FileName",System.IO.Path.GetFileName( txtFilename.Text)));
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

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
