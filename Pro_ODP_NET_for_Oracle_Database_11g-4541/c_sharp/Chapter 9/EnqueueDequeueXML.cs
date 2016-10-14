using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Chapter_9
{
    public partial class EnqueueDequeueXML : Form
    {
        public EnqueueDequeueXML()
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
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.JobsXML", _connObj);
                    _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Set payload type to XML
                _queueObj.MessageType = OracleAQMessageType.Xml;
                // Create a new message object
                OracleAQMessage _msg = new OracleAQMessage();
                OracleXmlType _jobXML = new OracleXmlType(_connObj , "<JOB><JOBID>J1234</JOBID><JOBNAME>Feed Snuppy</JOBNAME></JOB>");
                _msg.Payload = _jobXML;
                // Enqueue the message
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.Enqueue(_msg);
                // Display the payload data that was enqueued
                MessageBox.Show("Payload Data : \n" + _jobXML.Value);
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
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.JobsXML", _connObj);
                // Set the payload type to XML
                _queueObj.MessageType = OracleAQMessageType.Xml;
                _connObj.Open();
                    OracleTransaction _txn = _connObj.BeginTransaction();
                // Dequeue the message.
                _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.DequeueOptions.Wait = 10;
                _queueObj.DequeueOptions.ProviderSpecificType = true;
                OracleAQMessage _deqMsg = _queueObj.Dequeue();
                OracleXmlType _jobXML = (OracleXmlType)_deqMsg.Payload;
                MessageBox.Show("Dequeued Payload Data: \n" + _jobXML.Value);
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
