using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_8
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryBasedChangeNotification _query = new QueryBasedChangeNotification();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ObjectBasedChangeNotification _query = new ObjectBasedChangeNotification();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeNotificationInformation _query = new ChangeNotificationInformation();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PollForChanges _query = new PollForChanges();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelfUpdatingDatagrid _query = new SelfUpdatingDatagrid();
            _query.ShowDialog();
            _query.Dispose();
            _query = null;
        }
    }
}
