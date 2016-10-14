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
    public partial class EnqueueMCQ : Form
    {
        public EnqueueMCQ()
        {
            InitializeComponent();
        }

        static private String ConvertFromByteArray(byte[] Data)
        {
            StringBuilder _stringObj = new StringBuilder();
            for (int i = 0; i < Data.Length; i++)
            {
                _stringObj.Append((char)Data[i]);
            }
            return _stringObj.ToString();
        }

        static private string ConvertToHexString(byte[] Data)
        {
            StringBuilder _stringObj = new StringBuilder();
            for (int i = 0; i < Data.Length; i++)
            {
                _stringObj.Append((int.Parse(Data[i].ToString())).ToString("X"));
            }
            return _stringObj.ToString();
        }
        // Converts a String to a byte array
        static private byte[] ConvertToByteArray(String Data)
        {
            char[] _charArray = Data.ToCharArray();
            byte[] _byteArray = new byte[Data.Length];
            for (int i = 0; i < _charArray.Length; i++)
            {
                _byteArray[i] = (byte)_charArray[i];
            }
            return _byteArray;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                // Create a new queue object
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.JobsQueue", _connObj);
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Set payload type
                _queueObj.MessageType = OracleAQMessageType.Raw;
                // Create a new message object
                OracleAQMessage _msg = new OracleAQMessage();
                String Data = "HELLO, HOW ARE YOU!";
                _msg.Payload = ConvertToByteArray(Data);
                // Define the sender ID and enqueue the message
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _msg.SenderId = new OracleAQAgent("EDZEHOO");
                _queueObj.Enqueue(_msg);
                // Display the payload data that was enqueued
                MessageBox.Show("Payload Data : " + Data + "\n" +
                "Payload Hex value : " + ConvertToHexString((byte[])_msg.Payload) + "\n" +
                "Message ID : " + ConvertToHexString(_msg.MessageId));
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
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.JobsQueue", _connObj);
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Dequeue the message.
                _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.DequeueOptions.Wait = 10;
                // Here set the consumer name to the registered queue subscriber
                // This queue subscriber was registered when you setup the queue
                // in SQL*Plus
                _queueObj.DequeueOptions.ConsumerName = "JOHNDALY";
                OracleAQMessage _deqMsg = _queueObj.Dequeue();
                MessageBox.Show("Dequeued Payload Data: " + ConvertFromByteArray((byte[])_deqMsg.Payload) + "\n" + "Dequeued Payload Hex: " + ConvertToHexString((byte[])_deqMsg.Payload) + "\n" + "Message ID of Dequeued Payload : " + ConvertToHexString(_deqMsg.MessageId));
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

        private void button3_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                // Create a new queue object
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.JobsQueue", _connObj);
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Set payload type
                _queueObj.MessageType = OracleAQMessageType.Raw;
                // Create a new message object
                OracleAQMessage _msg = new OracleAQMessage();
                String Data = "HELLO, HOW ARE YOU!";
                _msg.Payload = ConvertToByteArray(Data);
                // Enqueue the message
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                // Register the subscriber at the message-level using the
                // OracleAQMessage.Recipients property
                OracleAQAgent[] agent = new OracleAQAgent[1];
                agent[0] = new OracleAQAgent("RONFRICKE");
                _msg.Recipients = agent;
                _msg.SenderId = new OracleAQAgent("EDZEHOO");
                _queueObj.Enqueue(_msg);
                // Display the payload data that was enqueued
                MessageBox.Show("Payload Data : " + Data + "\n" +
                "Payload Hex value : " + ConvertToHexString((byte[])_msg.Payload) + "\n" +
                "Message ID : " + ConvertToHexString(_msg.MessageId));
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
