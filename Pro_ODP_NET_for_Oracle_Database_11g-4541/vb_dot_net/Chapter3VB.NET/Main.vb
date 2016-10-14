Imports System.ComponentModel
Imports System.Text
Imports Oracle.DataAccess.Client
Imports System.Data.Common

Namespace Chapter_3
	Partial Public Class Main
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim conn As New OracleConnection()
            conn.ConnectionString = "Data Source=localhost/NEWDB;User ID=SYSTEM;Password=admin"
            Try
                conn.Open()
                conn.Close()
                MessageBox.Show("Connection successful!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle")
            End Try
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            Dim conn As New OracleConnection()
            conn.ConnectionString = "Data Source = " & "(DESCRIPTION = " & " (ADDRESS_LIST = " & " (ADDRESS = (PROTOCOL = TCP)" & " (HOST = 127.0.0.1) " & " (PORT = 1521) " & " )" & " )" & " (CONNECT_DATA = " & " (SERVICE_NAME = NEWDB)" & " )" & ");" & "User Id=SYSTEM;" & "password=admin;"
            Try
                conn.Open()
                conn.Close()
                MessageBox.Show("Connection successful!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle")
            End Try
        End Sub

        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
            Dim conn As New OracleConnection()
            conn.ConnectionString = "Data Source=EDZEHOO-PC:1521/NEWDB;User ID=SYSTEM;Password=admin"
            Try
                conn.Open()
                conn.Close()
                MessageBox.Show("Connection successful!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle")
            End Try
        End Sub

        Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
            Dim conn As New OracleConnection()
            conn.ConnectionString = "Data Source=localhost/NEWDB;" & "User ID=SYSTEM;" & "Password=admin;" & "Min Pool Size=10;" & "Max Pool Size=100;" & "Connection Lifetime=120;" & "Connection Timeout=60;" & "Incr Pool Size=3;" & "Decr Pool Size=1;"
            Try
                conn.Open()
                conn.Close()
                MessageBox.Show("Connection successful!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle")
            End Try
        End Sub

        Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
            Dim conn As New OracleConnection()
            conn.ConnectionString = "Data Source=localhost/NEWDB;User ID=/;"
            Try
                conn.Open()
                conn.Close()
                MessageBox.Show("Connection successful!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle")
            End Try
        End Sub

        Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
            Dim conn As New OracleConnection()
            conn.ConnectionString = "User Id=SYSTEM;Password=admin;" & "DBA Privilege=SYSDBA;Data Source=localhost/NEWDB;"
            Try
                conn.Open()
                conn.Close()
                MessageBox.Show("Connection successful!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle")
            End Try
        End Sub

        Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
            Dim _counter As Integer
            Dim _table As DataTable = System.Data.Common.DbProviderFactories.GetFactoryClasses()
            For _counter = 0 To _table.Rows.Count - 1
                If String.Compare(_table.Rows(_counter)("Name").ToString(), "Oracle Data Provider for .NET", True) = 0 Then
                    MessageBox.Show("ODP.NET exists")
                    Return
                End If
            Next _counter
            MessageBox.Show("ODP.NET does not exist")
        End Sub

        Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
            Dim _conn As New OracleConnectionStringBuilder()
            _conn.DataSource = "NEWDB"
            _conn.DecrPoolSize = 5
            _conn.IncrPoolSize = 10
            _conn.Pooling = True
            _conn.MaxPoolSize = 100
            _conn.MinPoolSize = 5
            _conn.ConnectionLifeTime = 120
            _conn.ConnectionTimeout = 60
            _conn.UserID = "SYSTEM"
            _conn.Password = "admin"
            MessageBox.Show(_conn.ConnectionString)
        End Sub

		Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
			Dim _ftry As DbProviderFactory
			_ftry=DbProviderFactories.GetFactory("Oracle.DataAccess.Client")
			Dim _datasourceEnum As DbDataSourceEnumerator = _ftry.CreateDataSourceEnumerator()
			Dim _datasources As DataTable = _datasourceEnum.GetDataSources()
			Dim _counter As Integer
			For _counter = 0 To _datasources.Rows.Count - 1
				MessageBox.Show(_datasources.Rows(_counter)("ServiceName").ToString())
			Next _counter
		End Sub
	End Class
End Namespace
