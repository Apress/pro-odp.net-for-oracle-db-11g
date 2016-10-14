using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_9
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnqueueDequeueSimpleMsg _query = new EnqueueDequeueSimpleMsg();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnqueueDequeueMultipleMsg _query = new EnqueueDequeueMultipleMsg();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EnqueueMCQ _query = new EnqueueMCQ();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EnqueueDequeueUDT _query = new EnqueueDequeueUDT();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            EnqueueDequeueXML _query = new EnqueueDequeueXML();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DequeueSyncAsync _query = new DequeueSyncAsync();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }
    }
}
