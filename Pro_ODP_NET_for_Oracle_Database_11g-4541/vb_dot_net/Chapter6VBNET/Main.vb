Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Oracle.DataAccess.Types
Imports Oracle.DataAccess.Client


Namespace Chapter_6
End Namespace 'Chapter_6
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
        Dim _query As New UpdatingDoubleByteData()
        _query.ShowDialog()
        _query.Dispose()
        _query = Nothing
    End Sub 'button1_Click


    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _result As String
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT RemarksInJapanese FROM Products"
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            _result = "Results:"
            If _reader.HasRows Then
                While _reader.Read()
                    If _reader.IsDBNull(_reader.GetOrdinal("RemarksInJapanese")) = False Then
                        Dim _price As [String] = _reader.GetString(_reader.GetOrdinal("RemarksInJapanese"))
                        _result = _result + ControlChars.Lf + _price.ToString()
                    End If
                End While
            End If
            MessageBox.Show(_result)
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button2_Click


    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim info As OracleGlobalization = OracleGlobalization.GetClientInfo()
            info.Language = "ITALIAN"
            _connObj.SetSessionInfo(info)
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT NonExistentField FROM Products"
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub 'button3_Click


    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _result As String
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim info As OracleGlobalization = OracleGlobalization.GetClientInfo()
            info.DateLanguage = "FINNISH"
            info.DateFormat = "DD-MON-YYYY"
            OracleGlobalization.SetThreadInfo(info)
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT ExpiryDate FROM Products ORDER BY ExpiryDate ASC"
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            _result = "Results:"
            If _reader.HasRows Then
                While _reader.Read()
                    Dim _odate As OracleDate = _reader.GetOracleDate(_reader.GetOrdinal("ExpiryDate"))
                    _result = _result + ControlChars.Lf + _odate.ToString()
                End While
            End If
            MessageBox.Show(_result)
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button4_Click


    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _result As String
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim info As OracleGlobalization = OracleGlobalization.GetClientInfo()
            info.Currency = "¥"
            _connObj.SetSessionInfo(info)
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT TO_CHAR(Price,'L99G999D99') Price FROM Products WHERE Price IS NOT NULL"
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            _result = "Results:"
            If _reader.HasRows Then
                While _reader.Read()
                    Dim _price As [String] = _reader.GetString(_reader.GetOrdinal("Price"))
                    _result = _result + ControlChars.Lf + _price
                End While
            End If
            MessageBox.Show(_result)
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button5_Click


    Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _result As String
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim info As OracleGlobalization = OracleGlobalization.GetClientInfo()
            info.ISOCurrency = "AUSTRALIA"
            _connObj.SetSessionInfo(info)
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT TO_CHAR(Price,'C99G999D99') Price FROM Products"
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            _result = "Results:"
            If _reader.HasRows Then
                While _reader.Read()
                    Dim _price As [String] = _reader.GetString(_reader.GetOrdinal("Price"))
                    _result = _result + ControlChars.Lf + _price.ToString()
                End While
            End If
            MessageBox.Show(_result)
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button6_Click


    Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim info As OracleGlobalization = OracleGlobalization.GetClientInfo()
            info.Territory = "Hong Kong"
            info.TimeZone = "Asia/Hong_Kong"
            OracleGlobalization.SetThreadInfo(info)
            _connObj.SetSessionInfo(info)
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT LaunchDate AT LOCAL LaunchDateLocal FROM Products"
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            If _reader.HasRows Then
                If _reader.Read() Then
                    Dim _launchDate As OracleTimeStampTZ = _reader.GetOracleTimeStampTZ(_reader.GetOrdinal("LaunchDateLocal"))
                    MessageBox.Show(_launchDate.ToString())
                End If
            End If
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button7_Click


    Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
        Dim _connstring As [String] = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _result As String
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT Name FROM Products ORDER BY Name ASC"
            Dim info As OracleGlobalization = OracleGlobalization.GetClientInfo()
            info.Sort = "SPANISH_M"
            _connObj.SetSessionInfo(info)
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            _result = "Results:"
            If _reader.HasRows Then
                While _reader.Read()
                    Dim _Name As [String] = _reader.GetString(_reader.GetOrdinal("Name"))
                    _result = _result + ControlChars.Lf + _Name.ToString()
                End While
            End If
            MessageBox.Show(_result)
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button8_Click


    Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _result As String
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim info As OracleGlobalization = OracleGlobalization.GetClientInfo()
            info.Territory = "Sweden"
            info.Language = "Swedish"
            OracleGlobalization.SetThreadInfo(info)
            _connObj.SetSessionInfo(info)
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            _cmdObj.CommandText = "SELECT TO_CHAR(Price,'L99G999D99') PriceDefCurrency, TO_CHAR(Price,'U99G999D99') PriceDualCurrency, TO_CHAR(ExpiryDate,'DL') ExpiryDate FROM Products WHERE ID='E1'"
            Dim _reader As OracleDataReader = _cmdObj.ExecuteReader()
            If _reader.HasRows Then
                If _reader.Read() Then
                    Dim _priceDefCurrency As [String] = _reader.GetString(_reader.GetOrdinal("PriceDefCurrency"))
                    Dim _priceDualCurrency As [String] = _reader.GetString(_reader.GetOrdinal("PriceDualCurrency"))
                    Dim _expiryDate As [String] = _reader.GetString(_reader.GetOrdinal("ExpiryDate"))
                    _result = _priceDefCurrency + ControlChars.Lf + _priceDualCurrency + ControlChars.Lf + _expiryDate
                    MessageBox.Show(_result)
                End If
            End If
            _reader.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _reader.Close()
            _connObj.Close()
            _reader = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'button9_Click


    Private Sub button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button10.Click
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Try
            Dim _connObj As New OracleConnection()
            _connObj.ConnectionString = _connstring
            _connObj.Open()
            Dim _cmdObj As OracleCommand = _connObj.CreateCommand()
            Dim _datasetObj As New DataSet()
            _cmdObj.CommandText = "SELECT LaunchDate FROM Products WHERE LaunchDate IS NOT NULL"
            'Without safe mapping
            Dim _adapterObj As New OracleDataAdapter(_cmdObj)
            _adapterObj.Fill(_datasetObj)
            'Display the data type name and the data
            MessageBox.Show(("Type:" + _datasetObj.Tables(0).Rows(0)("LaunchDate").GetType().ToString() + ControlChars.Lf + "Data:" + Convert.ToString(_datasetObj.Tables(0).Rows(0)("LaunchDate"))))
            'With safe mapping
            _datasetObj = New DataSet()
            _adapterObj.SafeMapping.Add("LAUNCHDATE", GetType(String))
            _adapterObj.Fill(_datasetObj)
            'Display the data type name and the data again
            MessageBox.Show(("Type:" + _datasetObj.Tables(0).Rows(0)("LaunchDate").GetType().ToString() + ControlChars.Lf + "Data:" + Convert.ToString(_datasetObj.Tables(0).Rows(0)("LaunchDate"))))
            _adapterObj.Dispose()
            _cmdObj.Dispose()
            _connObj.Dispose()
            _connObj.Close()
            _adapterObj = Nothing
            _connObj = Nothing
            _cmdObj = Nothing
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