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
Class EnqueueDequeueSimpleMsg
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


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            ' Create a new queue object
            Dim _queueObj As New OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE", _connObj)
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            'The Visibility property OnCommit makes the dequeue part of the transaction
            'The Wait property specifies the number of seconds to wait for the Dequeue.
            'The default value of this property is set to wait forever
            _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            _queueObj.DequeueOptions.Wait = 10
            ' Dequeue the message.
            Dim _deqMsg As OracleAQMessage = _queueObj.Dequeue()
            MessageBox.Show(("Dequeued Payload Data: " + ConvertFromByteArray(CType(_deqMsg.Payload, Byte())) + ControlChars.Lf + "Dequeued Payload Hex: " + ConvertToHexString(CType(_deqMsg.Payload, Byte())) + ControlChars.Lf + "Message ID of Dequeued Payload : " + ConvertToHexString(_deqMsg.MessageId) + ControlChars.Lf + "Correlation : " + _deqMsg.Correlation))
            _txn.Commit()
            _queueObj.Dispose()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click



    ' Converts a byte array to a String
    Private Shared Function ConvertFromByteArray(ByVal Data() As Byte) As [String]
        Dim _stringObj As New StringBuilder()
        Dim i As Integer
        For i = 0 To Data.Length - 1
            _stringObj.Append(Chr(Data(i)))
        Next i
        Return _stringObj.ToString()
    End Function 'ConvertFromByteArray


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            ' Create a new queue object
            Dim _queueObj As New OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE", _connObj)
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            ' Set payload type to RAW (byte array)
            _queueObj.MessageType = OracleAQMessageType.Raw
            ' Create a new message object
            Dim _msg As New OracleAQMessage()
            Dim Data As [String] = "HELLO, HOW ARE YOU!"
            _msg.Payload = ConvertToByteArray(Data)
            'You can also attach additional custom data to a message via the
            'Correlation property
            _msg.Correlation = "MY ADDITIONAL MISC DATA"
            'The Visibility property OnCommit makes the enqueue part of a transaction
            _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            ' Enqueue the message
            _queueObj.Enqueue(_msg)
            ' Display the payload data that was enqueued
            MessageBox.Show(("Payload Data : " + Data + ControlChars.Lf + "Payload Hex value : " + ConvertToHexString(CType(_msg.Payload, Byte())) + ControlChars.Lf + "Message ID : " + ConvertToHexString(_msg.MessageId) + ControlChars.Lf + "Correlation : " + _msg.Correlation))
            _txn.Commit()
            _queueObj.Dispose()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click

    ' Converts a byte array to a Hexadecimal string
    Private Shared Function ConvertToHexString(ByVal Data() As Byte) As String
        Dim _stringObj As New StringBuilder()
        Dim i As Integer
        For i = 0 To Data.Length - 1
            _stringObj.Append(Integer.Parse(Data(i).ToString()).ToString("X"))
        Next i
        Return _stringObj.ToString()
    End Function 'ConvertToHexString

    ' Converts a String to a byte array
    Private Shared Function ConvertToByteArray(ByVal Data As [String]) As Byte()
        Dim _charArray As Char() = Data.ToCharArray()
        Dim _byteArray(Data.Length) As Byte
        Dim i As Integer
        For i = 0 To _charArray.Length - 1
            _byteArray(i) = Asc(_charArray(i))
        Next i
        Return _byteArray
    End Function 'ConvertToByteArray
End Class 'EnqueueDequeueSimpleMsg
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected