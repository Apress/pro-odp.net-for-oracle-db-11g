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
    Class EnqueueMCQ
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
        End Sub 'New


        Private Shared Function ConvertFromByteArray(ByVal Data() As Byte) As [String]
            Dim _stringObj As New StringBuilder()
            Dim i As Integer
            For i = 0 To Data.Length - 1
                _stringObj.Append(Chr(Data(i)))
            Next i
            Return _stringObj.ToString()
        End Function 'ConvertFromByteArray


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



        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
            Try
                Dim _connObj As New OracleConnection(_connstring)
                ' Create a new queue object

                Dim _queueObj As New OracleAQQueue("EDZEHOO.JobsQueue", _connObj)
                _connObj.Open()
                Dim _txn As OracleTransaction = _connObj.BeginTransaction()
                ' Set payload type
                _queueObj.MessageType = OracleAQMessageType.Raw
                ' Create a new message object
                Dim _msg As New OracleAQMessage()
                Dim Data As [String] = "HELLO, HOW ARE YOU!"
                _msg.Payload = ConvertToByteArray(Data)
                ' Define the sender ID and enqueue the message
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit
                _msg.SenderId = New OracleAQAgent("EDZEHOO")
                _queueObj.Enqueue(_msg)
                ' Display the payload data that was enqueued
                MessageBox.Show(("Payload Data : " + Data + ControlChars.Lf + "Payload Hex value : " + ConvertToHexString(CType(_msg.Payload, Byte())) + ControlChars.Lf + "Message ID : " + ConvertToHexString(_msg.MessageId)))
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
                Dim _queueObj As New OracleAQQueue("EDZEHOO.JobsQueue", _connObj)
                _connObj.Open()
                Dim _txn As OracleTransaction = _connObj.BeginTransaction()
                ' Dequeue the message.
                _queueObj.DequeueOptions.Visibility = OracleAQVisibilityMode.OnCommit
                _queueObj.DequeueOptions.Wait = 10
                ' Here set the consumer name to the registered queue subscriber
                ' This queue subscriber was registered when you setup the queue
                ' in SQL*Plus
                _queueObj.DequeueOptions.ConsumerName = "JOHNDALY"
                Dim _deqMsg As OracleAQMessage = _queueObj.Dequeue()
                MessageBox.Show(("Dequeued Payload Data: " + ConvertFromByteArray(CType(_deqMsg.Payload, Byte())) + ControlChars.Lf + "Dequeued Payload Hex: " + ConvertToHexString(CType(_deqMsg.Payload, Byte())) + ControlChars.Lf + "Message ID of Dequeued Payload : " + ConvertToHexString(_deqMsg.MessageId)))
                _txn.Commit()
                _queueObj.Dispose()
                _connObj.Close()
                _connObj.Dispose()
                _connObj = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End Sub 'button2_Click


        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
            Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
            Try
                Dim _connObj As New OracleConnection(_connstring)
                ' Create a new queue object
                Dim _queueObj As New OracleAQQueue("EDZEHOO.JobsQueue", _connObj)
                _connObj.Open()
                Dim _txn As OracleTransaction = _connObj.BeginTransaction()
                ' Set payload type
                _queueObj.MessageType = OracleAQMessageType.Raw
                ' Create a new message object
                Dim _msg As New OracleAQMessage()
                Dim Data As [String] = "HELLO, HOW ARE YOU!"
                _msg.Payload = ConvertToByteArray(Data)
                ' Enqueue the message
                _queueObj.EnqueueOptions.Visibility = OracleAQVisibilityMode.OnCommit
                ' Register the subscriber at the message-level using the
                ' OracleAQMessage.Recipients property
                Dim agent(1) As OracleAQAgent
                agent(0) = New OracleAQAgent("RONFRICKE")
                _msg.Recipients = agent
                _msg.SenderId = New OracleAQAgent("EDZEHOO")
                _queueObj.Enqueue(_msg)
                ' Display the payload data that was enqueued
                MessageBox.Show(("Payload Data : " + Data + ControlChars.Lf + "Payload Hex value : " + ConvertToHexString(CType(_msg.Payload, Byte())) + ControlChars.Lf + "Message ID : " + ConvertToHexString(_msg.MessageId)))
                _txn.Commit()
                _queueObj.Dispose()
                _connObj.Close()
                _connObj.Dispose()
                _connObj = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End Sub 'button3_Click

        Private Sub InitializeComponent()
            Me.button3 = New System.Windows.Forms.Button
            Me.button2 = New System.Windows.Forms.Button
            Me.button1 = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'button3
            '
            Me.button3.Location = New System.Drawing.Point(12, 46)
            Me.button3.Name = "button3"
            Me.button3.Size = New System.Drawing.Size(222, 23)
            Me.button3.TabIndex = 7
            Me.button3.Text = "Enqueue + Define Recipients by code"
            Me.button3.UseVisualStyleBackColor = True
            '
            'button2
            '
            Me.button2.Location = New System.Drawing.Point(240, 17)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(202, 23)
            Me.button2.TabIndex = 6
            Me.button2.Text = "Dequeue"
            Me.button2.UseVisualStyleBackColor = True
            '
            'button1
            '
            Me.button1.Location = New System.Drawing.Point(12, 17)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(222, 23)
            Me.button1.TabIndex = 5
            Me.button1.Text = "Enqueue"
            Me.button1.UseVisualStyleBackColor = True
            '
            'EnqueueMCQ
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(454, 87)
            Me.Controls.Add(Me.button3)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Name = "EnqueueMCQ"
            Me.Text = "EnqueueMCQ"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents button3 As System.Windows.Forms.Button
        Private WithEvents button2 As System.Windows.Forms.Button
        Private WithEvents button1 As System.Windows.Forms.Button
    End Class 'EnqueueMCQ
    '
    'ToDo: Error processing original source shown below
    '
    '
End Namespace 'Chapter_9
'-^--- expression expected