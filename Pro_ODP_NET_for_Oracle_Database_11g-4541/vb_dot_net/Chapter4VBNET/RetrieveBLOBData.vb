﻿Imports System
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
Class RetrieveBLOBData
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
        'We first read the full contents of the file into a byte array
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _rdrObj As OracleDataReader
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT FileAttachment FROM ProductFiles WHERE ProductID=:ProductID"
            _cmdObj.Parameters.Add(New OracleParameter("ProductID", txtProductID.Text))
            _rdrObj = _cmdObj.ExecuteReader()
            If _rdrObj.HasRows Then
                If _rdrObj.Read() Then
                    Dim _blobObj As OracleBlob = _rdrObj.GetOracleBlob(_rdrObj.GetOrdinal("FileAttachment"))
                    picProductImage.Image = Image.FromStream(New System.IO.MemoryStream(_blobObj.Value))
                End If
            Else
                MessageBox.Show("An item with the matching product ID was not found!")
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click
End Class 'RetrieveBLOBData
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected