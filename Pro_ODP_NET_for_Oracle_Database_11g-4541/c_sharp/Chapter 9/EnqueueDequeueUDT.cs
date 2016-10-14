using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Chapter_9
{
    public partial class EnqueueDequeueUDT : Form
    {
        public EnqueueDequeueUDT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                // Create a new queue object
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.SmallJobs", _connObj);
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Set the payload type to your UDT
                _queueObj.MessageType = OracleAQMessageType.Udt;
                _queueObj.UdtTypeName = "EDZEHOO.JOBS_TYPE";
                // Create a new message object
                OracleAQMessage _msg = new OracleAQMessage();
                // Create an instance of JobClass and pass it in as the payload for the // message
                JobClass _job = new JobClass();
                _job.JobID = "J1234";
                _job.JobName = "Feed Snuppy";
                _job.JobPrice = 15;
                _job.JobDescription = "Feed Rice Crispies twice a day";
                _msg.Payload = _job;
                // Enqueue the message
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.Enqueue(_msg);
                // Display the payload data that was enqueued
                MessageBox.Show("Payload Data : " + _job.ToString());
                _txn.Commit();
                _queueObj.Dispose();
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
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                // Create a new queue object
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.SmallJobs", _connObj);
                // Set the payload type to your UDT
                _queueObj.MessageType = OracleAQMessageType.Udt;
                _queueObj.UdtTypeName = "EDZEHOO.JOBS_TYPE";
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Dequeue the message.
                _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.DequeueOptions.Wait = 10;
                OracleAQMessage _deqMsg = _queueObj.Dequeue();
                JobClass _Data = (JobClass)_deqMsg.Payload;
                MessageBox.Show(_Data.ToString ());
                _txn.Commit();
                _queueObj.Dispose();
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
