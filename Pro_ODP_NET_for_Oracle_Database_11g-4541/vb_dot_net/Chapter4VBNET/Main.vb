Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types


Namespace Chapter_4
End Namespace 'Chapter_4
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
        Dim _ID As String
        Dim _name As String
        Dim _price As Decimal
        Dim _remarks As String
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT * FROM Products"
            Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
            If _rdrObj.HasRows Then
                While _rdrObj.Read()
                    _ID = _rdrObj.GetString(_rdrObj.GetOrdinal("ID"))
                    _name = _rdrObj.GetString(_rdrObj.GetOrdinal("Name"))
                    _price = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Price"))
                    _remarks = _rdrObj.GetString(_rdrObj.GetOrdinal("Remarks"))
                    MessageBox.Show("ID: " + _ID + vbCrLf + "Name: " + _name + vbCrLf + "Price: " + _price + vbCrLf + "Remarks: " + _remarks, "Products")
                End While
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _totalRecords As Decimal
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT COUNT(*) AS TotalRecords FROM Products"
            _totalRecords = CDec(_cmdObj.ExecuteScalar())
            MessageBox.Show(("Total records:" + _totalRecords))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _query As New RetrievingDataIntoDataset()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button3_Click


    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        Dim _query As New ParameterizedQueries()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button4_Click


    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        Dim _connstring As String
        _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _recordsAffected As Integer
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            'Insert a new record
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Price) VALUES(:ID,:Name,:Price)"
            _cmdObj.Parameters.Add(New OracleParameter("ID", "M1"))
            _cmdObj.Parameters.Add(New OracleParameter("Name", "Mudguards"))
            _cmdObj.Parameters.Add(New OracleParameter("Price", "250.50"))
            _recordsAffected = _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Total records affected after insert:" + _recordsAffected))
            'Update an existing record
            _cmdObj.CommandText = "UPDATE Products SET Remarks=:Remarks WHERE ID=:ID"
            _cmdObj.Parameters.Clear()
            _cmdObj.Parameters.Add(New OracleParameter("Remarks", "Quality mudguards"))
            _cmdObj.Parameters.Add(New OracleParameter("ID", "M1"))
            _recordsAffected = _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Total records affected after update:" + _recordsAffected))
            'Delete an existing record
            _cmdObj.CommandText = "DELETE FROM Products WHERE ID=:ID"
            _cmdObj.Parameters.Clear()
            _cmdObj.Parameters.Add(New OracleParameter("ID", "M1"))
            _recordsAffected = _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Total records affected after delete:" + _recordsAffected))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button5_Click


    Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        Dim _query As New CommittingChangesToDatabase()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button6_Click


    Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _sql As String
        Dim _ds As New DataSet()
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            _sql = "SELECT * FROM Products"
            Dim _adapterObj As New OracleDataAdapter(_sql, _connObj)
            _adapterObj.Fill(_ds)
            Dim _commBldrObj As New OracleCommandBuilder(_adapterObj)
            'We must specify the unique column in the dataset so that the
            'OracleCommandBuilder knows which field to use as the primary key when
            'generating the UpdateCommand and DeleteCommand objects
            _ds.Tables(0).Columns("ID").Unique = True
            _adapterObj.Update(_ds)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
            MessageBox.Show("Dataset committed!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button7_Click


    Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
        Dim _query As New FormBinding()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button8_Click


    Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
        'We first read the full contents of the file into a byte array
        Dim _query As New InsertBLOBData()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button9_Click


    Private Sub button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button10.Click
        Dim _query As New RetrieveBLOBData()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button10_Click


    Private Sub button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button11.Click
        Dim _query As New InsertCLOBData()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button11_Click


    Private Sub button12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button12.Click
        Dim _query As New RetrieveCLOBData()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button12_Click


    Private Sub button13_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button13.Click
        Dim _query As New InsertBFILE()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button13_Click


    Private Sub button14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button14.Click
        Dim _query As New RetrieveBFile()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button14_Click


    Private Sub button15_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button15.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _recordsAffected As Integer
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            'Insert a new record
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "INSERT INTO GUIDTest(GUID, Name) VALUES(:GUID,:Name)"
            Dim _rawObj As New OracleParameter("GUID", OracleDbType.Raw)
            _rawObj.Value = System.Guid.NewGuid().ToByteArray()
            _cmdObj.Parameters.Add(_rawObj)
            _cmdObj.Parameters.Add(New OracleParameter("Name", "Test1"))
            _recordsAffected = _cmdObj.ExecuteNonQuery()
            MessageBox.Show(("Total records affected after insert:" + _recordsAffected))
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button15_Click


    Private Sub button16_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button16.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _sql As String
        Dim _rdrObj As OracleDataReader
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _ds As New DataSet()
            _connObj.Open()
            _sql = "SELECT GUID FROM GUIDTest"
            Dim _cmdObj As New OracleCommand(_sql, _connObj)
            _rdrObj = _cmdObj.ExecuteReader()
            If _rdrObj.HasRows Then
                If _rdrObj.Read() Then
                    Dim _binaryObj As OracleBinary = _rdrObj.GetOracleBinary(_rdrObj.GetOrdinal("GUID"))
                    Dim _GUIDObj As New System.Guid(_binaryObj.Value)
                    MessageBox.Show(("The GUID retrieved is: " + _GUIDObj.ToString()))
                End If
            End If
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button16_Click


    Private Sub button17_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button17.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "ALTER TABLE PRODUCTS ADD (SPECIALREMARKS VARCHAR2(255))"
            _cmdObj.ExecuteNonQuery()
            MessageBox.Show("New column added!")
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button17_Click


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'Form1_Load



    Private Sub button18_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button18.Click
        Dim _query As New DiscoverSchema()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button18_Click


    Private Sub button19_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button19.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _sql As String
        Dim _rdrObj As OracleDataReader
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _ds As New DataSet()
            _connObj.Open()
            'Intentionally run an incorrect query
            _sql = "SELECT aaa FROM bbb WHERE ccc=ddd"
            Dim _cmdObj As New OracleCommand(_sql, _connObj)
            _rdrObj = _cmdObj.ExecuteReader()
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As OracleException
            MessageBox.Show("Oracle Error Number: " & ex.Number.ToString() & vbCrLf & "Source: " & ex.Source.ToString & vbCrLf & "Data source: " & ex.DataSource.ToString & vbCrLf & "Procedure: " & ex.Procedure & vbCrLf & "Message: " & ex.Message.ToString & vbCrLf & "InnerException: " & ex.InnerException.ToString)
        End Try
    End Sub 'button19_Click
End Class 'Main
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected