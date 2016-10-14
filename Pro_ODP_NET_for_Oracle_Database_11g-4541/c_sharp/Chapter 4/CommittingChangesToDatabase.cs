using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Chapter_4
{
    public partial class CommittingChangesToDatabase : Form
    {
        private DataSet _ds;
        public CommittingChangesToDatabase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _ds = new DataSet();
                _connObj.Open();
                _sql = "SELECT * FROM Products";
                OracleDataAdapter _adapterObj = new OracleDataAdapter(_sql, _connObj);
                _adapterObj.Fill(_ds);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                dataGridView1.DataSource = _ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _commandObj = _connObj.CreateCommand();
                OracleDataAdapter _adapterObj = new OracleDataAdapter(_commandObj);
                //Manually define the UPDATE command in the OracleDataAdapter
                _sql = "UPDATE Products SET Name=:Name, Price=:Price, Remarks=:Remarks WHERE ID=:ID";
                _adapterObj.UpdateCommand = new OracleCommand(_sql, _connObj);
                _adapterObj.UpdateCommand.Parameters.Add (new OracleParameter("Name", OracleDbType.Varchar2, 255, "Name"));
                _adapterObj.UpdateCommand.Parameters.Add (new OracleParameter("Price", OracleDbType.Decimal, 10, "Price"));
                _adapterObj.UpdateCommand.Parameters.Add (new OracleParameter("Remarks", OracleDbType.Varchar2, 4000, "Remarks"));
                _adapterObj.UpdateCommand.Parameters.Add (new OracleParameter("ID", OracleDbType.Varchar2, 10, "ID"));
                //Manually define the INSERT command in the OracleDataAdapter
                _sql = "INSERT INTO Products(Name, Price, Remarks, ID) VALUES(:Name, :Price, :Remarks, :ID)";
                _adapterObj.InsertCommand = new OracleCommand(_sql, _connObj);
                _adapterObj.InsertCommand.Parameters.Add(new OracleParameter("Name", OracleDbType.Varchar2, 255, "Name"));
                _adapterObj.InsertCommand.Parameters.Add(new OracleParameter("Price", OracleDbType.Decimal, 10, "Price"));
                _adapterObj.InsertCommand.Parameters.Add(new OracleParameter("Remarks",OracleDbType.Varchar2, 4000, "Remarks"));
                _adapterObj.InsertCommand.Parameters.Add(new OracleParameter("ID", OracleDbType.Varchar2, 10, "ID"));
                //Manually define the DELETE command in the OracleDataAdapter
                _sql = "DELETE FROM Products WHERE ID=:ID";
                _adapterObj.DeleteCommand = new OracleCommand(_sql, _connObj);
                _adapterObj.DeleteCommand.Parameters.Add(new OracleParameter("ID", OracleDbType.Varchar2, 10, "ID"));
                //Now we pass in the dataset to the DataAdapter and request it
                //to commit the changes to the database (using the command objects above)
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
    }
}
