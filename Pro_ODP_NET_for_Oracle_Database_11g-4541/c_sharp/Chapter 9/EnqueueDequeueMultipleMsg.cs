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
    public partial class EnqueueDequeueMultipleMsg : Form
    {
        public EnqueueDequeueMultipleMsg()
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
                OracleAQQueue _queueObj = new OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE",
                _connObj);
                _connObj.Open();
                OracleTransaction _txn = _connObj.BeginTransaction();
                // Set payload type
                _queueObj.MessageType = OracleAQMessageType.Raw;
                // Create an array of OracleAQMessage objects
                OracleAQMessage[] _msgs = new OracleAQMessage[2];
                // Fill the array with strings
                String[] Data = new String[2];
                Data[0] = "HELLO, HOW ARE YOU!";
                Data[1] = "... AND WHAT'S YOUR NAME?";
                _msgs[0] = new OracleAQMessage(ConvertToByteArray(Data[0]));
                _msgs[1] = new OracleAQMessage(ConvertToByteArray(Data[1]));
                // Enqueue the message - take note that we're using the EnqueueArray
                // function now
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit;
                _queueObj.EnqueueArray(_msgs);
                // Display the payload data that was enqueued
                for (int i = 0; i < 2; i++)
                {
                MessageBox.Show("Payload Data : " + Data[i] + "\n" +
                "Payload Hex value : " +
                ConvertToHexString((byte[])_msgs[i].Payload) + "\n" +
                "Message ID : " + ConvertToHexString(_msgs[i].MessageId));
                }
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

        private void button2_Click(object sender, EventArgs e)
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
                _queueObj.DequeueOptions.ProviderSpecificType = true;
                // Dequeue the messages – take note that you can specify the number of
                // messages you wish to retrieve from the queue
                OracleAQMessage[] _deqMsgs = _queueObj.DequeueArray(2);
                for (int i = 0; i < _deqMsgs.Length ; i++)
                {
                    // If you enqueued a byte array, the dequeued object is an
                    // OracleBinary object. You can retrieve the byte array using the
                    // OracleBinary.Value property
                    OracleBinary _payload = (OracleBinary)_deqMsgs[i].Payload;
                    MessageBox.Show("Dequeued Payload Data: " +
                    ConvertFromByteArray(_payload.Value) + "\n"
                    + "Dequeued Payload Hex: " +
                    ConvertToHexString(_payload.Value) + "\n");
                }
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
