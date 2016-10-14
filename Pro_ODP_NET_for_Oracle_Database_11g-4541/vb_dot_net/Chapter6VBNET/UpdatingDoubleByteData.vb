Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types


Namespace Chapter_6
End Namespace 'Chapter_6
 _
Class UpdatingDoubleByteData
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
        Dim _recordsAffected As Integer
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "UPDATE Products SET RemarksInJapanese=:DblByteRemarks WHERE ID=:ProdID"
            _cmdObj.CommandType = CommandType.Text
            Dim _RemarksParam As New OracleParameter()
            _RemarksParam.ParameterName = "DblByteRemarks"
            _RemarksParam.OracleDbType = OracleDbType.NVarchar2
            _RemarksParam.Direction = ParameterDirection.Input
            _RemarksParam.Value = txtRemarks.Text
            _cmdObj.Parameters.Add(_RemarksParam)
            Dim _NameParam As New OracleParameter()
            _NameParam.ParameterName = "ProdID"
            _NameParam.OracleDbType = OracleDbType.Varchar2
            _NameParam.Direction = ParameterDirection.Input
            _NameParam.Value = txtProductID.Text
            _cmdObj.Parameters.Add(_NameParam)
            _recordsAffected = _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Updating done!")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As OracleException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click
End Class 'UpdatingDoubleByteData
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected