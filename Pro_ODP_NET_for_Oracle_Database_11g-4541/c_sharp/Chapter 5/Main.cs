

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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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
                " INSERT INTO Products(ID, NAME, PRICE," +
                " REMARKS) VALUES('B1', 'Brake Fluid'," +
                " 80.50, 'Inserted via PL/SQL');" +
                "END;";
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("New row added!");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateRecordViaAnonymousPLSQL _query = new UpdateRecordViaAnonymousPLSQL();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {   
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "BEGIN" +
                    " SELECT COUNT(*) INTO :1 FROM Products;" +
                    "END;";
                OracleParameter _countParam = new OracleParameter();
                _countParam.ParameterName = ":1";
                _countParam.OracleDbType = OracleDbType.Int32;
                _countParam.Direction = ParameterDirection.Output;
                _cmdObj.Parameters.Add(_countParam);
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Total number of records : " + _countParam.Value);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "proc_InsertProduct";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show ("Product inserted");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateRecordViaPLSQLStoredProc _query = new UpdateRecordViaPLSQLStoredProc();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "proc_RetrieveCount";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                OracleParameter _countParam = new OracleParameter();
                _countParam.ParameterName = "intRecordCount";
                _countParam.OracleDbType = OracleDbType.Int32;
                _countParam.Direction = ParameterDirection.Output;
                _cmdObj.Parameters.Add(_countParam);
                    _cmdObj.ExecuteNonQuery();
                MessageBox.Show ("Total number of records : " + _countParam.Value );
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                    _cmdObj.CommandText = "func_RetrieveCount";
                _cmdObj.CommandType = CommandType.StoredProcedure ;
                //Declare the return parameter
                OracleParameter _retValueParam = new OracleParameter();
                _retValueParam.ParameterName = "Any_name";
                _retValueParam.OracleDbType = OracleDbType.Int32;
                _retValueParam.Direction = ParameterDirection.ReturnValue;
                _cmdObj.Parameters.Add(_retValueParam);
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("The return value is :" + _retValueParam.Value.ToString());
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "ProductsPackage.proc_UpdateMultiplePrices";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                OracleParameter _priceParam = new OracleParameter();
                _priceParam.ParameterName = "ProdPrices";
                _priceParam.OracleDbType = OracleDbType.Decimal;
                _priceParam.Direction = ParameterDirection.Input;
                _priceParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Decimal [] decArray= new Decimal[3];
                decArray[0] = 100;
                decArray[1] = 300;
                decArray[2] = 500;
                _priceParam.Value = decArray;
                _cmdObj.Parameters.Add(_priceParam);
                OracleParameter _NameParam = new OracleParameter();
                _NameParam.ParameterName = "ProdNames";
                _NameParam.OracleDbType = OracleDbType.Varchar2;
                _NameParam.Direction = ParameterDirection.Input;
                _NameParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                String[] stringArray = new String[3];
                stringArray[0] = "Engine";
                stringArray[1] = "Windshield";
                stringArray[2] = "Rear Lights";
                _NameParam.Value = stringArray;
                _cmdObj.Parameters.Add(_NameParam);
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("All products updated!");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                }
            catch (Exception ex)
            {
            MessageBox.Show(ex.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "ProductsPackage.proc_GetAllProductNames";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                //Create an output parameter
                OracleParameter _NameParam = new OracleParameter();
                _NameParam.ParameterName = "ProdNames";
                _NameParam.OracleDbType = OracleDbType.Varchar2 ;
                _NameParam.Direction = ParameterDirection.Output;
                _NameParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //You must explicitly define the number of elements to return
                _NameParam.Size = 10;
                //Because you are retrieving an object with a variable size, you need to
                //define the size of the string returned. This size must be specified for
                //each element in the output result
                int[] intArray= new int[10];
                int _counter;
                for (_counter = 0; _counter < 10; _counter++) {intArray[_counter] = 255;}
                _NameParam.ArrayBindSize = intArray;
                //Execute the stored procedure
                _cmdObj.Parameters.Add(_NameParam);
                _cmdObj.ExecuteNonQuery();
                //For VARCHAR2 data types, an array of OracleString objects is returned
                String _result="";
                OracleString[] stringArray = (OracleString[])_NameParam.Value;
                for (_counter = 0; _counter <= stringArray.GetUpperBound(0); _counter++)
                {
                OracleString _outputString = stringArray[_counter];
                _result = _result + _outputString.Value + "\n";
                }
                MessageBox.Show("Product names are:\n" + _result);
                _connObj.Close();
                _connObj.Dispose();
                    _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "proc_DeleteProducts";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                //Instantiate the ProductVArray class and add two elements
                ProductVArray _products = new ProductVArray();
                _products.Array = new String[] { "B1", "C1" };
                //Create a UDT-based OracleParameter, and pass in the ProductVArray
                //object
                OracleParameter param = new OracleParameter();
                param.OracleDbType = OracleDbType.Object;
                param.Direction = ParameterDirection.Input;
                param.UdtTypeName = "EDZEHOO.PRODUCTVARRAY";
                param.Value = _products;
                _cmdObj.Parameters.Add(param);
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Records deleted successfully");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String _connString = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connString);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "proc_DeleteProducts";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                // Create a string array and populate it with the IDs of the Products you
                //wish to delete
                String[] _productsTable = new String[] { "E1", "W1" };
                //Create a parameter object and pass in the string array
                OracleParameter _productTblParam = new OracleParameter();
                _productTblParam.OracleDbType = OracleDbType.Array;
                _productTblParam.Direction = ParameterDirection.Input;
                _productTblParam.UdtTypeName = "EDZEHOO.PRODUCTNESTEDTABLE";
                _productTblParam.Value = _productsTable;
                _cmdObj.Parameters.Add(_productTblParam);
                _cmdObj.ExecuteNonQuery();
                
                MessageBox.Show("Records deleted successfully");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }

        private void button12_Click(object sender, EventArgs e)
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
                OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                //This should remind you of Chapter 4. We use an OracleDataReader object to
                //loop through the result set and display a summary of the retrieved
                //information in a popup message box
                    if (_rdrObj.HasRows)
                {
                while (_rdrObj.Read())
                {
                String _data="";
                _data = "ID:" + _rdrObj.GetString(_rdrObj.GetOrdinal("ID")) + "\n" +
                "Name:" + _rdrObj.GetString(_rdrObj.GetOrdinal("Name")) + "\n" +
                "Price:" + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Price"));
                MessageBox.Show(_data);
                }
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

        private void button13_Click(object sender, EventArgs e)
        {
            ReadingRefCursorUsingDataAdapter _query = new ReadingRefCursorUsingDataAdapter();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            RetrievingMultipleREFCursors _query = new RetrievingMultipleREFCursors();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = " proc_InsertProduct";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                //Instantiate your UDT class here and specify the data for your new record
                PRODUCTTYPE _product = new PRODUCTTYPE();
                _product.NAME = "SPARETYRE";
                _product.PRICE = 400;
                _product.ID = "Y1";
                //Declare a UDT-based parameter and pass the instantiated class into this
                //parameter
                OracleParameter param = new OracleParameter();
                param.OracleDbType = OracleDbType.Object;
                param.Direction = ParameterDirection.Input;
                param.UdtTypeName = "EDZEHOO.PRODUCTTYPE";
                param.Value = _product;
                _cmdObj.Parameters.Add(param);
                int result = _cmdObj.ExecuteNonQuery();
                if (result > 0)
                {
                MessageBox.Show("Product successfully added");
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

        private void button16_Click(object sender, EventArgs e)
        {
            HandlingCustomErrors _query = new HandlingCustomErrors();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }
     }
 }
