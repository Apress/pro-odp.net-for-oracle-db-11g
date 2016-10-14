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
Class DiscoverSchema
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
        Dim _connstring As String
        _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _dt As DataTable = Nothing
        Dim myconn As New OracleConnection(_connstring)
        myconn.Open()
        Dim restrictions(3) As String
        'Here we initialize all restrictions to null – take note that null is different
        'from "". To make sure a restriction is not used, set it to null
        Dim _counter As Integer
        For _counter = 0 To 2
            restrictions(_counter) = Nothing
        Next _counter
        restrictions(0) = "EDZEHOO"
        restrictions(1) = "PRODUCTS"
        _dt = myconn.GetSchema("columns", restrictions)
        dataGridView1.DataSource = _dt
    End Sub 'button1_Click
End Class 'DiscoverSchema
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected