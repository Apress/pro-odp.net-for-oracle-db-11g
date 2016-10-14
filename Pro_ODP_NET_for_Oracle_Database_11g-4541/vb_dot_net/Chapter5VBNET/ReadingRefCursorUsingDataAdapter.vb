Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Types
Imports Oracle.DataAccess.Client



Namespace Chapter_5
End Namespace 'Chapter_5
 _
Class ReadingRefCursorUsingDataAdapter
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
            Dim _RefParam As New OracleParameter()
            _RefParam.ParameterName = "ProdInfo"
            _RefParam.OracleDbType = OracleDbType.RefCursor
            _RefParam.Direction = ParameterDirection.Output
            _cmdObj.Parameters.Add(_RefParam)
            Dim _adapterObj As New OracleDataAdapter(_cmdObj)
            Dim _datasetObj As New DataSet()
            _adapterObj.Fill(_datasetObj)
            dataGridView1.DataSource = _datasetObj.Tables(0)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click
End Class 'ReadingRefCursorUsingDataAdapter
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected