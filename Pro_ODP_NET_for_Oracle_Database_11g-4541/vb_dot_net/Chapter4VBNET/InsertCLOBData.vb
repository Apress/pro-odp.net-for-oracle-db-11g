Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types


Namespace Chapter_4
End Namespace 'Chapter_4
 _
Class InsertCLOBData
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


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _recordsAffected As Integer
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "INSERT INTO ProductFiles(ProductID, Remarks) VALUES(:ProductID,:Remarks)"
            _cmdObj.Parameters.Add(New OracleParameter("ProductID", txtProductID.Text))
            Dim _clobObj As New OracleClob(_connObj)
            _clobObj.Write(txtRemarks.Text.ToCharArray(), 0, txtRemarks.Text.Length)
            _cmdObj.Parameters.Add(New OracleParameter("Remarks", _clobObj))
            _recordsAffected = _cmdObj.ExecuteNonQuery()
            If _recordsAffected = 1 Then
                MessageBox.Show("CLOB saved!")
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'InsertCLOBData
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected