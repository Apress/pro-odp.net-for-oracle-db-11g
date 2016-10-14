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
Class UpdateRecordViaAnonymousPLSQL
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


    Private Sub UpdateRecordViaAnonymousPLSQL_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'UpdateRecordViaAnonymousPLSQL_Load



    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "BEGIN" + " UPDATE Products SET Price=Price + :1 " + " WHERE Name = :2;" + "END;"
            Dim _PriceParam As New OracleParameter()
            _PriceParam.ParameterName = ":1"
            _PriceParam.OracleDbType = OracleDbType.Int32
            _PriceParam.Direction = ParameterDirection.Input
            _PriceParam.Value = numPriceIncrement.Value
            _cmdObj.Parameters.Add(_PriceParam)
            Dim _NameParam As New OracleParameter()
            _NameParam.ParameterName = ":2"
            _NameParam.OracleDbType = OracleDbType.Varchar2
            _NameParam.Direction = ParameterDirection.Input
            _NameParam.Value = txtProductName.Text
            _cmdObj.Parameters.Add(_NameParam)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Updating done!")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click
End Class 'UpdateRecordViaAnonymousPLSQL
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected