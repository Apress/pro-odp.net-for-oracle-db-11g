using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;


namespace Chapter_5
{
    public partial class ReadingRefCursorUsingDataAdapter : Form
    {
        public ReadingRefCursorUsingDataAdapter()
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
                OracleParameter _RefParam = new OracleParameter();
                _RefParam.ParameterName = "ProdInfo";
                _RefParam.OracleDbType = OracleDbType.RefCursor;
                _RefParam.Direction = ParameterDirection.Output;
                _cmdObj.Parameters.Add(_RefParam);
                OracleDataAdapter _adapterObj = new OracleDataAdapter(_cmdObj);
                DataSet _datasetObj = new DataSet();
                _adapterObj.Fill(_datasetObj);
                dataGridView1.DataSource = _datasetObj.Tables[0];
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
