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
    public partial class DequeueSyncAsync : Form
    {
        private static bool _notified = false;
        public DequeueSyncAsync()
        {
            InitializeComponent();
        }

        // Converts a byte array to a Hexadecimal string
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
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE", _connObj);
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Set payload type to RAW (byte array)
                _queueObj.MessageType = OracleAQMessageType.Raw;
                // Create a new message object
                OracleAQMessage _msg = new OracleAQMessage();
                String Data = "HELLO, HOW ARE YOU!";
                _msg.Payload = ConvertToByteArray(Data);
                //You can also attach additional custom data to a message via the
                //Correlation property
                _msg.Correlation = "MY ADDITIONAL MISC DATA";
                //The Visibility property OnCommit makes the enqueue part of a transaction
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                // Enqueue the message
                _queueObj.Enqueue(_msg);
                // Display the payload data that was enqueued
                MessageBox.Show("Payload Data : " + Data + "\n" +
                "Payload Hex value : " + ConvertToHexString((byte[])_msg.Payload) +
                "\n" + "Message ID : " + ConvertToHexString(_msg.MessageId) + "\n" +
                "Correlation : " + _msg.Correlation);
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
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE",
                _connObj);
                _connObj.Open();
                // The Listen function is a blocking call - it will wait
                // indefinitely until a message is received.
                _queueObj.Listen(null);
                // Once we're here this means a message has been detected in the queue.
                // We can now proceed to dequeue that message
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Dequeue the message.
                _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.DequeueOptions.Wait = 10;
                OracleAQMessage _deqMsg = _queueObj.Dequeue();
                MessageBox.Show("Dequeued Payload Data: " +
                ConvertFromByteArray((byte[])_deqMsg.Payload) + "\n"
                + "Dequeued Payload Hex: " +
                ConvertToHexString((byte[])_deqMsg.Payload) + "\n"
                + "Message ID of Dequeued Payload : " +
                ConvertToHexString(_deqMsg.MessageId) + "\n" +
                "Correlation : " + _deqMsg.Correlation);
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
        // Converts a byte array to a String
        static private String ConvertFromByteArray(byte[] Data)
        {
            StringBuilder _stringObj = new StringBuilder();
            for (int i = 0; i < Data.Length; i++)
            {
                _stringObj.Append((char)Data[i]);
            }
            return _stringObj.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                // Create a new queue object
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE", _connObj);
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.DequeueOptions.Wait = 10;
                    //Register the callback function
                _queueObj.MessageAvailable += new
                OracleAQMessageAvailableEventHandler(IncomingMessageCallback);
                _txn.Commit();
                MessageBox.Show("Notification registered. Entering loop...");
                // Loop while waiting for notification
                while (_notified == false)
                {
                System.Threading.Thread.Sleep(2000);
                }
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

        static void IncomingMessageCallback(object src, OracleAQMessageAvailableEventArgs arg)
        {
            try
            {
                MessageBox.Show("Notification Received...\n" +
                "QueueName : " + arg.QueueName + "\n" +
                "Notification Type : " + arg.NotificationType);
                _notified = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.ToString());
            }
        }
    }
}
