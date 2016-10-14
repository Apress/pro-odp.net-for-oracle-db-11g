Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client


Namespace Chapter_9
End Namespace 'Chapter_9
 _
Class EnqueueDequeueUDT
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
        Try
            Dim _connObj As New OracleConnection(_connstring)
            ' Create a new queue object
            Dim _queueObj As New OracleAQQueue("EDZEHOO.SmallJobs", _connObj)
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            ' Set the payload type to your UDT
            _queueObj.MessageType = OracleAQMessageType.Udt
            _queueObj.UdtTypeName = "EDZEHOO.JOBS_TYPE"
            ' Create a new message object
            Dim _msg As New OracleAQMessage()
            ' Create an instance of JobClass and pass it in as the payload for the // message
            Dim _job As New JobClass()
            _job.JobID = "J1234"
            _job.JobName = "Feed Snuppy"
            _job.JobPrice = 15
            _job.JobDescription = "Feed Rice Crispies twice a day"
            _msg.Payload = _job
            ' Enqueue the message
            _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            _queueObj.Enqueue(_msg)
            ' Display the payload data that was enqueued
            MessageBox.Show(("Payload Data : " + _job.ToString()))
            _txn.Commit()
            _queueObj.Dispose()
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
            Dim _connObj As New OracleConnection(_connstring)
            ' Create a new queue object
            Dim _queueObj As New OracleAQQueue("EDZEHOO.SmallJobs", _connObj)
            ' Set the payload type to your UDT
            _queueObj.MessageType = OracleAQMessageType.Udt
            _queueObj.UdtTypeName = "EDZEHOO.JOBS_TYPE"
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            ' Dequeue the message.
            _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            _queueObj.DequeueOptions.Wait = 10
            Dim _deqMsg As OracleAQMessage = _queueObj.Dequeue()
            Dim _Data As JobClass = CType(_deqMsg.Payload, JobClass)
            MessageBox.Show(_Data.ToString())
            _txn.Commit()
            _queueObj.Dispose()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'EnqueueDequeueUDT
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected