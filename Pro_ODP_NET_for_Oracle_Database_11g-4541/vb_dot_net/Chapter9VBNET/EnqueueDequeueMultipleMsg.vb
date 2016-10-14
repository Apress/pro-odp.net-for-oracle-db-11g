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
Class EnqueueDequeueMultipleMsg
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
            Dim _queueObj As New OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE", _connObj)
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            ' Set payload type
            _queueObj.MessageType = OracleAQMessageType.Raw
            ' Create an array of OracleAQMessage objects
            Dim _msgs(2) As OracleAQMessage
            ' Fill the array with strings
            Dim Data(2) As [String]
            Data(0) = "HELLO, HOW ARE YOU!"
            Data(1) = "... AND WHAT'S YOUR NAME?"
            _msgs(0) = New OracleAQMessage(ConvertToByteArray(Data(0)))
            _msgs(1) = New OracleAQMessage(ConvertToByteArray(Data(1)))
            ' Enqueue the message - take note that we're using the EnqueueArray
            ' function now
            _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            _queueObj.EnqueueArray(_msgs)
            ' Display the payload data that was enqueued
            Dim i As Integer
            For i = 0 To 1
                MessageBox.Show(("Payload Data : " + Data(i) + ControlChars.Lf + "Payload Hex value : " + ConvertToHexString(CType(_msgs(i).Payload, Byte())) + ControlChars.Lf + "Message ID : " + ConvertToHexString(_msgs(i).MessageId)))
            Next i
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


    ' Converts a byte array to a String
    Private Shared Function ConvertFromByteArray(ByVal Data() As Byte) As [String]
        Dim _stringObj As New StringBuilder()
        Dim i As Integer
        For i = 0 To Data.Length - 1
            _stringObj.Append(Chr(Data(i)))
        Next i
        Return _stringObj.ToString()
    End Function 'ConvertFromByteArray


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            ' Create a new queue object
            Dim _queueObj As New OracleAQQueue("EDZEHOO.MY_JOBS_QUEUE", _connObj)
            _connObj.Open()
            Dim _txn As OracleTransaction = _connObj.BeginTransaction()
            _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit
            _queueObj.DequeueOptions.Wait = 10
            _queueObj.DequeueOptions.ProviderSpecificType = True
            ' Dequeue the messages – take note that you can specify the number of
            ' messages you wish to retrieve from the queue
            Dim _deqMsgs As OracleAQMessage() = _queueObj.DequeueArray(2)
            Dim i As Integer
            For i = 0 To _deqMsgs.Length - 1
                ' If you enqueued a byte array, the dequeued object is an
                ' OracleBinary object. You can retrieve the byte array using the
                ' OracleBinary.Value property
                Dim _payload As OracleBinary = CType(_deqMsgs(i).Payload, OracleBinary)
                MessageBox.Show(("Dequeued Payload Data: " + ConvertFromByteArray(_payload.Value) + ControlChars.Lf + "Dequeued Payload Hex: " + ConvertToHexString(_payload.Value) + ControlChars.Lf))
            Next i
            _txn.Commit()
            _queueObj.Dispose()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'EnqueueDequeueMultipleMsg
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected