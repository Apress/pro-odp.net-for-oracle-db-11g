using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Chapter_4
{
    public partial class FormBinding : Form
    {
        OracleCommand _productsCmdObj = null;
        OracleCommand _productComponentsCmdObj = null;
        OracleDataAdapter _productsAdpObj = null;
        OracleDataAdapter _productComponentsAdpObj = null;
        private DataSet _ds = new DataSet();
        //In this example, we load the Product identified by the ID value of "E1"
        string _productID = "E1";

        public FormBinding()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            bsProducts.DataSource = _ds.Tables["Products"];
            txtName.DataBindings.Add(new Binding("Text",
            bsProducts, "Name", true));
            numPrice.DataBindings.Add(new Binding("Value",
            bsProducts, "Price", true));
            txtRemarks.DataBindings.Add(new Binding("Text",
            bsProducts, "Remarks", true));
            dgComponents.DataSource = _ds.Tables["ProductComponents"];
        }

        private void LoadData()
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _sql;
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                _ds = new DataSet();
                //Retrieve from the Products table
                _sql = "SELECT * FROM Products WHERE ID=:ID";
                _productsCmdObj = new OracleCommand(_sql, _connObj);
                _productsCmdObj.Parameters.Add(new OracleParameter("ID", _productID));
                _productsAdpObj = new OracleDataAdapter(_productsCmdObj);
                _productsAdpObj.Fill(_ds, "Products");
                //Retrieve from the ProductComponents table
                _sql = "SELECT * FROM ProductComponents WHERE ParentProductID=:ParentProductID";
                _productComponentsCmdObj = new OracleCommand(_sql, _connObj);
                _productComponentsCmdObj.Parameters.Add(new OracleParameter("ParentProductID", _productID));
                _productComponentsAdpObj = new OracleDataAdapter(_productComponentsCmdObj);
                _productComponentsAdpObj.Fill(_ds, "ProductComponents");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }       
               
        private void FormBinding_Load(object sender, EventArgs e)
        {
            //In this example, we load the Product identified by the ID value of "E1"
            LoadData();
            BindData();
        }
    }
}
