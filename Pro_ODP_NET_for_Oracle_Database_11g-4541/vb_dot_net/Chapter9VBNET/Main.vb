Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Namespace Chapter_9
End Namespace 'Chapter_9
 _
Class Main
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
        Dim _query As New EnqueueDequeueSimpleMsg()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _query As New EnqueueDequeueMultipleMsg()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _query As New EnqueueMCQ()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button3_Click


    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        Dim _query As New EnqueueDequeueUDT()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button4_Click


    Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'Main_Load



    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        Dim _query As New EnqueueDequeueXML()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button5_Click


    Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        Dim _query As New DequeueSyncAsync()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button6_Click
End Class 'Main
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected