Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client


Namespace Chapter_4
End Namespace 'Chapter_4
 _
Class CommittingChangesToDatabase
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
    Private _ds As DataSet

    Public Sub New()
        InitializeComponent()
    End Sub 'New


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _sql As String
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _ds = New DataSet()
            _connObj.Open()
            _sql = "SELECT * FROM Products"
            Dim _adapterObj As New OracleDataAdapter(_sql, _connObj)
            _adapterObj.Fill(_ds)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            dataGridView1.DataSource = _ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _sql As String
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _commandObj As OracleCommand = _connObj.CreateCommand()
            Dim _adapterObj As New OracleDataAdapter(_commandObj)
            'Manually define the UPDATE command in the OracleDataAdapter
            _sql = "UPDATE Products SET Name=:Name, Price=:Price, Remarks=:Remarks WHERE ID=:ID"
            _adapterObj.UpdateCommand = New OracleCommand(_sql, _connObj)
            _adapterObj.UpdateCommand.Parameters.Add(New OracleParameter("Name", OracleDbType.Varchar2, 255, "Name"))
            _adapterObj.UpdateCommand.Parameters.Add(New OracleParameter("Price", OracleDbType.Decimal, 10, "Price"))
            _adapterObj.UpdateCommand.Parameters.Add(New OracleParameter("Remarks", OracleDbType.Varchar2, 4000, "Remarks"))
            _adapterObj.UpdateCommand.Parameters.Add(New OracleParameter("ID", OracleDbType.Varchar2, 10, "ID"))
            'Manually define the INSERT command in the OracleDataAdapter
            _sql = "INSERT INTO Products(Name, Price, Remarks, ID) VALUES(:Name, :Price, :Remarks, :ID)"
            _adapterObj.InsertCommand = New OracleCommand(_sql, _connObj)
            _adapterObj.InsertCommand.Parameters.Add(New OracleParameter("Name", OracleDbType.Varchar2, 255, "Name"))
            _adapterObj.InsertCommand.Parameters.Add(New OracleParameter("Price", OracleDbType.Decimal, 10, "Price"))
            _adapterObj.InsertCommand.Parameters.Add(New OracleParameter("Remarks", OracleDbType.Varchar2, 4000, "Remarks"))
            _adapterObj.InsertCommand.Parameters.Add(New OracleParameter("ID", OracleDbType.Varchar2, 10, "ID"))
            'Manually define the DELETE command in the OracleDataAdapter
            _sql = "DELETE FROM Products WHERE ID=:ID"
            _adapterObj.DeleteCommand = New OracleCommand(_sql, _connObj)
            _adapterObj.DeleteCommand.Parameters.Add(New OracleParameter("ID", OracleDbType.Varchar2, 10, "ID"))
            'Now we pass in the dataset to the DataAdapter and request it
            'to commit the changes to the database (using the command objects above)
            _adapterObj.Update(_ds)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            MessageBox.Show("Dataset committed!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click
End Class 'CommittingChangesToDatabase
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected