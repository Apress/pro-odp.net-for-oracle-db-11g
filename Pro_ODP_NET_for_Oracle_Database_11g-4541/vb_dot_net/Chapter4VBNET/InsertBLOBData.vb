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
Class InsertBLOBData
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
        openFileDialog1.ShowDialog()
        txtFilepath.Text = openFileDialog1.FileName
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        'We first read the full contents of the file into a byte array
        Dim _fileContents As Byte() = System.IO.File.ReadAllBytes(txtFilepath.Text)
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _recordsAffected As Integer
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "INSERT INTO ProductFiles(ProductID, FileAttachment) VALUES(:ProductID,:FileAttachment)"
            _cmdObj.Parameters.Add(New OracleParameter("ProductID", txtProductID.Text))
            Dim _blob As New OracleBlob(_connObj)
            _blob.Write(_fileContents, 0, _fileContents.Length)
            _cmdObj.Parameters.Add(New OracleParameter("FileAttachment", _blob))
            _recordsAffected = _cmdObj.ExecuteNonQuery()
            If _recordsAffected = 1 Then
                MessageBox.Show("File uploaded!")
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'InsertBLOBData
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected