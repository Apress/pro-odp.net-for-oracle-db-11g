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
    public partial class RetrievingMultipleREFCursors : Form
    {
        public RetrievingMultipleREFCursors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "ProductsPackage.proc_GetProductsInfo";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                //Create the REF cursor parameter for the products that are < $500
                OracleParameter _chpProdParam = new OracleParameter();
                _chpProdParam.ParameterName = "cheapProducts";
                _chpProdParam.OracleDbType = OracleDbType.RefCursor;
                _chpProdParam.Direction = ParameterDirection.Output;
                _cmdObj.Parameters.Add(_chpProdParam);
                //Create the REF cursor parameter for the products that are > $500
                OracleParameter _expProdParam = new OracleParameter();
                _expProdParam.ParameterName = "expensiveProducts";
                _expProdParam.OracleDbType = OracleDbType.RefCursor;
                _expProdParam.Direction = ParameterDirection.Output;
                _cmdObj.Parameters.Add(_expProdParam);
                OracleDataAdapter _adapterObj = new OracleDataAdapter(_cmdObj);
                DataSet _datasetObj = new DataSet();
                _adapterObj.Fill(_datasetObj);
                //The result sets are stored in separate Datatables in the same dataset
                dataGridView1.DataSource = _datasetObj.Tables[0];
                dataGridView2.DataSource = _datasetObj.Tables[1];
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
