using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Chapter_6
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatingDoubleByteData _query = new UpdatingDoubleByteData();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _result;
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT RemarksInJapanese FROM Products"; 
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                _result = "Results:";
                if (_reader.HasRows)
                {
                while (_reader.Read())
                {
                    if (_reader.IsDBNull(_reader.GetOrdinal("RemarksInJapanese")) == false)
                    {
                        String _price = _reader.GetString(_reader.GetOrdinal("RemarksInJapanese"));
                        _result = _result + "\n" + _price.ToString();
                    }
                }
                }
                MessageBox.Show(_result);
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
       }

        private void button3_Click(object sender, EventArgs e)
        {
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleGlobalization info = OracleGlobalization.GetClientInfo();
                info.Language = "ITALIAN";
                _connObj.SetSessionInfo(info);
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT NonExistentField FROM Products";
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _result;
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleGlobalization info = OracleGlobalization.GetClientInfo();
                info.DateLanguage = "FINNISH";
                info.DateFormat = "DD-MON-YYYY";
                OracleGlobalization.SetThreadInfo(info);
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT ExpiryDate FROM Products ORDER BY ExpiryDate ASC";
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                _result = "Results:";
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        OracleDate _odate =
                        _reader.GetOracleDate(_reader.GetOrdinal("ExpiryDate"));
                        _result = _result + "\n" + _odate.ToString();
                    }
                }
                MessageBox.Show(_result);
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _result;
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleGlobalization info = OracleGlobalization.GetClientInfo();
                info.Currency = "¥";
                _connObj.SetSessionInfo(info);
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT TO_CHAR(Price,'L99G999D99') Price FROM Products WHERE Price IS NOT NULL";
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                _result = "Results:";
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        String _price = _reader.GetString
                        (_reader.GetOrdinal("Price"));
                        _result = _result + "\n" + _price;
                    }
                }
                MessageBox.Show(_result);
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _result;
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleGlobalization info = OracleGlobalization.GetClientInfo();
                info.ISOCurrency = "AUSTRALIA";
                _connObj.SetSessionInfo(info);
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT TO_CHAR(Price,'C99G999D99') Price FROM Products";
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                _result = "Results:";
                if (_reader.HasRows)
                {
                while (_reader.Read())
                {
                    String _price = _reader.GetString
                    (_reader.GetOrdinal("Price"));
                    _result = _result + "\n" + _price.ToString();
                    }
                }
                MessageBox.Show(_result);
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
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
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleGlobalization info = OracleGlobalization.GetClientInfo();
                info.Territory = "Hong Kong";
                info.TimeZone = "Asia/Hong_Kong";
                OracleGlobalization.SetThreadInfo(info);
                _connObj.SetSessionInfo(info);
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT LaunchDate AT LOCAL LaunchDateLocal FROM Products";
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                if (_reader.HasRows)
                {
                    if (_reader.Read())
                    {
                        OracleTimeStampTZ _launchDate = _reader.GetOracleTimeStampTZ
                        (_reader.GetOrdinal("LaunchDateLocal"));
                        MessageBox.Show(_launchDate.ToString ());
                    }
                }
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _result;
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT Name FROM Products ORDER BY Name ASC";
                OracleGlobalization info = OracleGlobalization.GetClientInfo();
                info.Sort = "SPANISH_M";
                _connObj.SetSessionInfo(info);
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                _result = "Results:";
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        String _Name = _reader.GetString
                        (_reader.GetOrdinal("Name"));
                        _result = _result + "\n" + _Name.ToString();
                    }
                }
                MessageBox.Show(_result);
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _result;
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleGlobalization info = OracleGlobalization.GetClientInfo();
                info.Territory = "Sweden";
                info.Language = "Swedish";
                OracleGlobalization.SetThreadInfo(info);
                _connObj.SetSessionInfo(info);
                OracleCommand _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "SELECT TO_CHAR(Price,'L99G999D99') PriceDefCurrency, TO_CHAR(Price,'U99G999D99') PriceDualCurrency, TO_CHAR(ExpiryDate,'DL') ExpiryDate FROM Products WHERE ID='E1'";
                OracleDataReader _reader = _cmdObj.ExecuteReader();
                if (_reader.HasRows)
                {
                    if (_reader.Read())
                    {
                        String _priceDefCurrency = _reader.GetString(_reader.GetOrdinal("PriceDefCurrency"));
                        String _priceDualCurrency = _reader.GetString(_reader.GetOrdinal("PriceDualCurrency"));
                        String _expiryDate = _reader.GetString(_reader.GetOrdinal("ExpiryDate"));
                        _result = _priceDefCurrency + "\n" + _priceDualCurrency + "\n" + _expiryDate;
                        MessageBox.Show(_result);
                    }
                }
                _reader.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _reader.Close();
                _connObj.Close();
                _reader = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection();
                _connObj.ConnectionString = _connstring;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                DataSet _datasetObj = new DataSet();
                _cmdObj.CommandText = "SELECT LaunchDate FROM Products WHERE LaunchDate IS NOT NULL";
                //Without safe mapping
                OracleDataAdapter _adapterObj = new OracleDataAdapter(_cmdObj);
                _adapterObj.Fill(_datasetObj);
                //Display the data type name and the data
                MessageBox.Show("Type:" + _datasetObj.Tables[0].Rows[0]["LaunchDate"].GetType().ToString () + "\nData:" + Convert.ToString(_datasetObj.Tables[0].Rows[0]["LaunchDate"]));
                //With safe mapping
                _datasetObj = new DataSet();
                _adapterObj.SafeMapping.Add("LAUNCHDATE", typeof(string));
                _adapterObj.Fill(_datasetObj);
                //Display the data type name and the data again
                MessageBox.Show("Type:" + _datasetObj.Tables[0].Rows[0]
                ["LaunchDate"].GetType().ToString () + "\nData:" + Convert.ToString
                (_datasetObj.Tables[0].Rows[0]["LaunchDate"]));
                _adapterObj.Dispose();
                _cmdObj.Dispose();
                _connObj.Dispose();
                _connObj.Close();
                _adapterObj = null;
                _connObj = null;
                _cmdObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
