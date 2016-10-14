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
Class RetrievingDataIntoDataset
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
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _ds As New DataSet()
            _connObj.Open()
            _sql = "SELECT * FROM Products"
            Dim _adapterObj As New OracleDataAdapter(_sql, _connObj)
            _adapterObj.Fill(_ds)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            dataGridView1.DataSource = _ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub dataGridView1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
    End Sub 'dataGridView1_CellContentClick

    Private Sub dataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub
End Class 'RetrievingDataIntoDataset 
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected