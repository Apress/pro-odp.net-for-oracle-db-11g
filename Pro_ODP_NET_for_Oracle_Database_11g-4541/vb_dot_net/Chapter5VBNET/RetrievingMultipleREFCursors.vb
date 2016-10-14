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
Class RetrievingMultipleREFCursors
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
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "ProductsPackage.proc_GetProductsInfo"
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Create the REF cursor parameter for the products that are < $500
            Dim _chpProdParam As New OracleParameter()
            _chpProdParam.ParameterName = "cheapProducts"
            _chpProdParam.OracleDbType = OracleDbType.RefCursor
            _chpProdParam.Direction = ParameterDirection.Output
            _cmdObj.Parameters.Add(_chpProdParam)
            'Create the REF cursor parameter for the products that are > $500
            Dim _expProdParam As New OracleParameter()
            _expProdParam.ParameterName = "expensiveProducts"
            _expProdParam.OracleDbType = OracleDbType.RefCursor
            _expProdParam.Direction = ParameterDirection.Output
            _cmdObj.Parameters.Add(_expProdParam)
            Dim _adapterObj As New OracleDataAdapter(_cmdObj)
            Dim _datasetObj As New DataSet()
            _adapterObj.Fill(_datasetObj)
            'The result sets are stored in separate Datatables in the same dataset
            dataGridView1.DataSource = _datasetObj.Tables(0)
            dataGridView2.DataSource = _datasetObj.Tables(1)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click
End Class 'RetrievingMultipleREFCursors
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected