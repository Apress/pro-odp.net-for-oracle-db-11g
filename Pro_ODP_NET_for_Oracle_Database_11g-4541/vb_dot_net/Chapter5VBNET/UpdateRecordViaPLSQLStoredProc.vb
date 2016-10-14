Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client


Namespace Chapter_5
End Namespace 'Chapter_5
 _
Class UpdateRecordViaPLSQLStoredProc
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
            _cmdObj.CommandText = "proc_UpdateProduct"
            _cmdObj.CommandType = CommandType.StoredProcedure
            Dim _PriceParam As New OracleParameter()
            _PriceParam.ParameterName = "decPrice"
            _PriceParam.OracleDbType = OracleDbType.Decimal
            _PriceParam.Direction = ParameterDirection.Input
            _PriceParam.Value = numPriceIncrement.Value
            _cmdObj.Parameters.Add(_PriceParam)
            Dim _NameParam As New OracleParameter()
            _NameParam.ParameterName = "strProductName"
            _NameParam.OracleDbType = OracleDbType.Varchar2
            _NameParam.Direction = ParameterDirection.Input
            _NameParam.Value = txtProductName.Text
            _cmdObj.Parameters.Add(_NameParam)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Product updated")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click
End Class 'UpdateRecordViaPLSQLStoredProc
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected