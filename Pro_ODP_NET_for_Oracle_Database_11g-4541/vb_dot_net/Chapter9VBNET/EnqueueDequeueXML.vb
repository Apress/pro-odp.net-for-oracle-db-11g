Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types


Namespace Chapter_9
End Namespace 'Chapter_9
 _
Class EnqueueDequeueXML
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
            Dim _queueObj As New OracleAQQueue("EDZEHOO.JobsXML", _connObj)
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            ' Set payload type to XML
            _queueObj.MessageType = OracleAQMessageType.Xml
            ' Create a new message object
            Dim _msg As New OracleAQMessage()
            Dim _jobXML As New OracleXmlType(_connObj, "<JOB><JOBID>J1234</JOBID><JOBNAME>Feed Snuppy</JOBNAME></JOB>")
            _msg.Payload = _jobXML
            ' Enqueue the message
            _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            _queueObj.Enqueue(_msg)
            ' Display the payload data that was enqueued
            MessageBox.Show(("Payload Data : " + ControlChars.Lf + _jobXML.Value))
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
            Dim _queueObj As New OracleAQQueue("EDZEHOO.JobsXML", _connObj)
            ' Set the payload type to XML
            _queueObj.MessageType = OracleAQMessageType.Xml
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            ' Dequeue the message.
            _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            _queueObj.DequeueOptions.Wait = 10
            _queueObj.DequeueOptions.ProviderSpecificType = True
            Dim _deqMsg As OracleAQMessage = _queueObj.Dequeue()
            Dim _jobXML As OracleXmlType = CType(_deqMsg.Payload, OracleXmlType)
            MessageBox.Show(("Dequeued Payload Data: " + ControlChars.Lf + _jobXML.Value))
            _txn.Commit()
            _queueObj.Dispose()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'EnqueueDequeueXML
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected