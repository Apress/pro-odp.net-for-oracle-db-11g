
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types


Namespace Chapter_5
End Namespace 'Chapter_5
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
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "BEGIN" + " INSERT INTO Products(ID, NAME, PRICE," + " REMARKS) VALUES('B1', 'Brake Fluid'," + " 80.50, 'Inserted via PL/SQL');" + "END;"
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("New row added!")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _query As New UpdateRecordViaAnonymousPLSQL()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "BEGIN" + " SELECT COUNT(*) INTO :1 FROM Products;" + "END;"
            Dim _countParam As New OracleParameter()
            _countParam.ParameterName = ":1"
            _countParam.OracleDbType = OracleDbType.Int32
            _countParam.Direction = ParameterDirection.Output
            _cmdObj.Parameters.Add(_countParam)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Total number of records : " + _countParam.Value))
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
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "proc_InsertProduct"
            _cmdObj.CommandType = CommandType.StoredProcedure
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Product inserted")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button4_Click


    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        Dim _query As New UpdateRecordViaPLSQLStoredProc()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button5_Click


    Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "proc_RetrieveCount"
            _cmdObj.CommandType = CommandType.StoredProcedure
            Dim _countParam As New OracleParameter()
            _countParam.ParameterName = "intRecordCount"
            _countParam.OracleDbType = OracleDbType.Int32
            _countParam.Direction = ParameterDirection.Output
            _cmdObj.Parameters.Add(_countParam)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Total number of records : " + _countParam.Value))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button6_Click


    Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "func_RetrieveCount"
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Declare the return parameter
            Dim _retValueParam As New OracleParameter()
            _retValueParam.ParameterName = "Any_name"
            _retValueParam.OracleDbType = OracleDbType.Int32
            _retValueParam.Direction = ParameterDirection.ReturnValue
            _cmdObj.Parameters.Add(_retValueParam)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("The return value is :" + _retValueParam.Value.ToString()))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button7_Click


    Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "ProductsPackage.proc_UpdateMultiplePrices"
            _cmdObj.CommandType = CommandType.StoredProcedure
            Dim _priceParam As New OracleParameter()
            _priceParam.ParameterName = "ProdPrices"
            _priceParam.OracleDbType = OracleDbType.Decimal
            _priceParam.Direction = ParameterDirection.Input
            _priceParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            Dim decArray(3) As [Decimal]
            decArray(0) = 100
            decArray(1) = 300
            decArray(2) = 500
            _priceParam.Value = decArray
            _cmdObj.Parameters.Add(_priceParam)
            Dim _NameParam As New OracleParameter()
            _NameParam.ParameterName = "ProdNames"
            _NameParam.OracleDbType = OracleDbType.Varchar2
            _NameParam.Direction = ParameterDirection.Input
            _NameParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            Dim stringArray(3) As [String]
            stringArray(0) = "Engine"
            stringArray(1) = "Windshield"
            stringArray(2) = "Rear Lights"
            _NameParam.Value = stringArray
            _cmdObj.Parameters.Add(_NameParam)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("All products updated!")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button8_Click


    Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "ProductsPackage.proc_GetAllProductNames"
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Create an output parameter
            Dim _NameParam As New OracleParameter()
            _NameParam.ParameterName = "ProdNames"
            _NameParam.OracleDbType = OracleDbType.Varchar2
            _NameParam.Direction = ParameterDirection.Output
            _NameParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            'You must explicitly define the number of elements to return
            _NameParam.Size = 10
            'Because you are retrieving an object with a variable size, you need to
            'define the size of the string returned. This size must be specified for
            'each element in the output result
            Dim intArray(10) As Integer
            Dim _counter As Integer
            For _counter = 0 To 9
                intArray(_counter) = 255
            Next _counter
            _NameParam.ArrayBindSize = intArray
            'Execute the stored procedure
            _cmdObj.Parameters.Add(_NameParam)
            _cmdObj.ExecuteNonQuery()
            'For VARCHAR2 data types, an array of OracleString objects is returned
            Dim _result As [String] = ""
            Dim stringArray As OracleString() = CType(_NameParam.Value, OracleString())
            For _counter = 0 To stringArray.GetUpperBound(0)
                Dim _outputString As OracleString = stringArray(_counter)
                _result = _result + _outputString.Value + ControlChars.Lf
            Next _counter
            MessageBox.Show(("Product names are:" + ControlChars.Lf + _result))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button9_Click


    Private Sub button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button10.Click
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "proc_DeleteProducts"
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Instantiate the ProductVArray class and add two elements
            Dim _products As New ProductVArray()
            _products.Array = New [String]() {"B1", "C1"}
            'Create a UDT-based OracleParameter, and pass in the ProductVArray
            'object
            Dim param As New OracleParameter()
            param.OracleDbType = OracleDbType.Object
            param.Direction = ParameterDirection.Input
            param.UdtTypeName = "EDZEHOO.PRODUCTVARRAY"
            param.Value = _products
            _cmdObj.Parameters.Add(param)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Records deleted successfully")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button10_Click


    Private Sub button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button11.Click
        Dim _connString As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connString)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "proc_DeleteProducts"
            _cmdObj.CommandType = CommandType.StoredProcedure
            ' Create a string array and populate it with the IDs of the Products you
            'wish to delete
            Dim _productsTable() As [String] = {"E1", "W1"}
            'Create a parameter object and pass in the string array
            Dim _productTblParam As New OracleParameter()
            _productTblParam.OracleDbType = OracleDbType.Array
            _productTblParam.Direction = ParameterDirection.Input
            _productTblParam.UdtTypeName = "EDZEHOO.PRODUCTNESTEDTABLE"
            _productTblParam.Value = _productsTable
            _cmdObj.Parameters.Add(_productTblParam)
            _cmdObj.ExecuteNonQuery()

            MessageBox.Show("Records deleted successfully")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As OracleException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button11_Click


    Private Sub button12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button12.Click
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "ProductsPackage.proc_GetProductsInfo"
            _cmdObj.CommandType = CommandType.StoredProcedure
            Dim _RefParam As New OracleParameter()
            _RefParam.ParameterName = "ProdInfo"
            _RefParam.OracleDbType = OracleDbType.RefCursor
            _RefParam.Direction = ParameterDirection.Output
            _cmdObj.Parameters.Add(_RefParam)
            Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
            'This should remind you of Chapter 4. We use an OracleDataReader object to
            'loop through the result set and display a summary of the retrieved
            'information in a popup message box
            If _rdrObj.HasRows Then
                While _rdrObj.Read()
                    Dim _data As [String] = ""
                    _data = "ID:" + _rdrObj.GetString(_rdrObj.GetOrdinal("ID")) + ControlChars.Lf + "Name:" + _rdrObj.GetString(_rdrObj.GetOrdinal("Name")) + ControlChars.Lf + "Price:" + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Price"))
                    MessageBox.Show(_data)
                End While
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button12_Click


    Private Sub button13_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button13.Click
        Dim _query As New ReadingRefCursorUsingDataAdapter()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button13_Click


    Private Sub button14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button14.Click
        Dim _query As New RetrievingMultipleREFCursors()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button14_Click


    Private Sub button15_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button15.Click
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = " proc_InsertProduct"
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Instantiate your UDT class here and specify the data for your new record
            Dim _product As New PRODUCTTYPE()
            _product.NAME = "SPARETYRE"
            _product.PRICE = 400
            _product.ID = "Y1"
            'Declare a UDT-based parameter and pass the instantiated class into this
            'parameter
            Dim param As New OracleParameter()
            param.OracleDbType = OracleDbType.Object
            param.Direction = ParameterDirection.Input
            param.UdtTypeName = "EDZEHOO.PRODUCTTYPE"
            param.Value = _product
            _cmdObj.Parameters.Add(param)
            Dim result As Integer = _cmdObj.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Product successfully added")
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button15_Click


    Private Sub button16_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button16.Click
        Dim _query As New HandlingCustomErrors()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button16_Click
End Class 'Main
'
'ToDo: Error processing original source shown below
'
'
'--^--- expression expected