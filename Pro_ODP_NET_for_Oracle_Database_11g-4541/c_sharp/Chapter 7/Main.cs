using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Transactions;

namespace Chapter_7
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
                OracleTransaction _tranObj;
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();

                //Clear the appropriate tables first
                _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='A01'";
                _cmdObj.ExecuteNonQuery();

                _tranObj = _connObj.BeginTransaction();
                try
                {
                    //Insert a record into the Invoice table
                    _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)";
                    _cmdObj.Parameters.Add(new OracleParameter("InvID", "A01"));
                    _cmdObj.Parameters.Add(new OracleParameter("Remarks", "Sample invoice"));
                    _cmdObj.ExecuteNonQuery();
                    MessageBox.Show("Invoice record created successfully");

                    //Intentionally cause an exception
                    _cmdObj.CommandText = "INSERT INTO NonExistentTable(InvID, Description, Quantity, UnitPrice) VALUES(:InvID, :Description, :Quantity, :UnitPrice)";
                    _cmdObj.Parameters.Clear();
                    _cmdObj.Parameters.Add(new OracleParameter("InvID", "A01"));
                    _cmdObj.Parameters.Add(new OracleParameter("Description", "Exhaust pipe"));
                    _cmdObj.Parameters.Add(new OracleParameter("Quantity", "5"));
                    _cmdObj.Parameters.Add(new OracleParameter("UnitPrice", "99.50"));
                    _cmdObj.ExecuteNonQuery();
                    _tranObj.Commit();
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Uh oh, rollback initiated...");
                    _tranObj.Rollback();
                }
                finally
                {
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleTransaction _tranObj;
                _connObj.Open();
                _tranObj = _connObj.BeginTransaction();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                try
                {
                _cmdObj.CommandText = "proc_InsertSamplePODetails";
                _cmdObj.CommandType = CommandType.StoredProcedure;
                _cmdObj.Parameters.Clear();
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Stored proc run successfully");

                //Intentionally cause an exception
                _cmdObj.CommandText = "INSERT INTO NonExistentTable(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)";
                _cmdObj.CommandType = CommandType.Text;
                _cmdObj.Parameters.Clear();
                _cmdObj.Parameters.Add(new OracleParameter("InvID", "A02"));
                _cmdObj.Parameters.Add(new OracleParameter("Remarks", "Sample invoice 2"));
                _cmdObj.ExecuteNonQuery();
                _tranObj.Commit();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uh oh, rollback initiated...");
                _tranObj.Rollback();
            }
            finally
            {
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleTransaction _tranObj;
                _connObj.Open();
                _tranObj = _connObj.BeginTransaction();
                OracleCommand _cmdObj = _connObj.CreateCommand();
                try
                {
                //Clear the appropriate tables first
                _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='A01'";
                _cmdObj.ExecuteNonQuery();
                _cmdObj.CommandText = "DELETE FROM InvoiceDetails WHERE InvID='A01'";
                _cmdObj.ExecuteNonQuery();

                _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)";
                _cmdObj.Parameters.Add(new OracleParameter("InvID", "A01"));
                _cmdObj.Parameters.Add(new OracleParameter("Remarks", "Sample invoice"));
                _cmdObj.ExecuteNonQuery();
                _tranObj.Save("MySavepoint1");
                MessageBox.Show("Invoice record created successfully");
                _cmdObj.CommandText = "INSERT INTO InvoiceDetails(InvID, Description, Quantity, UnitPrice) VALUES(:InvID, :Description, :Quantity, :UnitPrice)";
                _cmdObj.Parameters.Clear();
                _cmdObj.Parameters.Add(new OracleParameter("InvID", "A01"));
                _cmdObj.Parameters.Add(new OracleParameter("Description", "Exhaust pipe"));
                _cmdObj.Parameters.Add(new OracleParameter("Quantity", "5"));
                _cmdObj.Parameters.Add(new OracleParameter("UnitPrice", "99.50"));
                _cmdObj.ExecuteNonQuery();
                _tranObj.Save("MySavepoint2");
                MessageBox.Show("Invoicedetails record created successfully");
                _cmdObj.CommandText = "INSERT INTO NonExistentTable(InvID, Description, Quantity, UnitPrice) VALUES(:InvID, :Description, :Quantity, :UnitPrice)";
                _cmdObj.Parameters.Clear();
                _cmdObj.Parameters.Add(new OracleParameter("InvID", "B01"));
                _cmdObj.Parameters.Add(new OracleParameter("Description","Windshield wipers"));
                _cmdObj.Parameters.Add(new OracleParameter("Quantity", "20"));
                _cmdObj.Parameters.Add(new OracleParameter("UnitPrice", "25.50"));
                _cmdObj.ExecuteNonQuery();
                _tranObj.Save("MySavepoint3");
                _tranObj.Commit();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Uh oh, rollback (up to Savepoint1) initiated...");
                _tranObj.Rollback("MySavepoint1");
                _tranObj.Commit();
            }
            finally
            {
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (TransactionScope _ts = new TransactionScope())
            {
            try
            {
               
                //Connect to the first database instance
                string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();

                //Clear the appropriate tables
                _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='B01'";
                _cmdObj.ExecuteNonQuery();

                //Create a new record in the first database instance
                _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)";
                _cmdObj.Parameters.Add(new OracleParameter("InvID", "B01"));
                _cmdObj.Parameters.Add(new OracleParameter("Remarks", "Sample invoice"));
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Invoice record created in first database instance successfully");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                
                //Connect to the second database instance
                _connstring = "Data Source=localhost/SECONDDB;User Id=SYSTEM;Password=admin;";
                _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                _cmdObj = _connObj.CreateCommand();
                //Intentionally cause an exception
                _cmdObj.CommandText = "INSERT INTO NonExistentTable(ReceiptID, ReceiptDate, Remarks) VALUES(:ReceiptID, SYSDATE, :Remarks)";
                _cmdObj.Parameters.Add(new OracleParameter("ReceiptID", "R01"));
                _cmdObj.Parameters.Add(new OracleParameter("Remarks", "Sample receipt"));
                _cmdObj.ExecuteNonQuery();
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                _ts.Complete();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error encountered : The created Invoice record should now be rolled back automatically");
            }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CommittableTransaction _cmtTran = new CommittableTransaction();
            try
            {
                //Connect to the first database instance and create a new record in
                //the Invoice table
                string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = _connObj.CreateCommand();

                //Clear the appropriate tables
                _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='B01'";
                _cmdObj.ExecuteNonQuery();

                _connObj.EnlistTransaction(_cmtTran);
                _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)";
                _cmdObj.Parameters.Add(new OracleParameter("InvID", "B01"));
                _cmdObj.Parameters.Add(new OracleParameter("Remarks", "Sample invoice"));
                _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Invoice record inserted successfully");
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                //Connect to the second database instance and create a new record in
                //the Receipt table
                _connstring = "Data Source=localhost/SECONDDB;User Id=SYSTEM;Password=admin;";
                _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                _connObj.EnlistTransaction(_cmtTran);
                _cmdObj = _connObj.CreateCommand();
                _cmdObj.CommandText = "INSERT INTO Receipt(ReceiptID, ReceiptDate, Remarks) VALUES(:ReceiptID, SYSDATE, :Remarks)";
                _cmdObj.Parameters.Add(new OracleParameter("ReceiptID", "R01"));
                _cmdObj.Parameters.Add(new OracleParameter("Remarks", "Sample receipt"));
                _cmdObj.ExecuteNonQuery();
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                _cmtTran.Commit();
                
            }
            catch (Exception ex)
            {
                _cmtTran.Rollback();
                MessageBox.Show("Uh oh, rollback initiated...");
            }
        }
    }
}
