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
Class ChangeNotificationInformation
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


    Public Sub OnNotificationReceived(ByVal src As Object, ByVal arg As OracleNotificationEventArgs)
        Dim changeDetails As DataTable = arg.Details
        _NotificationRaised = True
        DisplayDataInGrid(changeDetails)
    End Sub 'OnNotificationReceived


    Delegate Sub DisplayDataInGridDelegate(ByVal sourceData As DataTable)

    Private Sub DisplayDataInGrid(ByVal sourceData As DataTable)
        If Me.InvokeRequired Then
            Dim _displayDataFunc As New DisplayDataInGridDelegate(AddressOf DisplayDataInGrid)
            Me.BeginInvoke(_displayDataFunc, sourceData)
            Return
        End If
        'This is the code that displays the OracleNotificationEventArgs object in the
        'DataGridView control
        dataGridView1.DataSource = sourceData
        dataGridView1.Refresh()
    End Sub 'DisplayDataInGrid


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            'Register the change notification
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT Price FROM Products WHERE ID='E1'"
            OracleDependency.Port = 1200
            Dim _dep As New OracleDependency(_cmdObj)
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


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj2 As New OracleConnection(_connstring)
            _connObj2.Open()
            Dim _txn As OracleTransaction = _connObj2.BeginTransaction()
            'Update the particular record that we’ve registered the change notification for
            Dim _sql As String = "UPDATE Products SET Price=550 WHERE ID='E1'"
            Dim _cmdObj2 As New OracleCommand(_sql, _connObj2)
            _cmdObj2.ExecuteNonQuery()
            _txn.Commit()
            _connObj2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'ChangeNotificationInformation
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected