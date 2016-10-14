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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _ID;
            string _name;
            decimal _price;
            string _remarks;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand ();
                _cmdObj.CommandText = "SELECT * FROM Products";
                OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                { 
                while (_rdrObj.Read())
                    {
                        _ID = _rdrObj.GetString(_rdrObj.GetOrdinal ("ID"));
                        _name = _rdrObj.GetString(_rdrObj.GetOrdinal ("Name"));
                        _price = _rdrObj.GetDecimal (_rdrObj.GetOrdinal ("Price"));
                        _remarks = _rdrObj.GetString(_rdrObj.GetOrdinal("Remarks"));
                        MessageBox.Show("ID: " + _ID + "\nName: " + _name + "\nPrice: " + _price + "\nRemarks: " + _remarks,"Products");
                    };
                };
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
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            decimal _totalRecords;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT COUNT(*) AS TotalRecords FROM Products";
                _totalRecords = (decimal)_cmdObj.ExecuteScalar();
                MessageBox.Show("Total records:" + _totalRecords);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RetrievingDataIntoDataset _query = new RetrievingDataIntoDataset();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ParameterizedQueries _query = new ParameterizedQueries();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string _connstring;
            _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            int _recordsAffected;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                //Insert a new record
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Price) VALUES(:ID,:Name,:Price)";
                _cmdObj.Parameters.Add (new OracleParameter ("ID","M1"));
                _cmdObj.Parameters.Add (new OracleParameter ("Name","Mudguards"));
                _cmdObj.Parameters.Add (new OracleParameter ("Price","250.50"));
                _recordsAffected=_cmdObj.ExecuteNonQuery();
                MessageBox.Show("Total records affected after insert:" + _recordsAffected);
                //Update an existing record
                _cmdObj.CommandText = "UPDATE Products SET Remarks=:Remarks WHERE ID=:ID";
                _cmdObj.Parameters.Clear();
                _cmdObj.Parameters.Add (new OracleParameter ("Remarks","Quality mudguards"));
                _cmdObj.Parameters.Add(new OracleParameter("ID", "M1"));
                _recordsAffected=_cmdObj.ExecuteNonQuery();
                MessageBox.Show("Total records affected after update:" + _recordsAffected);
                //Delete an existing record
                _cmdObj.CommandText = "DELETE FROM Products WHERE ID=:ID";
                _cmdObj.Parameters.Clear(); 
                _cmdObj.Parameters.Add(new OracleParameter("ID", "M1"));
                _recordsAffected = _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Total records affected after delete:" + _recordsAffected);
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
            CommittingChangesToDatabase _query = new CommittingChangesToDatabase();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            DataSet _ds = new DataSet();
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                _sql = "SELECT * FROM Products";
                OracleDataAdapter _adapterObj = new OracleDataAdapter(_sql, _connObj);
                _adapterObj.Fill(_ds);
                OracleCommandBuilder _commBldrObj = new OracleCommandBuilder(_adapterObj);
                //We must specify the unique column in the dataset so that the
                //OracleCommandBuilder knows which field to use as the primary key when
                //generating the UpdateCommand and DeleteCommand objects
                _ds.Tables[0].Columns["ID"].Unique = true;
                _adapterObj.Update(_ds);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                MessageBox.Show("Dataset committed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormBinding _query = new FormBinding();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //We first read the full contents of the file into a byte array
            InsertBLOBData _query = new InsertBLOBData();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RetrieveBLOBData _query = new RetrieveBLOBData();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            InsertCLOBData _query = new InsertCLOBData();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RetrieveCLOBData _query = new RetrieveCLOBData();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            InsertBFILE _query = new InsertBFILE();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            RetrieveBFile _query = new RetrieveBFile();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            int _recordsAffected;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                //Insert a new record
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "INSERT INTO GUIDTest(GUID, Name) VALUES(:GUID,:Name)";
                OracleParameter _rawObj = new OracleParameter("GUID", OracleDbType.Raw);
                _rawObj.Value = System.Guid.NewGuid().ToByteArray();
                _cmdObj.Parameters.Add(_rawObj);
                _cmdObj.Parameters.Add(new OracleParameter("Name", "Test1"));
                _recordsAffected = _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Total records affected after insert:" + _recordsAffected);
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
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            OracleDataReader _rdrObj;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                DataSet _ds = new DataSet();
                _connObj.Open();
                _sql = "SELECT GUID FROM GUIDTest";
                OracleCommand _cmdObj = new OracleCommand(_sql, _connObj);
                _rdrObj = _cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                {
                    if (_rdrObj.Read())
                    {
                        OracleBinary _binaryObj = _rdrObj.GetOracleBinary(_rdrObj.GetOrdinal("GUID"));
                        System.Guid _GUIDObj = new System.Guid(_binaryObj.Value);
                        MessageBox.Show("The GUID retrieved is: " + _GUIDObj.ToString());
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

        private void button17_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "ALTER TABLE PRODUCTS ADD (SPECIALREMARKS VARCHAR2(255))";
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("New column added!");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            DiscoverSchema _query = new DiscoverSchema();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            OracleDataReader _rdrObj;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                DataSet _ds = new DataSet();
                _connObj.Open();
                //Intentionally run an incorrect query
                _sql = "SELECT aaa FROM bbb WHERE ccc=ddd";
                OracleCommand _cmdObj = new OracleCommand(_sql, _connObj);
                _rdrObj = _cmdObj.ExecuteReader();
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Oracle Error Number: " + ex.Number + "\nSource: " +
                ex.Source + "\nData source: " + ex.DataSource + "\nProcedure: " +
                ex.Procedure + "\nMessage: " + ex.Message + "\nInnerException: " +
                ex.InnerException);
            }
        }
    }
}
