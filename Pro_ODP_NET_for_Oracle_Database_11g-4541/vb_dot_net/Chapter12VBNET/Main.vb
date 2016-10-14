Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types



Namespace Chapter_12
End Namespace 'Chapter_12
 _
Class Main
    Inherits Form
    '
    Public Sub New()
        InitializeComponent()
    End Sub 'New


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Pooling=false"
        Try
            'Open and close connections 10 times without connection pooling enabled
            Dim _connObj As New OracleConnection(_connstring)
            _stopwatch.Start()
            Dim i As Integer
            For i = 1 To 10
                _connObj.Open()
                _connObj.Close()
            Next i
            _stopwatch.Stop()
            _Results = "Without connection pooling:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Open and close connections 10 times with connection pooling enabled
            _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Pooling=true"
            _connObj = New OracleConnection(_connstring)
            _stopwatch.Reset()
            _stopwatch.Start()
            For i = 1 To 10
                _connObj.Open()
                _connObj.Close()
            Next i
            _stopwatch.Stop()
            _Results = _Results + "With connection pooling:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            'Adding NUMBERs
            _cmdObj.CommandText = "DECLARE" + " Number1 NUMBER:=1;" + " Number2 NUMBER:=1;" + "BEGIN" + " FOR i IN 1 .. 1000000 LOOP" + " Number1:=Number1 + Number2;" + " END LOOP;" + "END;"
            _stopwatch.Start()
            _cmdObj.ExecuteNonQuery()
            _stopwatch.Stop()
            _Results = "Adding NUMBERs:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Adding BINARY_FLOAT numbers
            _cmdObj.CommandText = "DECLARE" + " BinaryFloat1 BINARY_FLOAT:=1;" + " BinaryFloat2 BINARY_FLOAT:=1;" + "BEGIN" + " FOR i IN 1 .. 1000000 LOOP" + " BinaryFloat1:=BinaryFloat1 + BinaryFloat2;" + " END LOOP;" + "END;"
            _stopwatch.Reset()
            _stopwatch.Start()
            _cmdObj.ExecuteNonQuery()
            _stopwatch.Stop()
            _Results = _Results + "Adding BINARY_FLOATs:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Adding BINARY_DOUBLE numbers
            _cmdObj.CommandText = "DECLARE" + " BinaryDouble1 BINARY_DOUBLE:=1;" + " BinaryDouble2 BINARY_DOUBLE:=1;" + "BEGIN" + " FOR i IN 1 .. 1000000 LOOP" + " BinaryDouble1:=BinaryDouble1 + " + " BinaryDouble2;" + " END LOOP;" + "END;"
            _stopwatch.Reset()
            _stopwatch.Start()
            _cmdObj.ExecuteNonQuery()
            _stopwatch.Stop()
            _Results = _Results + "Adding BINARY_DOUBLEs:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            'Update 10,000 products in separate statements
            _stopwatch.Start()
            Dim i As Integer
            For i = 1 To 10000
                _cmdObj.CommandText = "UPDATE Products SET Name='Test" + Convert.ToString(i) + "' WHERE ID='E1'"
                _cmdObj.ExecuteNonQuery()
            Next i
            _stopwatch.Stop()
            _Results = "Without Batch SQL:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Update 10,000 products in batch
            _cmdObj.CommandText = "BEGIN" + " FOR i IN 1 .. 10000 LOOP" + " UPDATE Products SET Name='Test' || i WHERE" + " ID='E1';" + " END LOOP;" + "END;"
            _stopwatch.Reset()
            _stopwatch.Start()
            _cmdObj.ExecuteNonQuery()
            _stopwatch.Stop()
            _Results = _Results + "With Batch SQL:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button3_Click


    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Try
            'Retrieve 10,000 products with statement caching disabled
            'Setting a cache size of 0 automatically disables the statement cache
            Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Statement Cache Size=0;Self Tuning=false;"
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _stopwatch.Start()
            _cmdObj.CommandText = "SELECT * FROM Products WHERE ID=:IDValue"
            Dim _paramObj As OracleParameter = _cmdObj.Parameters.Add("IDValue", OracleDbType.Varchar2)
            Dim i As Integer
            For i = 1 To 10000
                _paramObj.Value = "E" + Convert.ToString(i)
                Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
                _rdrObj.Dispose()
            Next i
            _stopwatch.Stop()
            _Results = "Without Statement Caching:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            _cmdObj.Dispose()
            _connObj.Close()

            'Retrieve 10,000 products with statement caching enabled
            _connstring = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;Statement Cache Size=5;Self Tuning=false;"
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            _cmdObj = _connObj.CreateCommand()
            _stopwatch.Reset()
            _stopwatch.Start()
            _cmdObj.CommandText = "SELECT * FROM Products WHERE ID=:IDValue"
            _paramObj = _cmdObj.Parameters.Add("IDValue", OracleDbType.Varchar2)
            For i = 1 To 10000
                _paramObj.Value = "E" + Convert.ToString(i)
                Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
                _rdrObj.Dispose()
            Next i
            _stopwatch.Stop()
            _Results = _Results + "With Statement Caching:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            _cmdObj.Dispose()
            _connObj.Close()
            MessageBox.Show(_Results)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button4_Click


    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            'Clear the table
            Dim _cmdDelObj As OracleCommand = _connObj.CreateCommand()
            _cmdDelObj.CommandText = "DELETE FROM Products"
            _cmdDelObj.ExecuteNonQuery()
            'Perform 10,000 iterations, inserting 3 records in every iteration without
            'using bind arrays
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Price) VALUES(:ID, :Name, :Price)"
            Dim _IDParam As New OracleParameter("ID", OracleDbType.Varchar2)
            _cmdObj.Parameters.Add(_IDParam)
            Dim _nameParam As New OracleParameter("Name", OracleDbType.Varchar2)
            _cmdObj.Parameters.Add(_nameParam)
            Dim _priceParam As New OracleParameter("Price", OracleDbType.Decimal)
            _cmdObj.Parameters.Add(_priceParam)
            _stopwatch.Start()
            Dim i As Integer
            For i = 1 To 10000
                _IDParam.Value = "EN" + Convert.ToString(i)
                _nameParam.Value = "Engine" + Convert.ToString(i)
                _priceParam.Value = 100
                _cmdObj.ExecuteNonQuery()
                _IDParam.Value = "WS" + Convert.ToString(i)
                _nameParam.Value = "Windshield" + Convert.ToString(i)
                _priceParam.Value = 300
                _cmdObj.ExecuteNonQuery()
                _IDParam.Value = "RL" + Convert.ToString(i)
                _nameParam.Value = "Rear Lights" + Convert.ToString(i)
                _priceParam.Value = 500
                _cmdObj.ExecuteNonQuery()
            Next i
            _stopwatch.Stop()
            _Results = "Without bind arrays:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Clear the table again
            _cmdDelObj.ExecuteNonQuery()
            _cmdDelObj.Dispose()
            'Perform 10,000 iterations, inserting 3 records in every iteration using
            'bind arrays
            _cmdObj.ArrayBindCount = 3
            _stopwatch.Reset()
            _stopwatch.Start()
            For i = 1 To 10000
                Dim _priceArray(3) As Integer
                _priceArray(0) = 100
                _priceArray(1) = 300
                _priceArray(2) = 500

                Dim _nameArray(3) As String
                _nameArray(0) = "Engine" + Convert.ToString(i)
                _nameArray(1) = "Windshield" + Convert.ToString(i)
                _nameArray(2) = "Rear Lights" + Convert.ToString(i)

                Dim _IDArray(3) As String
                _IDArray(0) = "EN" + Convert.ToString(i)
                _IDArray(1) = "WS" + Convert.ToString(i)
                _IDArray(2) = "RL" + Convert.ToString(i)

                _IDParam.Value = _IDArray
                _nameParam.Value = _nameArray
                _priceParam.Value = _priceArray
                _cmdObj.ExecuteNonQuery()
            Next i
            _stopwatch.Stop()
            _cmdObj.Dispose()
            _Results = _Results + "With Bind Arrays:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button5_Click


    Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            'Perform 1000 iterations, updating 3 records in each iteration without
            'using associative arrays
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "UPDATE Products SET Price = Price + :ProdPrice WHERE Name = :ProdName"
            Dim _priceParam As New OracleParameter("ProdPrice", OracleDbType.Decimal)
            _cmdObj.Parameters.Add(_priceParam)
            Dim _nameParam As New OracleParameter("ProdName", OracleDbType.Varchar2)
            _cmdObj.Parameters.Add(_nameParam)
            _stopwatch.Start()
            Dim i As Integer
            For i = 1 To 1000
                _priceParam.Value = 100
                _nameParam.Value = "Engine"
                _cmdObj.ExecuteNonQuery()
                _priceParam.Value = 300
                _nameParam.Value = "Windshield"
                _cmdObj.ExecuteNonQuery()
                _priceParam.Value = 500
                _nameParam.Value = "Rear Lights"
                _cmdObj.ExecuteNonQuery()
            Next i
            _stopwatch.Stop()
            _cmdObj.Dispose()
            _Results = "Without arrays:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Perform 1000 iterations, updating 3 records in each iteration using
            'associative arrays
            _cmdObj = _connObj.CreateCommand()
            _cmdObj.CommandText = "ProductsPackage.proc_UpdateMultiplePrices"
            _cmdObj.CommandType = CommandType.StoredProcedure
            'Declare first parameter
            _priceParam = New OracleParameter()
            _priceParam.ParameterName = "ProdPrices"
            _priceParam.OracleDbType = OracleDbType.Decimal
            _priceParam.Direction = ParameterDirection.Input
            _priceParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            _cmdObj.Parameters.Add(_priceParam)
            'Declare second parameter
            _nameParam = New OracleParameter()
            _nameParam.ParameterName = "ProdNames"
            _nameParam.OracleDbType = OracleDbType.Varchar2
            _nameParam.Direction = ParameterDirection.Input
            _nameParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            _cmdObj.Parameters.Add(_nameParam)
            _stopwatch.Reset()
            _stopwatch.Start()
            For i = 1 To 1000
                Dim decArray(3) As [Decimal]
                decArray(0) = 100
                decArray(1) = 300
                decArray(2) = 500
                _priceParam.Value = decArray
                Dim stringArray(3) As [String]
                stringArray(0) = "Engine"
                stringArray(1) = "Windshield"
                stringArray(2) = "Rear Lights"
                _nameParam.Value = stringArray
                _cmdObj.ExecuteNonQuery()
            Next i
            _stopwatch.Stop()
            _cmdObj.Dispose()
            _Results = _Results + "With Associative Arrays:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button6_Click


    Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
        If MessageBox.Show("This test will assume that a BLOB has been uploaded into the Products table for the product ID 'E1'. Please upload a BLOB if you have not. You can do so using the sample in Chapter 4. Would you like to proceed?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
            Return
        End If 'We first read the full contents of the file into a byte array
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            Dim _rdrObj As OracleDataReader
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            'Disable the Cache
            _cmdObj.CommandText = "ALTER TABLE ProductFiles MODIFY LOB(FileAttachment) (NOCACHE)"
            _cmdObj.ExecuteNonQuery()
            _cmdObj.CommandText = "SELECT FileAttachment FROM ProductFiles WHERE ProductID=:ProductID"
            _cmdObj.Parameters.Add(New OracleParameter("ProductID", "E1"))
            _stopwatch.Start()
            Dim i As Integer
            For i = 1 To 100
                _rdrObj = _cmdObj.ExecuteReader()
                If _rdrObj.HasRows Then
                    If _rdrObj.Read() Then
                        Dim _blobObj As OracleBlob = _rdrObj.GetOracleBlob(_rdrObj.GetOrdinal("FileAttachment"))
                        Dim dest(_blobObj.Length) As Byte
                        _blobObj.Read(dest, 0, CInt(_blobObj.Length))
                    End If
                Else
                    MessageBox.Show("The BLOB was not found!")
                End If
            Next i
            _stopwatch.Stop()
            _cmdObj.Dispose()
            _Results = "Without LOB caching:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Enable the Cache
            _cmdObj = _connObj.CreateCommand()
            _cmdObj.CommandText = "ALTER TABLE ProductFiles MODIFY LOB(FileAttachment) (CACHE)"
            _cmdObj.ExecuteNonQuery()
            _cmdObj.CommandText = "SELECT FileAttachment FROM ProductFiles WHERE ProductID=:ProductID"
            _cmdObj.Parameters.Add(New OracleParameter("ProductID", "E1"))
            _stopwatch.Reset()
            _stopwatch.Start()

            For i = 1 To 100
                _rdrObj = _cmdObj.ExecuteReader()
                If _rdrObj.HasRows Then
                    If _rdrObj.Read() Then
                        Dim _blobObj As OracleBlob = _rdrObj.GetOracleBlob(_rdrObj.GetOrdinal("FileAttachment"))
                        Dim dest(_blobObj.Length) As Byte
                        _blobObj.Read(dest, 0, CInt(_blobObj.Length))
                    End If
                Else
                    MessageBox.Show("The BLOB was not found!")
                End If
            Next i
            _stopwatch.Stop()
            _Results = _Results + "With LOB Caching:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
            _connObj.Dispose()
            _connObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button7_Click


    Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            'Insert 10,000 dummy records into the Products table
            _cmdObj.CommandText = "DELETE FROM Products"
            _cmdObj.ExecuteNonQuery()
            Dim i As Integer
            For i = 1 To 10000
                _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Remarks) VALUES('E" + Convert.ToString(i) + "','TestData','')"
                _cmdObj.ExecuteNonQuery()
            Next i
            MessageBox.Show("10,000 products inserted")
            'Read all 10,000 products from the same table using the default FetchSize
            'of 64K
            _cmdObj.CommandText = "SELECT * FROM Products"
            _stopwatch.Start()
            Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
            While _rdrObj.Read()
            End While
            _stopwatch.Stop()
            _Results = "Default Fetchsize (64Kb):" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Set the FetchSize to accommodate for 10,000 rows and execute the same
            'query again
            _stopwatch.Reset()
            _stopwatch.Start()
            _rdrObj = _cmdObj.ExecuteReader()
            Dim _newFetchSize As Long = _rdrObj.RowSize * 10000
            _rdrObj.FetchSize = _newFetchSize
            While _rdrObj.Read()
            End While
            _stopwatch.Stop()
            _Results = _Results + "Fetchsize (" + Convert.ToString(_newFetchSize) + "):" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button8_Click


    Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            'Insert 1,000 dummy records into the Products table
            _cmdObj.CommandText = "DELETE FROM Products"
            _cmdObj.ExecuteNonQuery()
            Dim i As Integer
            For i = 1 To 1000
                _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Remarks) VALUES('E" + Convert.ToString(i) + "','TestData','')"
                _cmdObj.ExecuteNonQuery()
            Next i
            MessageBox.Show("1,000 products inserted")
            'Retrieve 1,000 rows without using the client result cache
            _cmdObj.CommandText = "SELECT * FROM Products"
            _stopwatch.Start()

            For i = 1 To 1000
                Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
                While _rdrObj.Read()
                End While
                _rdrObj.Close()
            Next i
            _stopwatch.Stop()
            _Results = "No client result cache:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            'Retrieve 1,000 rows using the client result cache
            _cmdObj.CommandText = "SELECT /*+ result_cache */ * FROM Products"
            _stopwatch.Reset()
            _stopwatch.Start()

            For i = 1 To 1000
                Dim _rdrObj As OracleDataReader = _cmdObj.ExecuteReader()
                While _rdrObj.Read()
                End While
                _rdrObj.Close()
            Next i
            _stopwatch.Stop()
            _Results = _Results + "With client result cache:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            MessageBox.Show(_Results)
            _connObj.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button9_Click


    Private Sub button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button10.Click

        Dim _stopwatch As New Stopwatch()
        Dim _Results As [String]
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()

            'Clear all products
            _cmdObj.CommandText = "DELETE FROM Products"
            _cmdObj.ExecuteNonQuery()


            _cmdObj.CommandText = "INSERT INTO Products(ID, Name, Price) VALUES(:ID, :Name, :Price)"
            Dim _IDParam As New OracleParameter("ID", OracleDbType.Varchar2)
            _cmdObj.Parameters.Add(_IDParam)
            Dim _nameParam As New OracleParameter("Name", OracleDbType.Varchar2)
            _cmdObj.Parameters.Add(_nameParam)
            Dim _priceParam As New OracleParameter("Price", OracleDbType.Decimal)
            _cmdObj.Parameters.Add(_priceParam)

            _stopwatch.Start()
            Dim i As Integer
            For i = 1 To 50000
                _IDParam.Value = "E" + Convert.ToString(i)
                _nameParam.Value = "Test Product" + Convert.ToString(i)
                _priceParam.Value = 100
                _cmdObj.ExecuteNonQuery()
            Next i
            _stopwatch.Stop()
            _cmdObj.Dispose()

            'Oracle Bulk Copy
            _Results = "Without Oracle Bulk Copy:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            _cmdObj = _connObj.CreateCommand()
            _cmdObj.CommandText = "DELETE FROM Products"
            _cmdObj.ExecuteNonQuery()
            _cmdObj.Dispose()


            Dim _dataTbl As New DataTable("SourceTable")
            _dataTbl.Columns.Add(New DataColumn("ID", System.Type.GetType("System.String")))
            _dataTbl.Columns.Add(New DataColumn("Name", System.Type.GetType("System.String")))
            _dataTbl.Columns.Add(New DataColumn("Price", System.Type.GetType("System.String")))

            _stopwatch.Reset()
            _stopwatch.Start()

            For i = 1 To 50000
                Dim _newrow As DataRow = _dataTbl.NewRow()
                _newrow("ID") = "E" + Convert.ToString(i)
                _newrow("Name") = "Test Product" + Convert.ToString(i)
                _newrow("Price") = 100
                _dataTbl.Rows.Add(_newrow)
            Next i
            _stopwatch.Stop()

            Dim _bulkCopy As New OracleBulkCopy(_connObj)
            _bulkCopy.DestinationTableName = "Products"
            _stopwatch.Start()
            _bulkCopy.WriteToServer(_dataTbl)
            _stopwatch.Stop()
            _Results += "With Oracle Bulk Copy:" + ControlChars.Tab + _stopwatch.Elapsed.TotalSeconds.ToString() + " seconds" + ControlChars.Lf
            _bulkCopy.Close()
            _bulkCopy.Dispose()
            _bulkCopy = Nothing

            MessageBox.Show(_Results)
            _connObj.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button10_Click 

    
End Class 'Main
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected