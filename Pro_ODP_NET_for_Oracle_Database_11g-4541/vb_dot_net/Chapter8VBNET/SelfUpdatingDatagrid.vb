Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types


Namespace Chapter_8
End Namespace 'Chapter_8
 _

Class SelfUpdatingDatagrid
    Inherits Form '
    'ToDo: Error processing original source shown below
    '
    '
    '------------^--- 'class', 'struct', 'interface' or 'delegate' expected
    '
    'ToDo: Error processing original source shown below
    '
    '
    '--------------------^--- Syntax error: ';' expected
    Private _BoundToDB As Boolean = False
    Private _globalID As Integer = 1

    'The event handler for the change notification. Here we initiate a refresh of the grid data
    Public Sub OnNotificationReceived(ByVal src As Object, ByVal arg As OracleNotificationEventArgs)
        RefreshGrid()
    End Sub 'OnNotificationReceived


    'Extra code to update the DataGridView control from a callback thread
    Delegate Sub RefreshGridDelegate()


    Private Sub RefreshGrid()
        If Me.InvokeRequired Then
            Dim _displayDataFunc As New RefreshGridDelegate(AddressOf RefreshGrid)
            Me.BeginInvoke(_displayDataFunc)
            Return
        End If
        'Write the code to populate the DataGridView control with latest data from the
        'Products table
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT * FROM Products"
            Dim _adapObj As New OracleDataAdapter(_cmdObj)
            Dim _products As New DataSet()
            _adapObj.Fill(_products)
            dataGridView1.DataSource = _products.Tables(0)
            dataGridView1.Refresh()
            _cmdObj.Dispose()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'RefreshGrid


    Public Sub New()
        InitializeComponent()
    End Sub 'New


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT * FROM Products"
            OracleDependency.Port = 1200
            Dim _dep As New OracleDependency(_cmdObj)
            'Set notification settings
            _dep.QueryBasedNotification = False
            _cmdObj.Notification.IsNotifiedOnce = False
            AddHandler _dep.OnChange, AddressOf OnNotificationReceived
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Change Notification Registered!")
            _BoundToDB = True
            'Populate the DataGridView with data from the Products table
            RefreshGrid()
            While _BoundToDB = True
                Application.DoEvents()
            End While
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        _BoundToDB = False
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        _globalID += 1
        Try
            Dim _connObj2 As New OracleConnection(_connstring)
            _connObj2.Open()
            Dim _txn As OracleTransaction = _connObj2.BeginTransaction()
            Dim _sql As String = "INSERT INTO Products(ID, Name, Price) VALUES('TP" + _globalID.ToString() + "','Test Product',100)"
            Dim _cmdObj2 As New OracleCommand(_sql, _connObj2)
            _cmdObj2.ExecuteNonQuery()
            _txn.Commit()
            _connObj2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button3_Click
End Class 'SelfUpdatingDatagrid
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected