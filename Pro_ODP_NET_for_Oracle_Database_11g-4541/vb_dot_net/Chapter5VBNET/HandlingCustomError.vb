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
Class HandlingCustomErrors
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
            _cmdObj.CommandText = "proc_UpdatePrice"
            _cmdObj.CommandType = CommandType.StoredProcedure
            Dim _PriceParam As New OracleParameter()
            _PriceParam.ParameterName = "ProdPrice"
            _PriceParam.OracleDbType = OracleDbType.Int32
            _PriceParam.Direction = ParameterDirection.Input
            _PriceParam.Value = numPriceIncrement.Value
            _cmdObj.Parameters.Add(_PriceParam)
            Dim _NameParam As New OracleParameter()
            _NameParam.ParameterName = "ProdName"
            _NameParam.OracleDbType = OracleDbType.Varchar2
            _NameParam.Direction = ParameterDirection.Input
            _NameParam.Value = txtProductName.Text
            _cmdObj.Parameters.Add(_NameParam)
            Dim _recordsAffected As Integer = _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Updating done!")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As OracleException
            If ex.Number = 20000 Then
                MessageBox.Show("Sorry, invalid price value!")
            Else
                MessageBox.Show(ex.ToString())
            End If
        End Try
    End Sub 'button1_Click
End Class 'HandlingCustomErrors '
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected