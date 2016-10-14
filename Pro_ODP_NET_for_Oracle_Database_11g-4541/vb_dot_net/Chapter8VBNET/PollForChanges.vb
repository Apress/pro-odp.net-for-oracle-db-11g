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
Class PollForChanges
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
    Private Shared _globalDep As OracleDependency

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
            _globalDep = New OracleDependency(_cmdObj)
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Change Notification Registered!")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        'Start a timer to keep polling for changes in the table every 1 second
        AddHandler timer1.Tick, AddressOf TimerTick
        timer1.Start()
    End Sub 'button1_Click


    'The timer tick event handler. Show a message if a change is detected
    Private Shared Sub TimerTick(ByVal sender As Object, ByVal e As EventArgs)
        If _globalDep.HasChanges Then
            MessageBox.Show("Change detected!")
        End If
    End Sub 'TimerTick


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj2 As New OracleConnection(_connstring)
            _connObj2.Open()
            Dim _txn As OracleTransaction = _connObj2.BeginTransaction()
            Dim _sql As String = "INSERT INTO Products(ID, Name, Price) VALUES('AZ1','Test Product',300)"
            Dim _cmdObj2 As New OracleCommand(_sql, _connObj2)
            _cmdObj2.ExecuteNonQuery()
            _txn.Commit()
            _connObj2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'PollForChanges
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected