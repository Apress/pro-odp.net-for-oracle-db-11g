Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System.Transactions


Namespace Chapter_7
End Namespace 'Chapter_7
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
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _tranObj As OracleTransaction
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()

            'Clear the appropriate tables first
            _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='A01'"
            _cmdObj.ExecuteNonQuery()

            _tranObj = _connObj.BeginTransaction()
            Try
                'Insert a record into the Invoice table
                _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)"
                _cmdObj.Parameters.Add(New OracleParameter("InvID", "A01"))
                _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Sample invoice"))
                _cmdObj.ExecuteNonQuery()
                MessageBox.Show("Invoice record created successfully")

                'Intentionally cause an exception
                _cmdObj.CommandText = "INSERT INTO NonExistentTable(InvID, Description, Quantity, UnitPrice) VALUES(:InvID, :Description, :Quantity, :UnitPrice)"
                _cmdObj.Parameters.Clear()
                _cmdObj.Parameters.Add(New OracleParameter("InvID", "A01"))
                _cmdObj.Parameters.Add(New OracleParameter("Description", "Exhaust pipe"))
                _cmdObj.Parameters.Add(New OracleParameter("Quantity", "5"))
                _cmdObj.Parameters.Add(New OracleParameter("UnitPrice", "99.50"))
                _cmdObj.ExecuteNonQuery()
                _tranObj.Commit()

            Catch
            Finally
                _connObj.Close()
                _connObj.Dispose()
                _connObj = Nothing
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _tranObj As OracleTransaction
            _connObj.Open()
            _tranObj = _connObj.BeginTransaction()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            Try
                _cmdObj.CommandText = "proc_InsertSamplePODetails"
                _cmdObj.CommandType = CommandType.StoredProcedure
                _cmdObj.Parameters.Clear()
                _cmdObj.ExecuteNonQuery()
                MessageBox.Show("Stored proc run successfully")

                'Intentionally cause an exception
                _cmdObj.CommandText = "INSERT INTO NonExistentTable(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)"
                _cmdObj.CommandType = CommandType.Text
                _cmdObj.Parameters.Clear()
                _cmdObj.Parameters.Add(New OracleParameter("InvID", "A02"))
                _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Sample invoice 2"))
                _cmdObj.ExecuteNonQuery()
                _tranObj.Commit()

            Catch ex As Exception
                MessageBox.Show("Uh oh, rollback initiated...")
                _tranObj.Rollback()
            Finally
                _connObj.Close()
                _connObj.Dispose()
                _connObj = Nothing
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _tranObj As OracleTransaction
            _connObj.Open()
            _tranObj = _connObj.BeginTransaction()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            Try
                'Clear the appropriate tables first
                _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='A01'"
                _cmdObj.ExecuteNonQuery()
                _cmdObj.CommandText = "DELETE FROM InvoiceDetails WHERE InvID='A01'"
                _cmdObj.ExecuteNonQuery()

                _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)"
                _cmdObj.Parameters.Add(New OracleParameter("InvID", "A01"))
                _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Sample invoice"))
                _cmdObj.ExecuteNonQuery()
                _tranObj.Save("MySavepoint1")
                MessageBox.Show("Invoice record created successfully")
                _cmdObj.CommandText = "INSERT INTO InvoiceDetails(InvID, Description, Quantity, UnitPrice) VALUES(:InvID, :Description, :Quantity, :UnitPrice)"
                _cmdObj.Parameters.Clear()
                _cmdObj.Parameters.Add(New OracleParameter("InvID", "A01"))
                _cmdObj.Parameters.Add(New OracleParameter("Description", "Exhaust pipe"))
                _cmdObj.Parameters.Add(New OracleParameter("Quantity", "5"))
                _cmdObj.Parameters.Add(New OracleParameter("UnitPrice", "99.50"))
                _cmdObj.ExecuteNonQuery()
                _tranObj.Save("MySavepoint2")
                MessageBox.Show("Invoicedetails record created successfully")
                _cmdObj.CommandText = "INSERT INTO NonExistentTable(InvID, Description, Quantity, UnitPrice) VALUES(:InvID, :Description, :Quantity, :UnitPrice)"
                _cmdObj.Parameters.Clear()
                _cmdObj.Parameters.Add(New OracleParameter("InvID", "B01"))
                _cmdObj.Parameters.Add(New OracleParameter("Description", "Windshield wipers"))
                _cmdObj.Parameters.Add(New OracleParameter("Quantity", "20"))
                _cmdObj.Parameters.Add(New OracleParameter("UnitPrice", "25.50"))
                _cmdObj.ExecuteNonQuery()
                _tranObj.Save("MySavepoint3")
                _tranObj.Commit()

            Catch
            Finally
                _connObj.Close()
                _connObj.Dispose()
                _connObj = Nothing
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button3_Click


    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        Dim _ts As New TransactionScope()
        Try
            Try

                'Connect to the first database instance
                Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
                Dim _connObj As New OracleConnection(_connstring)
                _connObj.Open()
                Dim _cmdObj As OracleCommand = _connObj.CreateCommand()

                'Clear the appropriate tables
                _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='B01'"
                _cmdObj.ExecuteNonQuery()

                'Create a new record in the first database instance
                _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)"
                _cmdObj.Parameters.Add(New OracleParameter("InvID", "B01"))
                _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Sample invoice"))
                _cmdObj.ExecuteNonQuery()
                MessageBox.Show("Invoice record created in first database instance successfully")
                _connObj.Close()
                _connObj.Dispose()
                _connObj = Nothing

                'Connect to the second database instance
                _connstring = "Data Source=localhost/SECONDDB;User Id=SYSTEM;Password=admin;"
                _connObj = New OracleConnection(_connstring)
                _connObj.Open()
                _cmdObj = _connObj.CreateCommand()
                'Intentionally cause an exception
                _cmdObj.CommandText = "INSERT INTO NonExistentTable(ReceiptID, ReceiptDate, Remarks) VALUES(:ReceiptID, SYSDATE, :Remarks)"
                _cmdObj.Parameters.Add(New OracleParameter("ReceiptID", "R01"))
                _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Sample receipt"))
                _cmdObj.ExecuteNonQuery()
                _connObj.Close()
                _connObj.Dispose()
                _connObj = Nothing
                _ts.Complete()
            Catch ex As Exception
                MessageBox.Show("Error encountered : The created Invoice record should now be rolled back automatically")
            End Try
        Finally
            _ts.Dispose()
        End Try
    End Sub 'button4_Click


    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        Dim _cmtTran As New CommittableTransaction()
        Try
            'Connect to the first database instance and create a new record in
            'the Invoice table
            Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()

            'Clear the appropriate tables
            _cmdObj.CommandText = "DELETE FROM Invoice WHERE InvID='B01'"
            _cmdObj.ExecuteNonQuery()

            _connObj.EnlistTransaction(_cmtTran)
            _cmdObj.CommandText = "INSERT INTO Invoice(InvID, InvDate, Remarks) VALUES(:InvID, SYSDATE, :Remarks)"
            _cmdObj.Parameters.Add(New OracleParameter("InvID", "B01"))
            _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Sample invoice"))
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("Invoice record inserted successfully")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            'Connect to the second database instance and create a new record in
            'the Receipt table
            _connstring = "Data Source=localhost/SECONDDB;User Id=SYSTEM;Password=admin;"
            _connObj = New OracleConnection(_connstring)
            _connObj.Open()
            _connObj.EnlistTransaction(_cmtTran)
            _cmdObj = _connObj.CreateCommand()
            _cmdObj.CommandText = "INSERT INTO Receipt(ReceiptID, ReceiptDate, Remarks) VALUES(:ReceiptID, SYSDATE, :Remarks)"
            _cmdObj.Parameters.Add(New OracleParameter("ReceiptID", "R01"))
            _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Sample receipt"))
            _cmdObj.ExecuteNonQuery()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            _cmtTran.Commit()

        Catch ex As Exception
            _cmtTran.Rollback()
            MessageBox.Show("Uh oh, rollback initiated...")
        End Try
    End Sub 'button5_Click
End Class 'Main
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected