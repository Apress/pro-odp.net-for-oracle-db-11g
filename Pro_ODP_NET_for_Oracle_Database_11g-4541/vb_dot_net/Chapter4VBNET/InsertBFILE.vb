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
Class InsertBFILE
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
        txtFilename.Text = openFileDialog1.FileName
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        'We first read the full contents of the file into a byte array
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _recordsAffected As Integer
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "INSERT INTO ProductFiles(ProductID, FileAttachment2) VALUES(:ProductID,BFILENAME('PRODUCTFILESFOLDER',:FileName))"
            _cmdObj.Parameters.Add(New OracleParameter("ProductID", txtProductID.Text))
            _cmdObj.Parameters.Add(New OracleParameter("FileName", System.IO.Path.GetFileName(txtFilename.Text)))
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


    Private Sub txtFilename_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'txtFilename_TextChanged



    Private Sub txtProductID_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'txtProductID_TextChanged



    Private Sub label2_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'label2_Click



    Private Sub label1_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'label1_Click
End Class 'InsertBFILE 
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected