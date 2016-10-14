Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System.Xml


Namespace Chapter_10
End Namespace 'Chapter_10
 _
Class Main
    Inherits Form
    '
    'ToDo: Error processing original source shown below
    '
    '
    '------------^--- 'class', 'struct', 'interface' or 'delegate' expected
    '
    'ToDo: Error processing original source shown below
    '
    '
    '--------------------^--- Syntax error: ';' expected
    Public Sub New()
        InitializeComponent()
    End Sub 'New


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _sql As String = "SELECT INFO FROM PRODUCT_EXTRAINFO"
            Dim _cmdObj As New OracleCommand(_sql, _connObj)
            Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
            While _rdrObj.Read()
                Dim _message As [String] = ""
                Dim _regionalprices As [String] = ""
                Dim _xmlRdr As XmlReader = _rdrObj.GetXmlReader(_rdrObj.GetOrdinal("INFO"))
                'Now that we have an XMLReader object, we create an XMLDocument
                'object so that we can manipulate its elements
                Dim _xmlDoc As New XmlDocument()
                _xmlDoc.Load(_xmlRdr)
                Dim _xmlRoot As XmlNode = _xmlDoc.FirstChild
                Dim _xmlCategory As XmlNode = _xmlRoot.SelectSingleNode("CATEGORY")
                Dim _xmlPerson As XmlNode = _xmlRoot.SelectSingleNode("PERSON_IN_CHARGE")
                Dim _xmlRegionalPricing As XmlNode = _xmlRoot.SelectSingleNode("REGIONAL_PRICING")
                Dim i As Integer
                For i = 0 To _xmlRegionalPricing.ChildNodes.Count - 1
                    Dim _xmlRegion As XmlNode = _xmlRegionalPricing.ChildNodes.Item(i)
                    If _regionalprices.Length > 0 Then
                        _regionalprices += ","
                    End If
                    _regionalprices += _xmlRegion.Name + " : " + _xmlRegion.InnerText
                Next i
                _message = "Category name:" + ControlChars.Tab + _xmlCategory.InnerText + ControlChars.Lf + "Person in charge:" + ControlChars.Tab + _xmlPerson.InnerText + ControlChars.Lf + "Regional Pricing:" + ControlChars.Tab + _regionalprices + ControlChars.Lf + "Raw XML:" + ControlChars.Lf + _xmlDoc.OuterXml
                MessageBox.Show(_message)
            End While
            _rdrObj.Close()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _sql As String = "SELECT INFO FROM PRODUCT_EXTRAINFO"
            Dim _message As String = ""
            Dim _cmdObj As New OracleCommand(_sql, _connObj)
            Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
            If _rdrObj.HasRows Then
                While _rdrObj.Read()
                    Dim _oracleXmlType As OracleXmlType = _rdrObj.GetOracleXmlType(_rdrObj.GetOrdinal("INFO"))
                    If Not _oracleXmlType.IsNull Then
                        Dim _xPath As String = "/PRODUCT/CATEGORY"
                        Dim _nsMap As String = Nothing
                        If _oracleXmlType.IsExists(_xPath, _nsMap) Then
                            Dim _oracleXmlTypeNode As OracleXmlType = _oracleXmlType.Extract(_xPath, _nsMap)
                            If Not _oracleXmlTypeNode.IsEmpty Then
                                _message = "Category tag:" + ControlChars.Tab + _oracleXmlTypeNode.Value
                            End If
                        End If
                        _message += "Raw XML:" + ControlChars.Lf + _oracleXmlType.Value
                        MessageBox.Show(_message)
                    End If
                End While
            End If
            _rdrObj.Close()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As New OracleCommand("proc_GetProdInfo", _connObj)
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Define the first parameter – we want to retrieve the XML info for the
            'product with the ID "E1"
            Dim _ProductIDParam As New OracleParameter("ProductID", OracleDbType.Varchar2)
            _ProductIDParam.Value = "E1"
            _cmdObj.Parameters.Add(_ProductIDParam)
            'Define the output parameter that receives the XMLType data
            Dim _ProductInfoParam As New OracleParameter("ProductInfo", OracleDbType.XmlType)
            _ProductInfoParam.Direction = ParameterDirection.Output
            _cmdObj.Parameters.Add(_ProductInfoParam)
            _cmdObj.ExecuteNonQuery()
            Dim _returnValue As OracleXmlType = CType(_ProductInfoParam.Value, OracleXmlType)
            MessageBox.Show(_returnValue.Value)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button3_Click


    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As New OracleCommand("proc_InsertProdInfo", _connObj)
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Define first input parameter
            Dim _ProductIDParam As New OracleParameter("ProductID", OracleDbType.Varchar2)
            _ProductIDParam.Value = "W1"
            _cmdObj.Parameters.Add(_ProductIDParam)
            'Define the second input parameter
            Dim _ProductInfoParam As New OracleParameter("ProductInfo", OracleDbType.XmlType)
            Dim _ProductInfoXML As New OracleXmlType(_connObj, "<PRODUCT><CATEGORY>Accessories</CATEGORY><PERSON_IN_CHARGE>Mary Sabbath</PERSON_IN_CHARGE><REGIONAL_PRICING><EASTASIA>3.00</EASTASIA><AMERICAS>8.00</AMERICAS></REGIONAL_PRICING></PRODUCT>")
            _ProductInfoParam.Value = _ProductInfoXML
            _cmdObj.Parameters.Add(_ProductInfoParam)
            _cmdObj.ExecuteNonQuery()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            MessageBox.Show("Product inserted")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button4_Click


    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _data As String = ""
            _data = "<PRODUCT xmlns=""PRODUCT.xsd"">" + " <CATEGORY>Slipspace drives</CATEGORY>" + " <PERSON_IN_CHARGE>Fujikawa</PERSON_IN_CHARGE>" + " <REGIONAL_PRICING>" + " <EASTASIA>5000</EASTASIA>" + " <AMERICAS>8000</AMERICAS>" + " </REGIONAL_PRICING> " + "</PRODUCT>"
            Dim _oracleXmlType As New OracleXmlType(_connObj, _data)
            MessageBox.Show(("Validation result is : " + _oracleXmlType.Validate("PRODUCT.xsd")))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button5_Click


    Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _sql As String = "SELECT INFO FROM PRODUCT_EXTRAINFO"
            Dim _cmdObj As New OracleCommand(_sql, _connObj)
            Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
            If _rdrObj.HasRows Then
                While _rdrObj.Read()
                    Dim _oracleXmlType As OracleXmlType = _rdrObj.GetOracleXmlType(_rdrObj.GetOrdinal("INFO"))
                    Dim _xsl As String
                    _xsl = "<?xml version=""1.0""?>" + "<xsl:stylesheet version=""1.0"" " + " xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">" + " <xsl:template match=""/"">" + " <ProductExtraInfo>" + " <xsl:apply-templates select=""PRODUCT""/>" + " </ProductExtraInfo>" + " </xsl:template>" + " <xsl:template match=""PRODUCT"">" + " <xsl:apply-templates select=""CATEGORY""/>" + " <xsl:apply-templates select=""REGIONAL_PRICING""/>" + " </xsl:template>" + " <xsl:template match=""CATEGORY"">" + " <CategoryName>" + " <xsl:value-of select="".""/>" + " </CategoryName>" + " </xsl:template>" + " <xsl:template match=""REGIONAL_PRICING"">" + " <xsl:apply-templates select=""EASTASIA""/>" + " <xsl:apply-templates select=""AMERICAS""/>" + " </xsl:template>" + " <xsl:template match=""EASTASIA"">" + " <EastAsianPrice>" + " <xsl:value-of select="".""/>" + " </EastAsianPrice>" + " </xsl:template>" + " <xsl:template match=""AMERICAS"">" + " <AmericanPrice>" + " <xsl:value-of select="".""/>" + " </AmericanPrice>" + " </xsl:template>" + "</xsl:stylesheet>"
                    Dim _transformedXML As OracleXmlType = _oracleXmlType.Transform(_xsl, "")
                    MessageBox.Show(_transformedXML.Value)
                End While
            End If
            _rdrObj.Close()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button6_Click


    Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _xsltString As String = ""
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _cmdObj As New OracleCommand("SELECT * FROM Products", _connObj)
            _connObj.Open()
            _cmdObj.BindByName = True
            _cmdObj.XmlCommandType = OracleXmlCommandType.Query
            _cmdObj.XmlQueryProperties.MaxRows = 2
            _cmdObj.XmlQueryProperties.RootTag = "MYRECORDSET"
            _cmdObj.XmlQueryProperties.RowTag = "MYRECORD"
            'Define the XSL to transform the relational dataset to XML
            _xsltString = "<?xml version=""1.0""?>" + "<xsl:stylesheet version=""1.0"" " + " xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">" + " <xsl:output encoding=""utf-8""/>" + ControlChars.Lf + " <xsl:template match=""/"">" + " <Products>" + " <xsl:apply-templates select=""MYRECORDSET""/>" + " </Products>" + " </xsl:template>" + " <xsl:template match=""MYRECORDSET"">" + " <xsl:apply-templates select=""MYRECORD""/>" + " </xsl:template>" + " <xsl:template match=""MYRECORD"">" + " <Product>" + " <ID>" + " <xsl:value-of select=""ID""/>" + " </ID>" + " <Name>" + " <xsl:value-of select=""NAME""/>" + " </Name>" + " <Price>" + " <xsl:value-of select=""PRICE""/>" + " </Price>" + " <Remarks>" + " <xsl:value-of select=""REMARKS""/>" + " </Remarks>" + " </Product>" + " </xsl:template>" + "</xsl:stylesheet>"
            _cmdObj.XmlQueryProperties.Xslt = _xsltString
            Dim xmlReader As XmlReader = _cmdObj.ExecuteXmlReader()
            Dim xmlDocument As New XmlDocument()
            xmlDocument.PreserveWhitespace = True
            xmlDocument.Load(xmlReader)
            MessageBox.Show(xmlDocument.OuterXml)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button7_Click


    Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _xsltString As String = ""
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _cmdObj As New OracleCommand("", _connObj)
            _connObj.Open()
            Dim _updColList(4) As String
            _updColList(0) = "ID"
            _updColList(1) = "NAME"
            _updColList(2) = "PRICE"
            _updColList(3) = "REMARKS"
            'The XSL used to transform the incoming XML data into the raw XML format
            'that Oracle recognizes to perform the Insert.
            _xsltString = "<?xml version=""1.0""?>" + "<xsl:stylesheet version=""1.0"" " + " xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">" + " <xsl:output encoding=""utf-8""/>" + ControlChars.Lf + " <xsl:template match=""/"">" + " <RECORDSET>" + " <xsl:apply-templates select=""MYPRODUCTS""/>" + " </RECORDSET>" + " </xsl:template>" + " <xsl:template match=""MYPRODUCTS"">" + " <xsl:apply-templates select=""MYPRODUCT""/>" + " </xsl:template>" + " <xsl:template match=""MYPRODUCT"">" + " <RECORD>" + " <ID>" + " <xsl:value-of select=""PROD_ID""/>" + " </ID>" + " <NAME>" + " <xsl:value-of select=""PROD_NAME""/>" + " </NAME>" + " <PRICE>" + " <xsl:value-of select=""PROD_PRICE""/>" + " </PRICE>" + " <REMARKS>" + " <xsl:value-of select=""PROD_REMARKS""/>" + " </REMARKS>" + " </RECORD>" + " </xsl:template>" + "</xsl:stylesheet>"
            _cmdObj.BindByName = True
            _cmdObj.XmlCommandType = OracleXmlCommandType.Insert
            _cmdObj.XmlSaveProperties.RowTag = "RECORD"
            _cmdObj.XmlSaveProperties.Table = "PRODUCTS"
            _cmdObj.XmlSaveProperties.KeyColumnsList = Nothing
            _cmdObj.XmlSaveProperties.UpdateColumnsList = _updColList
            _cmdObj.XmlSaveProperties.Xslt = _xsltString
            'Declare two records in XML to insert
            _cmdObj.CommandText = "<?xml version=""1.0""?>" + ControlChars.Lf + "<MYPRODUCTS>" + ControlChars.Lf + " <MYPRODUCT>" + ControlChars.Lf + " <PROD_ID>G1</PROD_ID>" + ControlChars.Lf + " <PROD_NAME>Grille</PROD_NAME>" + ControlChars.Lf + " <PROD_PRICE>30.20</PROD_PRICE>" + ControlChars.Lf + " <PROD_REMARKS>The front grille of the car</PROD_REMARKS>" + ControlChars.Lf + " </MYPRODUCT>" + ControlChars.Lf + " <MYPRODUCT>" + ControlChars.Lf + " <PROD_ID>M1</PROD_ID>" + ControlChars.Lf + " <PROD_NAME>Mirrors</PROD_NAME>" + ControlChars.Lf + " <PROD_PRICE>50.50</PROD_PRICE>" + ControlChars.Lf + " <PROD_REMARKS>Front mirrors of the car</PROD_REMARKS>" + ControlChars.Lf + " </MYPRODUCT>" + ControlChars.Lf + "</MYPRODUCTS>"
            Dim _result As Integer = _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Rows Inserted:" + _result))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button9_Click


    Private Sub button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button10.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _xsltString As String = ""
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _cmdObj As New OracleCommand("", _connObj)
            _connObj.Open()
            ' Set the Update Column List
            Dim _updColList(2) As String
            _updColList(0) = "NAME"
            _updColList(1) = "PRICE"
            ' Set the Key List
            Dim _keyColList(1) As String
            _keyColList(0) = "ID"
            _xsltString = "<?xml version=""1.0""?>" + "<xsl:stylesheet version=""1.0"" " + " xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">" + " <xsl:output encoding=""utf-8""/>" + ControlChars.Lf + " <xsl:template match=""/"">" + " <RECORDSET>" + " <xsl:apply-templates select=""MYPRODUCTS""/>" + " </RECORDSET>" + " </xsl:template>" + " <xsl:template match=""MYPRODUCTS"">" + " <xsl:apply-templates select=""MYPRODUCT""/>" + " </xsl:template>" + " <xsl:template match=""MYPRODUCT"">" + " <RECORD>" + " <ID>" + " <xsl:value-of select=""PROD_ID""/>" + " </ID>" + " <NAME>" + " <xsl:value-of select=""PROD_NAME""/>" + " </NAME>" + " <PRICE>" + " <xsl:value-of select=""PROD_PRICE""/>" + " </PRICE>" + " <REMARKS>" + " <xsl:value-of select=""PROD_REMARKS""/>" + " </REMARKS>" + " </RECORD>" + " </xsl:template>" + "</xsl:stylesheet>"
            _cmdObj.BindByName = True
            _cmdObj.XmlCommandType = OracleXmlCommandType.Update
            _cmdObj.XmlSaveProperties.RowTag = "RECORD"
            _cmdObj.XmlSaveProperties.Table = "PRODUCTS"
            _cmdObj.XmlSaveProperties.KeyColumnsList = _keyColList
            _cmdObj.XmlSaveProperties.UpdateColumnsList = _updColList
            _cmdObj.XmlSaveProperties.Xslt = _xsltString
            'Notice that you don’t have to include all the fields – only the fields you
            'wish to update (together with the record identifiers)
            _cmdObj.CommandText = "<?xml version=""1.0""?>" + ControlChars.Lf + "<MYPRODUCTS>" + ControlChars.Lf + " <MYPRODUCT>" + ControlChars.Lf + " <PROD_ID>G1</PROD_ID>" + ControlChars.Lf + " <PROD_NAME>Grille Revision 2</PROD_NAME>" + ControlChars.Lf + " <PROD_PRICE>50.00</PROD_PRICE>" + ControlChars.Lf + " </MYPRODUCT>" + ControlChars.Lf + " <MYPRODUCT>" + ControlChars.Lf + " <PROD_ID>M1</PROD_ID>" + ControlChars.Lf + " <PROD_NAME>Titanium Enforced Mirror</PROD_NAME>" + ControlChars.Lf + " <PROD_PRICE>60.50</PROD_PRICE>" + ControlChars.Lf + " </MYPRODUCT>" + ControlChars.Lf + "</MYPRODUCTS>"
            Dim _result As Integer = _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Rows Updated:" + _result))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button10_Click


    Private Sub button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button11.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _xsltString As String = ""
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _cmdObj As New OracleCommand("", _connObj)
            _connObj.Open()
            ' Define the Key Columns List
            Dim _keyColList(1) As String
            _keyColList(0) = "ID"
            _xsltString = "<?xml version=""1.0""?>" + "<xsl:stylesheet version=""1.0"" " + " xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">" + " <xsl:output encoding=""utf-8""/>" + ControlChars.Lf + " <xsl:template match=""/"">" + " <RECORDSET>" + " <xsl:apply-templates select=""MYPRODUCTS""/>" + " </RECORDSET>" + " </xsl:template>" + " <xsl:template match=""MYPRODUCTS"">" + " <xsl:apply-templates select=""MYPRODUCT""/>" + " </xsl:template>" + " <xsl:template match=""MYPRODUCT"">" + " <RECORD>" + " <ID>" + " <xsl:value-of select=""PROD_ID""/>" + " </ID>" + " <NAME>" + " <xsl:value-of select=""PROD_NAME""/>" + " </NAME>" + " <PRICE>" + " <xsl:value-of select=""PROD_PRICE""/>" + " </PRICE>" + " <REMARKS>" + " <xsl:value-of select=""PROD_REMARKS""/>" + " </REMARKS>" + " </RECORD>" + " </xsl:template>" + "</xsl:stylesheet>"
            _cmdObj.BindByName = True
            _cmdObj.XmlCommandType = OracleXmlCommandType.Delete
            _cmdObj.XmlSaveProperties.RowTag = "RECORD"
            _cmdObj.XmlSaveProperties.Table = "PRODUCTS"
            _cmdObj.XmlSaveProperties.KeyColumnsList = _keyColList
            _cmdObj.XmlSaveProperties.UpdateColumnsList = Nothing
            _cmdObj.XmlSaveProperties.Xslt = _xsltString
            'Define the records to delete. Only the record identifier field is needed
            _cmdObj.CommandText = "<?xml version=""1.0""?>" + ControlChars.Lf + "<MYPRODUCTS>" + ControlChars.Lf + " <MYPRODUCT>" + ControlChars.Lf + " <PROD_ID>G1</PROD_ID>" + ControlChars.Lf + " </MYPRODUCT>" + ControlChars.Lf + " <MYPRODUCT>" + ControlChars.Lf + " <PROD_ID>M1</PROD_ID>" + ControlChars.Lf + " </MYPRODUCT>" + ControlChars.Lf + "</MYPRODUCTS>"
            Dim _result As Integer = _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Rows Deleted:" + _result))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button11_Click


    Private Sub button12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button12.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _cmdObj As New OracleCommand("", _connObj)
            _connObj.Open()
            _cmdObj.CommandType = CommandType.Text
            Dim _sql As String
            _sql = "SELECT XMLQuery('" + "for $i in ora:view(""PRODUCT_EXTRAINFO"") " + "where $i/ROW/INFO/PRODUCT/CATEGORY = $MyID " + "return $i' " + "PASSING :MyID AS ""MyID"" RETURNING CONTENT) " + "FROM DUAL"
            _cmdObj.CommandText = _sql
            'Pass in “Engines” as the category to search for
            _cmdObj.Parameters.Add("MyID", OracleDbType.Varchar2, "Engines", ParameterDirection.Input)
            Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
            _rdrObj.Read()
            Dim xml As OracleXmlType = _rdrObj.GetOracleXmlType(0)
            MessageBox.Show(xml.Value)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button12_Click

   
End Class 'Main
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected