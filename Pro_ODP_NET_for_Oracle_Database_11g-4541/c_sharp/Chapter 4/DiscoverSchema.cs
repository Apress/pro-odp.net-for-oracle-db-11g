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
    public partial class DiscoverSchema : Form
    {
        public DiscoverSchema()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connstring;
            _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            DataTable _dt = null;
            OracleConnection myconn = new OracleConnection(_connstring);
            myconn.Open();
            string[] restrictions = new string[3];
            //Here we initialize all restrictions to null – take note that null is different
            //from "". To make sure a restriction is not used, set it to null
            for (int _counter = 0; _counter < 3; _counter++) { restrictions[_counter] = null; }
            restrictions[0] = "EDZEHOO";
            restrictions[1] = "PRODUCTS";
            _dt = myconn.GetSchema("columns", restrictions);
            dataGridView1.DataSource = _dt;
        }
    }
}
