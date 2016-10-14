using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Xml;

namespace Chapter_10
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
                _connObj.Open();
                string _sql = "SELECT INFO FROM PRODUCT_EXTRAINFO";
                OracleCommand _cmdObj = new OracleCommand(_sql, _connObj);
                OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                    while (_rdrObj.Read())
                    {
                        String _message = "";
                        String _regionalprices = "";
                        XmlReader _xmlRdr = _rdrObj.GetXmlReader
                        (_rdrObj.GetOrdinal("INFO"));
                        //Now that we have an XMLReader object, we create an XMLDocument
                        //object so that we can manipulate its elements
                        XmlDocument _xmlDoc = new XmlDocument();
                        _xmlDoc.Load(_xmlRdr);
                        XmlNode _xmlRoot = _xmlDoc.FirstChild;
                        XmlNode _xmlCategory = _xmlRoot.SelectSingleNode("CATEGORY");
                        XmlNode _xmlPerson = _xmlRoot.SelectSingleNode
                        ("PERSON_IN_CHARGE");
                        XmlNode _xmlRegionalPricing = _xmlRoot.SelectSingleNode
                        ("REGIONAL_PRICING");
                        for (int i = 0; i < _xmlRegionalPricing.ChildNodes.Count; i++)
                        {
                            XmlNode _xmlRegion = _xmlRegionalPricing.ChildNodes.Item(i);
                            if (_regionalprices.Length > 0) _regionalprices += ",";
                            _regionalprices += _xmlRegion.Name + " : " +
                            _xmlRegion.InnerText;
                        }
                        _message = "Category name:\t" + _xmlCategory.InnerText + "\n" +
                        "Person in charge:\t" + _xmlPerson.InnerText + "\n" +
                        "Regional Pricing:\t" + _regionalprices + "\n" +
                        "Raw XML:\n" + _xmlDoc.OuterXml;
                        MessageBox.Show(_message);
                    }
                _rdrObj.Close();
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
                _connObj.Open();
                string _sql = "SELECT INFO FROM PRODUCT_EXTRAINFO";
                string _message="";
                OracleCommand _cmdObj = new OracleCommand(_sql, _connObj);
                OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        OracleXmlType _oracleXmlType = _rdrObj.GetOracleXmlType(_rdrObj.GetOrdinal("INFO"));
                        if (!_oracleXmlType.IsNull)
                        {
                            string _xPath = "/PRODUCT/CATEGORY";
                            string _nsMap = null;
                            if (_oracleXmlType.IsExists(_xPath, _nsMap))
                            {
                                OracleXmlType _oracleXmlTypeNode = _oracleXmlType.Extract(_xPath, _nsMap);
                                if (!_oracleXmlTypeNode.IsEmpty)
                                {
                                    _message = "Category tag:\t" +
                                    _oracleXmlTypeNode.Value;
                                }
                            }
                            _message += "Raw XML:\n" + _oracleXmlType.Value;
                            MessageBox.Show(_message);
                        }
                    }
                }
                _rdrObj.Close();
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
                _connObj.Open();
                OracleCommand _cmdObj = new OracleCommand("proc_GetProdInfo", _connObj);
                _cmdObj.CommandType = CommandType.StoredProcedure;
                //Define the first parameter – we want to retrieve the XML info for the
                //product with the ID "E1"
                OracleParameter _ProductIDParam = new OracleParameter("ProductID",
                OracleDbType.Varchar2);
                _ProductIDParam.Value = "E1";
                _cmdObj.Parameters.Add(_ProductIDParam);
                //Define the output parameter that receives the XMLType data
                OracleParameter _ProductInfoParam = new OracleParameter("ProductInfo",
                OracleDbType.XmlType);
                _ProductInfoParam.Direction = ParameterDirection.Output;
                _cmdObj.Parameters.Add(_ProductInfoParam);
                _cmdObj.ExecuteNonQuery();
                OracleXmlType _returnValue = (OracleXmlType)_ProductInfoParam.Value;
                MessageBox.Show(_returnValue.Value);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                OracleCommand _cmdObj = new OracleCommand("proc_InsertProdInfo", _connObj);
                _cmdObj.CommandType = CommandType.StoredProcedure;
                //Define first input parameter
                OracleParameter _ProductIDParam = new OracleParameter("ProductID",
                OracleDbType.Varchar2);
                _ProductIDParam.Value = "W1";
                _cmdObj.Parameters.Add(_ProductIDParam);
                //Define the second input parameter
                OracleParameter _ProductInfoParam = new OracleParameter("ProductInfo",
                OracleDbType.XmlType);
                OracleXmlType _ProductInfoXML = new OracleXmlType(_connObj, "<PRODUCT><CATEGORY>Accessories</CATEGORY><PERSON_IN_CHARGE>Mary Sabbath</PERSON_IN_CHARGE><REGIONAL_PRICING><EASTASIA>3.00</EASTASIA><AMERICAS>8.00</AMERICAS></REGIONAL_PRICING></PRODUCT>");
                _ProductInfoParam.Value = _ProductInfoXML;
                _cmdObj.Parameters.Add(_ProductInfoParam);
                _cmdObj.ExecuteNonQuery();
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
                MessageBox.Show("Product inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                string _data = "";
                _data = "<PRODUCT xmlns=\"PRODUCT.xsd\">" +
                " <CATEGORY>Slipspace drives</CATEGORY>" +
                " <PERSON_IN_CHARGE>Fujikawa</PERSON_IN_CHARGE>" +
                " <REGIONAL_PRICING>" +
                " <EASTASIA>5000</EASTASIA>" +
                " <AMERICAS>8000</AMERICAS>" +
                " </REGIONAL_PRICING> " +
                "</PRODUCT>";
                OracleXmlType _oracleXmlType = new OracleXmlType(_connObj, _data);
                MessageBox.Show("Validation result is : " +
                _oracleXmlType.Validate("PRODUCT.xsd"));
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                _connObj.Open();
                string _sql = "SELECT INFO FROM PRODUCT_EXTRAINFO";
                OracleCommand _cmdObj = new OracleCommand(_sql, _connObj);
                OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        OracleXmlType _oracleXmlType =
                        _rdrObj.GetOracleXmlType(_rdrObj.GetOrdinal("INFO"));
                        string _xsl;
                        _xsl = "<?xml version=\"1.0\"?>" +
                        "<xsl:stylesheet version=\"1.0\" " +
                        " xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">" +
                        " <xsl:template match=\"/\">" +
                        " <ProductExtraInfo>" +
                        " <xsl:apply-templates select=\"PRODUCT\"/>" +
                        " </ProductExtraInfo>" +
                        " </xsl:template>" +
                        " <xsl:template match=\"PRODUCT\">" +
                        " <xsl:apply-templates select=\"CATEGORY\"/>" +
                        " <xsl:apply-templates select=\"REGIONAL_PRICING\"/>"+
                        " </xsl:template>" +
                        " <xsl:template match=\"CATEGORY\">" +
                        " <CategoryName>" +
                        " <xsl:value-of select=\".\"/>" +
                        " </CategoryName>" +
                        " </xsl:template>" +
                        " <xsl:template match=\"REGIONAL_PRICING\">" +
                        " <xsl:apply-templates select=\"EASTASIA\"/>" +
                        " <xsl:apply-templates select=\"AMERICAS\"/>" +
                        " </xsl:template>" +
                        " <xsl:template match=\"EASTASIA\">" +
                        " <EastAsianPrice>" +
                        " <xsl:value-of select=\".\"/>" +
                        " </EastAsianPrice>" +
                        " </xsl:template>" +
                        " <xsl:template match=\"AMERICAS\">" +
                        " <AmericanPrice>" +
                        " <xsl:value-of select=\".\"/>" +
                        " </AmericanPrice>" +
                        " </xsl:template>" +
                        "</xsl:stylesheet>";
                        OracleXmlType _transformedXML = _oracleXmlType.Transform(_xsl, "");
                        MessageBox.Show(_transformedXML.Value);
                    }
                }
                _rdrObj.Close();
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _xsltString = "";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleCommand _cmdObj = new OracleCommand("SELECT * FROM Products",
                _connObj);
                _connObj.Open();
                _cmdObj.BindByName = true;
                _cmdObj.XmlCommandType = OracleXmlCommandType.Query;
                _cmdObj.XmlQueryProperties.MaxRows = 2;
                _cmdObj.XmlQueryProperties.RootTag = "MYRECORDSET";
                _cmdObj.XmlQueryProperties.RowTag = "MYRECORD";
                //Define the XSL to transform the relational dataset to XML
                _xsltString = "<?xml version=\"1.0\"?>" +
                "<xsl:stylesheet version=\"1.0\" " +
                " xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">" +
                " <xsl:output encoding=\"utf-8\"/>\n" +
                " <xsl:template match=\"/\">" +
                " <Products>" +
                " <xsl:apply-templates select=\"MYRECORDSET\"/>" +
                " </Products>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYRECORDSET\">" +
                " <xsl:apply-templates select=\"MYRECORD\"/>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYRECORD\">" +
                " <Product>" +
                " <ID>" +
                " <xsl:value-of select=\"ID\"/>" +
                " </ID>" +
                " <Name>" +
                " <xsl:value-of select=\"NAME\"/>" +
                " </Name>" +
                " <Price>" +
                " <xsl:value-of select=\"PRICE\"/>" +
                " </Price>" +
                " <Remarks>" +
                " <xsl:value-of select=\"REMARKS\"/>" +
                " </Remarks>" +
                " </Product>" +
                " </xsl:template>" +
                "</xsl:stylesheet>";
                _cmdObj.XmlQueryProperties.Xslt = _xsltString;
                XmlReader xmlReader = _cmdObj.ExecuteXmlReader();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(xmlReader);
                MessageBox.Show(xmlDocument.OuterXml);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _xsltString = "";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleCommand _cmdObj = new OracleCommand("", _connObj);
                _connObj.Open();
                string[] _updColList = new string[4];
                _updColList[0] = "ID";
                _updColList[1] = "NAME";
                _updColList[2] = "PRICE";
                _updColList[3] = "REMARKS";
                //The XSL used to transform the incoming XML data into the raw XML format
                //that Oracle recognizes to perform the Insert.
                _xsltString = "<?xml version=\"1.0\"?>" +
                "<xsl:stylesheet version=\"1.0\" " +
                " xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">" +
                " <xsl:output encoding=\"utf-8\"/>\n" +
                " <xsl:template match=\"/\">" +
                " <RECORDSET>" +
                " <xsl:apply-templates select=\"MYPRODUCTS\"/>" +
                " </RECORDSET>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYPRODUCTS\">" +
                " <xsl:apply-templates select=\"MYPRODUCT\"/>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYPRODUCT\">" +
                " <RECORD>" +
                " <ID>" +
                " <xsl:value-of select=\"PROD_ID\"/>" +
                " </ID>" +
                " <NAME>" +
                " <xsl:value-of select=\"PROD_NAME\"/>" +
                " </NAME>" +
                " <PRICE>" +
                " <xsl:value-of select=\"PROD_PRICE\"/>" +
                " </PRICE>" +
                " <REMARKS>" +
                " <xsl:value-of select=\"PROD_REMARKS\"/>" +
                " </REMARKS>" +
                " </RECORD>" +
                " </xsl:template>" +
                "</xsl:stylesheet>";
                    _cmdObj.BindByName = true;
                _cmdObj.XmlCommandType = OracleXmlCommandType.Insert;
                _cmdObj.XmlSaveProperties.RowTag = "RECORD";
                _cmdObj.XmlSaveProperties.Table = "PRODUCTS";
                _cmdObj.XmlSaveProperties.KeyColumnsList = null;
                _cmdObj.XmlSaveProperties.UpdateColumnsList = _updColList;
                _cmdObj.XmlSaveProperties.Xslt = _xsltString;
                //Declare two records in XML to insert
                _cmdObj.CommandText = "<?xml version=\"1.0\"?>\n" +
                "<MYPRODUCTS>\n" +
                " <MYPRODUCT>\n" +
                " <PROD_ID>G1</PROD_ID>\n" +
                " <PROD_NAME>Grille</PROD_NAME>\n" +
                " <PROD_PRICE>30.20</PROD_PRICE>\n" +
                " <PROD_REMARKS>The front grille of the car</PROD_REMARKS>\n" +
                " </MYPRODUCT>\n" +
                " <MYPRODUCT>\n" +
                " <PROD_ID>M1</PROD_ID>\n" +
                " <PROD_NAME>Mirrors</PROD_NAME>\n" +
                " <PROD_PRICE>50.50</PROD_PRICE>\n" +
                " <PROD_REMARKS>Front mirrors of the car</PROD_REMARKS>\n" +
                " </MYPRODUCT>\n" +
                "</MYPRODUCTS>";
                int _result = _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Rows Inserted:" + _result);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _xsltString = "";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleCommand _cmdObj = new OracleCommand("", _connObj);
                _connObj.Open();
                // Set the Update Column List
                string[] _updColList = new string[2];
                _updColList[0] = "NAME";
                _updColList[1] = "PRICE";
                // Set the Key List
                string[] _keyColList = new string[1];
                _keyColList[0] = "ID";
                _xsltString = "<?xml version=\"1.0\"?>" +
                "<xsl:stylesheet version=\"1.0\" " +
                " xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">" +
                " <xsl:output encoding=\"utf-8\"/>\n" +
                " <xsl:template match=\"/\">" +
                " <RECORDSET>" +
                " <xsl:apply-templates select=\"MYPRODUCTS\"/>" +
                " </RECORDSET>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYPRODUCTS\">" +
                " <xsl:apply-templates select=\"MYPRODUCT\"/>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYPRODUCT\">" +
                " <RECORD>" +
                " <ID>" +
                " <xsl:value-of select=\"PROD_ID\"/>" +
                " </ID>" +
                " <NAME>" +
                " <xsl:value-of select=\"PROD_NAME\"/>" +
                " </NAME>" +
                " <PRICE>" +
                " <xsl:value-of select=\"PROD_PRICE\"/>" +
                " </PRICE>" +
                " <REMARKS>" +
                " <xsl:value-of select=\"PROD_REMARKS\"/>" +
                " </REMARKS>" +
                " </RECORD>" +
                " </xsl:template>" +
                "</xsl:stylesheet>";
                _cmdObj.BindByName = true;
                _cmdObj.XmlCommandType = OracleXmlCommandType.Update ;
                _cmdObj.XmlSaveProperties.RowTag = "RECORD";
                _cmdObj.XmlSaveProperties.Table = "PRODUCTS";
                _cmdObj.XmlSaveProperties.KeyColumnsList = _keyColList;
                _cmdObj.XmlSaveProperties.UpdateColumnsList = _updColList;
                    _cmdObj.XmlSaveProperties.Xslt = _xsltString;
                //Notice that you don’t have to include all the fields – only the fields you
                //wish to update (together with the record identifiers)
                _cmdObj.CommandText = "<?xml version=\"1.0\"?>\n" +
                "<MYPRODUCTS>\n" +
                " <MYPRODUCT>\n" +
                " <PROD_ID>G1</PROD_ID>\n" +
                " <PROD_NAME>Grille Revision 2</PROD_NAME>\n" +
                " <PROD_PRICE>50.00</PROD_PRICE>\n" +
                " </MYPRODUCT>\n" +
                " <MYPRODUCT>\n" +
                " <PROD_ID>M1</PROD_ID>\n" +
                " <PROD_NAME>Titanium Enforced Mirror</PROD_NAME>\n" +
                " <PROD_PRICE>60.50</PROD_PRICE>\n" +
                " </MYPRODUCT>\n" +
                "</MYPRODUCTS>";
                int _result = _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Rows Updated:" + _result);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            string _xsltString = "";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleCommand _cmdObj = new OracleCommand("", _connObj);
                _connObj.Open();
                // Define the Key Columns List
                string[] _keyColList = new string[1];
                _keyColList[0] = "ID";
                _xsltString = "<?xml version=\"1.0\"?>" +
                "<xsl:stylesheet version=\"1.0\" " +
                " xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">" +
                " <xsl:output encoding=\"utf-8\"/>\n" +
                " <xsl:template match=\"/\">" +
                " <RECORDSET>" +
                " <xsl:apply-templates select=\"MYPRODUCTS\"/>" +
                " </RECORDSET>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYPRODUCTS\">" +
                " <xsl:apply-templates select=\"MYPRODUCT\"/>" +
                " </xsl:template>" +
                " <xsl:template match=\"MYPRODUCT\">" +
                " <RECORD>" +
                " <ID>" +
                " <xsl:value-of select=\"PROD_ID\"/>" +
                " </ID>" +
                " <NAME>" +
                " <xsl:value-of select=\"PROD_NAME\"/>" +
                " </NAME>" +
                " <PRICE>" +
                " <xsl:value-of select=\"PROD_PRICE\"/>" +
                " </PRICE>" +
                " <REMARKS>" +
                " <xsl:value-of select=\"PROD_REMARKS\"/>" +
                " </REMARKS>" +
                " </RECORD>" +
                " </xsl:template>" +
                "</xsl:stylesheet>";
                    _cmdObj.BindByName = true;
                _cmdObj.XmlCommandType = OracleXmlCommandType.Delete;
                _cmdObj.XmlSaveProperties.RowTag = "RECORD";
                _cmdObj.XmlSaveProperties.Table = "PRODUCTS";
                _cmdObj.XmlSaveProperties.KeyColumnsList = _keyColList;
                _cmdObj.XmlSaveProperties.UpdateColumnsList = null;
                _cmdObj.XmlSaveProperties.Xslt = _xsltString;
                //Define the records to delete. Only the record identifier field is needed
                _cmdObj.CommandText = "<?xml version=\"1.0\"?>\n" +
                "<MYPRODUCTS>\n" +
                " <MYPRODUCT>\n" +
                " <PROD_ID>G1</PROD_ID>\n" +
                " </MYPRODUCT>\n" +
                " <MYPRODUCT>\n" +
                " <PROD_ID>M1</PROD_ID>\n" +
                " </MYPRODUCT>\n" +
                "</MYPRODUCTS>";
                int _result = _cmdObj.ExecuteNonQuery();
                MessageBox.Show("Rows Deleted:" + _result);
                _connObj.Close();
                _connObj.Dispose();
                _connObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;";
            try
            {
                OracleConnection _connObj = new OracleConnection(_connstring);
                OracleCommand _cmdObj = new OracleCommand("", _connObj);
                _connObj.Open();
                _cmdObj.CommandType = CommandType.Text;
                string _sql;
                _sql = "SELECT XMLQuery('" +
                "for $i in ora:view(\"PRODUCT_EXTRAINFO\") " +
                "where $i/ROW/INFO/PRODUCT/CATEGORY = $MyID " +
                "return $i' " +
                "PASSING :MyID AS \"MyID\" RETURNING CONTENT) " +
                "FROM DUAL";
                _cmdObj.CommandText = _sql;
                //Pass in “Engines” as the category to search for
                _cmdObj.Parameters.Add("MyID", OracleDbType.Varchar2, "Engines",
                ParameterDirection.Input);
                    OracleDataReader _rdrObj = _cmdObj.ExecuteReader();
                _rdrObj.Read();
                OracleXmlType xml = _rdrObj.GetOracleXmlType(0);
                MessageBox.Show(xml.Value);
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
