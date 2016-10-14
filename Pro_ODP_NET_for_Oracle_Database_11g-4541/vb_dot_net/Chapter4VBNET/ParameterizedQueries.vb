Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client


Namespace Chapter_4
End Namespace 'Chapter_4
 _
Class ParameterizedQueries
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
        Dim _sql As String
        Dim _rdrObj As OracleDataReader
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _ds As New DataSet()
            _connObj.Open()
            _sql = "SELECT * FROM Products WHERE ID=:IDValue"
            Dim _cmdObj As New OracleCommand(_sql, _connObj)
            Dim _idParam As OracleParameter = _cmdObj.CreateParameter()
            _idParam.ParameterName = "IDValue"
            _idParam.OracleDbType = OracleDbType.Varchar2
            _idParam.Value = txtID.Text
            _cmdObj.Parameters.Add(_idParam)
            _rdrObj = _cmdObj.ExecuteReader()
            If _rdrObj.HasRows Then
                If _rdrObj.Read() Then
                    txtName.Text = _rdrObj.GetString(_rdrObj.GetOrdinal("Name"))
                    txtRemarks.Text = _rdrObj.GetString(_rdrObj.GetOrdinal("Remarks"))
                    numPrice.Value = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Price"))
                End If
            Else
                MessageBox.Show("A record with a matching ID was not found")
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click
End Class 'ParameterizedQueries
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected