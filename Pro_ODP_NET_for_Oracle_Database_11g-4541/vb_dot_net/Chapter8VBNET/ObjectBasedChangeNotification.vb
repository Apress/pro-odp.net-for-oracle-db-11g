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
Class ObjectBasedChangeNotification
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
    Private Shared _NotificationRaised As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub 'New


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            'Register the change notification
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT * FROM Products"
            OracleDependency.Port = 1200
            Dim _dep As New OracleDependency(_cmdObj)
            _dep.QueryBasedNotification = False
            AddHandler _dep.OnChange, AddressOf OnNotificationReceived
            _cmdObj.ExecuteNonQuery()
            'Wait in a loop for the notification
            While _NotificationRaised = False
                Application.DoEvents()
            End While
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    'The event handler for the change notification
    Public Shared Sub OnNotificationReceived(ByVal src As Object, ByVal arg As OracleNotificationEventArgs)
        Dim changeDetails As DataTable = arg.Details
        _NotificationRaised = True
        MessageBox.Show(("Table has changed: " + changeDetails.Rows(0)("ResourceName")))
    End Sub 'OnNotificationReceived


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj2 As New OracleConnection(_connstring)
            _connObj2.Open()
            Dim _txn As OracleTransaction = _connObj2.BeginTransaction()
            'Insert a new record into the table
            Dim _sql As String = "INSERT INTO Products (ID, Price, Name) VALUES('ZL1', 300, 'TestProduct')"
            Dim _cmdObj2 As New OracleCommand(_sql, _connObj2)
            _cmdObj2.ExecuteNonQuery()
            _txn.Commit()
            _connObj2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'ObjectBasedChangeNotification
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected