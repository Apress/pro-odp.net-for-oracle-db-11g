using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace Chapter_12
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Pooling=false";
            try
            {
                //Open and close connections 10 times without connection pooling enabled
                OracleConnection _connObj = new OracleConnection(_connstring);
                _stopwatch.Start();
                for (int i = 1; i <= 10; i++)
                {
                _connObj.Open();
                _connObj.Close();
                }
                _stopwatch.Stop();
                _Results = "Without connection pooling:\t" +
                    _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Open and close connections 10 times with connection pooling enabled
                _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Pooling=true";
                _connObj = new OracleConnection(_connstring);
                _stopwatch.Reset();
                _stopwatch.Start();
                for (int i = 1; i <= 10; i++)
                {
                    _connObj.Open();
                    _connObj.Close();
                }
                _stopwatch.Stop();
                _Results = _Results + "With connection pooling:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
                _connObj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                //Adding NUMBERs
                _cmdObj.CommandText = "DECLARE" +
                " Number1 NUMBER:=1;" +
                " Number2 NUMBER:=1;" +
                "BEGIN" +
                " FOR i IN 1 .. 1000000 LOOP" +
                " Number1:=Number1 + Number2;" +
                " END LOOP;" +
                "END;";
                _stopwatch.Start();
                _cmdObj.ExecuteNonQuery();
                _stopwatch.Stop();
                _Results = "Adding NUMBERs:\t" + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Adding BINARY_FLOAT numbers
                _cmdObj.CommandText = "DECLARE" +
                " BinaryFloat1 BINARY_FLOAT:=1;" +
                " BinaryFloat2 BINARY_FLOAT:=1;" +
                "BEGIN" +
                " FOR i IN 1 .. 1000000 LOOP" +
                " BinaryFloat1:=BinaryFloat1 + BinaryFloat2;" +
                " END LOOP;" +
                "END;";
                _stopwatch.Reset();
                _stopwatch.Start();
                _cmdObj.ExecuteNonQuery();
                _stopwatch.Stop();
                _Results = _Results + "Adding BINARY_FLOATs:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Adding BINARY_DOUBLE numbers
                _cmdObj.CommandText = "DECLARE" +
                " BinaryDouble1 BINARY_DOUBLE:=1;" +
                " BinaryDouble2 BINARY_DOUBLE:=1;" +
                "BEGIN" +
                " FOR i IN 1 .. 1000000 LOOP" +
                " BinaryDouble1:=BinaryDouble1 + " +
                " BinaryDouble2;" +
                " END LOOP;" +
                "END;";
                _stopwatch.Reset();
                _stopwatch.Start();
                _cmdObj.ExecuteNonQuery();
                _stopwatch.Stop();
                _Results = _Results + "Adding BINARY_DOUBLEs:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
                _connObj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                //Update 10,000 products in separate statements
                _stopwatch.Start();
                for (int i = 1; i <= 10000; i++)
                {
                    _cmdObj.CommandText = "UPDATE Products SET Name='Test" +
                    Convert.ToString(i) + "' WHERE ID='E1'";
                    _cmdObj.ExecuteNonQuery();
                }
                _stopwatch.Stop();
                _Results = "Without Batch SQL:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Update 10,000 products in batch
                _cmdObj.CommandText = "BEGIN" +
                " FOR i IN 1 .. 10000 LOOP" +
                " UPDATE Products SET Name='Test' || i WHERE"+
                " ID='E1';" +
                " END LOOP;" +
                "END;";
                _stopwatch.Reset();
                _stopwatch.Start();
                _cmdObj.ExecuteNonQuery();
                _stopwatch.Stop();
                _Results = _Results + "With Batch SQL:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
                _connObj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            try
            {
                //Retrieve 10,000 products with statement caching disabled
                //Setting a cache size of 0 automatically disables the statement cache
                String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Statement Cache Size=0;Self Tuning=false;";
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _stopwatch.Start();
                _cmdObj.CommandText = "SELECT * FROM Products WHERE ID=:IDValue";
                OracleParameter _paramObj =
                _cmdObj.Parameters.Add("IDValue",OracleDbType.Varchar2);
                for (int i = 1; i <= 10000; i++)
                {
                    _paramObj.Value = "E" + Convert.ToString(i);
                    OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                    _rdrObj.Dispose();
                }
                _stopwatch.Stop();
                _Results = "Without Statement Caching:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                _cmdObj.Dispose();
                _connObj.Close();
                
                //Retrieve 10,000 products with statement caching enabled
                _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Statement Cache Size=5;Self Tuning=false;";
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                _cmdObj = _connObj.CreateCommand();
                _stopwatch.Reset();
                _stopwatch.Start();
                _cmdObj.CommandText = "SELECT * FROM Products WHERE ID=:IDValue";
                _paramObj = _cmdObj.Parameters.Add("IDValue", OracleDbType.Varchar2);
                for (int i = 1; i <= 10000; i++)
                {
                    _paramObj.Value = "E" + Convert.ToString(i);
                    OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                    _rdrObj.Dispose();
                }
                _stopwatch.Stop();
                _Results = _Results + "With Statement Caching:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                _cmdObj.Dispose();
                _connObj.Close();
                MessageBox.Show(_Results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                //Clear the table
                OracleCommand _cmdDelObj = _connObj.CreateCommand();
                _cmdDelObj.CommandText = "DELETE FROM Products";
                _cmdDelObj.ExecuteNonQuery();
                //Perform 10,000 iterations, inserting 3 records in every iteration without
                //using bind arrays
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Price) VALUES(:ID, :Name, :Price)";
                OracleParameter _IDParam = new OracleParameter("ID", OracleDbType.Varchar2);
                _cmdObj.Parameters.Add(_IDParam);
                OracleParameter _nameParam = new OracleParameter("Name",
                OracleDbType.Varchar2);
                _cmdObj.Parameters.Add(_nameParam);
                OracleParameter _priceParam = new OracleParameter("Price",
                OracleDbType.Decimal);
                _cmdObj.Parameters.Add(_priceParam);
                _stopwatch.Start();
                for (int i = 1; i <= 10000; i++)
                {
                _IDParam.Value = "EN" + Convert.ToString(i);
                _nameParam.Value = "Engine" + Convert.ToString(i);
                _priceParam.Value = 100;
                _cmdObj.ExecuteNonQuery();
                    _IDParam.Value = "WS" + Convert.ToString(i);
                _nameParam.Value = "Windshield" + Convert.ToString(i);
                _priceParam.Value = 300;
                _cmdObj.ExecuteNonQuery();
                _IDParam.Value = "RL" + Convert.ToString(i);
                _nameParam.Value = "Rear Lights" + Convert.ToString(i);
                _priceParam.Value = 500;
                _cmdObj.ExecuteNonQuery();
                }
                _stopwatch.Stop();
                _Results = "Without bind arrays:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Clear the table again
                _cmdDelObj.ExecuteNonQuery();
                _cmdDelObj.Dispose();
                //Perform 10,000 iterations, inserting 3 records in every iteration using
                //bind arrays
                _cmdObj.ArrayBindCount = 3;
                _stopwatch.Reset ();
                _stopwatch.Start();
                for (int i = 1; i <= 10000; i++)
                {
                    int[] _priceArray = new int[3] { 100, 300, 500 };
                    String[] _nameArray = new String[3] { "Engine" + Convert.ToString(i), "Windshield" + Convert.ToString(i), "Rear Lights" + Convert.ToString(i) };
                    String[] _IDArray = new String[3] { "EN" + Convert.ToString(i), "WS" + Convert.ToString(i), "RL" + Convert.ToString(i) };
                    _IDParam.Value = _IDArray;
                    _nameParam.Value = _nameArray;
                    _priceParam.Value = _priceArray;
                    _cmdObj.ExecuteNonQuery();
                }
                _stopwatch.Stop();
                _cmdObj.Dispose();
                _Results = _Results + "With Bind Arrays:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                //Perform 1000 iterations, updating 3 records in each iteration without
                //using associative arrays
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "UPDATE Products SET Price = Price + :ProdPrice WHERE Name = :ProdName";
                OracleParameter _priceParam = new
                OracleParameter("ProdPrice",OracleDbType.Decimal);
                _cmdObj.Parameters.Add(_priceParam);
                OracleParameter _nameParam = new OracleParameter("ProdName", OracleDbType.Varchar2 );
                _cmdObj.Parameters.Add(_nameParam);
                _stopwatch.Start();
                for (int i = 1; i <= 1000; i++)
                {
                    _priceParam.Value = 100;
                    _nameParam.Value = "Engine";
                    _cmdObj.ExecuteNonQuery();
                    _priceParam.Value = 300;
                    _nameParam.Value = "Windshield";
                    _cmdObj.ExecuteNonQuery();
                    _priceParam.Value = 500;
                    _nameParam.Value = "Rear Lights";
                    _cmdObj.ExecuteNonQuery();
                }
                _stopwatch.Stop();
                _cmdObj.Dispose();
                _Results = "Without arrays:\t" + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Perform 1000 iterations, updating 3 records in each iteration using
                //associative arrays
                _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "ProductsPackage.proc_UpdateMultiplePrices";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                //Declare first parameter
                _priceParam = new OracleParameter();
                _priceParam.ParameterName = "ProdPrices";
                _priceParam.OracleDbType = OracleDbType.Decimal;
                _priceParam.Direction = ParameterDirection.Input;
                _priceParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                _cmdObj.Parameters.Add(_priceParam);
                    //Declare second parameter
                _nameParam = new OracleParameter();
                _nameParam.ParameterName = "ProdNames";
                _nameParam.OracleDbType = OracleDbType.Varchar2;
                _nameParam.Direction = ParameterDirection.Input;
                _nameParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                _cmdObj.Parameters.Add(_nameParam);
                _stopwatch.Reset();
                _stopwatch.Start();
                for (int i = 1; i <= 1000; i++)
                {
                    Decimal[] decArray = new Decimal[3];
                    decArray[0] = 100;
                    decArray[1] = 300;
                    decArray[2] = 500;
                    _priceParam.Value = decArray;
                    String[] stringArray = new String[3];
                    stringArray[0] = "Engine";
                    stringArray[1] = "Windshield";
                    stringArray[2] = "Rear Lights";
                    _nameParam.Value = stringArray;
                    _cmdObj.ExecuteNonQuery();
                }
                _stopwatch.Stop();
                _cmdObj.Dispose();
                _Results = _Results + "With Associative Arrays:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
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
            if (MessageBox.Show("This test will assume that a BLOB has been uploaded into the Products table for the product ID 'E1'. Please upload a BLOB if you have not. You can do so using the sample in Chapter 4. Would you like to proceed?","Notice",MessageBoxButtons.YesNo,MessageBoxIcon.Question ,MessageBoxDefaultButton.Button1  )== DialogResult.No ) return ;
            //We first read the full contents of the file into a byte array
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleDataReader _rdrObj;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                //Disable the Cache
                _cmdObj.CommandText = "ALTER TABLE ProductFiles MODIFY LOB(FileAttachment) (NOCACHE)";
                _cmdObj.ExecuteNonQuery();
                _cmdObj.CommandText = "SELECT FileAttachment FROM ProductFiles WHERE ProductID=:ProductID";
                _cmdObj.Parameters.Add(new OracleParameter("ProductID", "E1"));
                _stopwatch.Start();
                for (int i = 1; i <= 100; i++)
                {
                    _rdrObj = _cmdObj.ExecuteReader();
                    if (_rdrObj.HasRows)
                    {
                        if (_rdrObj.Read())
                        {
                            OracleBlob _blobObj =
                            _rdrObj.GetOracleBlob(_rdrObj.GetOrdinal
                            ("FileAttachment"));
                            byte[] dest = new byte[_blobObj.Length];
                            _blobObj.Read(dest, 0, (int)_blobObj.Length);
                        }
                    }
                    else
                    {
                    MessageBox.Show("The BLOB was not found!");
                    }
                }
                _stopwatch.Stop();
                _cmdObj.Dispose();
                _Results = "Without LOB caching:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Enable the Cache
                _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "ALTER TABLE ProductFiles MODIFY LOB(FileAttachment) (CACHE)";
                _cmdObj.ExecuteNonQuery();
                _cmdObj.CommandText = "SELECT FileAttachment FROM ProductFiles WHERE ProductID=:ProductID";
                _cmdObj.Parameters.Add(new OracleParameter("ProductID", "E1"));
                _stopwatch.Reset();
                _stopwatch.Start();
                for (int i = 1; i <= 100; i++)
                {
                    _rdrObj = _cmdObj.ExecuteReader();
                    if (_rdrObj.HasRows)
                    {
                        if (_rdrObj.Read())
                        {
                            OracleBlob _blobObj =
                            _rdrObj.GetOracleBlob(_rdrObj.GetOrdinal("FileAttachment"));
                            byte[] dest = new byte[_blobObj.Length];
                            _blobObj.Read(dest, 0, (int)_blobObj.Length);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The BLOB was not found!");
                    }
                }
                _stopwatch.Stop();
                _Results = _Results + "With LOB Caching:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
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
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                //Insert 10,000 dummy records into the Products table
                _cmdObj.CommandText = "DELETE FROM Products";
                _cmdObj.ExecuteNonQuery();
                for (int i = 1; i <= 10000; i++)
                {
                    _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Remarks) VALUES('E" + Convert.ToString(i) + "','TestData','')";                   _cmdObj.ExecuteNonQuery();
                }
                MessageBox.Show("10,000 products inserted");
                //Read all 10,000 products from the same table using the default FetchSize
                //of 64K
                _cmdObj.CommandText = "SELECT * FROM Products";
                _stopwatch.Start();
                OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                while (_rdrObj.Read()) { }
                _stopwatch.Stop();
                _Results = "Default Fetchsize (64Kb):\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Set the FetchSize to accommodate for 10,000 rows and execute the same
                //query again
                _stopwatch.Reset();
                _stopwatch.Start();
                _rdrObj = _cmdObj.ExecuteReader();
                long _newFetchSize = _rdrObj.RowSize * 10000;
                _rdrObj.FetchSize = _newFetchSize;
                while (_rdrObj.Read()) { }
                _stopwatch.Stop();
                _Results = _Results + "Fetchsize (" + Convert.ToString (_newFetchSize) +
                "):\t" + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
                _connObj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                //Insert 1,000 dummy records into the Products table
                _cmdObj.CommandText = "DELETE FROM Products";
                _cmdObj.ExecuteNonQuery();
                for (int i = 1; i <= 1000; i++)
                {
                _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Remarks) VALUES('E" + Convert.ToString(i) + "','TestData','')";
                _cmdObj.ExecuteNonQuery();
                }
                MessageBox.Show("1,000 products inserted");
                //Retrieve 1,000 rows without using the client result cache
                _cmdObj.CommandText = "SELECT * FROM Products";
                _stopwatch.Start();
                for (int i = 1; i <=1000; i++)
                {
                    OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                    while (_rdrObj.Read()) { }
                    _rdrObj.Close();
                }
                _stopwatch.Stop();
                _Results = "No client result cache:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                //Retrieve 1,000 rows using the client result cache
                _cmdObj.CommandText = "SELECT /*+ result_cache */ * FROM Products";
                _stopwatch.Reset();
                _stopwatch.Start();
                for (int i = 1; i <= 1000; i++)
                {
                    OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                    while (_rdrObj.Read()) { }
                    _rdrObj.Close();
                }
                _stopwatch.Stop();
                _Results = _Results + "With client result cache:\t" +
                _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                MessageBox.Show(_Results);
                _connObj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Stopwatch _stopwatch = new Stopwatch();
            String _Results;
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
              
                //Clear all products
                _cmdObj.CommandText = "DELETE FROM Products";
                _cmdObj.ExecuteNonQuery();


                _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Price) VALUES(:ID, :Name, :Price)";
                OracleParameter _IDParam = new OracleParameter("ID", OracleDbType.Varchar2);
                _cmdObj.Parameters.Add(_IDParam);
                OracleParameter _nameParam = new OracleParameter("Name", OracleDbType.Varchar2);
                _cmdObj.Parameters.Add(_nameParam);
                OracleParameter _priceParam = new OracleParameter("Price", OracleDbType.Decimal);
                _cmdObj.Parameters.Add(_priceParam);

                _stopwatch.Start();
                for (int i = 1; i <= 50000; i++)
                {
                    _IDParam.Value = "E" + Convert.ToString(i);
                    _nameParam.Value = "Test Product" + Convert.ToString(i);
                    _priceParam.Value = 100;
                    _cmdObj.ExecuteNonQuery();
                }
                _stopwatch.Stop();
                _cmdObj.Dispose();

                //Oracle Bulk Copy
                _Results = "Without Oracle Bulk Copy:\t" + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "DELETE FROM Products";
                _cmdObj.ExecuteNonQuery();
                _cmdObj.Dispose();


                DataTable _dataTbl = new DataTable("SourceTable");
                _dataTbl.Columns.Add(new DataColumn("ID", System.Type.GetType("System.String")));
                _dataTbl.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
                _dataTbl.Columns.Add(new DataColumn("Price", System.Type.GetType("System.String")));
                
                _stopwatch.Reset();
                _stopwatch.Start();
                for (int i = 1; i <= 50000; i++)
                {
                    DataRow _newrow = _dataTbl.NewRow();
                    _newrow["ID"] = "E" + Convert.ToString(i);
                    _newrow["Name"] = "Test Product" + Convert.ToString(i);
                    _newrow["Price"] = 100;
                    _dataTbl.Rows.Add(_newrow);
                }
                _stopwatch.Stop();

                OracleBulkCopy _bulkCopy = new OracleBulkCopy(_connObj);
                _bulkCopy.DestinationTableName = "Products";
                _stopwatch.Start();
                _bulkCopy.WriteToServer(_dataTbl);
                _stopwatch.Stop();
                _Results += "With Oracle Bulk Copy:\t" + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds\n";
                _bulkCopy.Close();
                _bulkCopy.Dispose();
                _bulkCopy = null;

                MessageBox.Show(_Results);
                _connObj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
