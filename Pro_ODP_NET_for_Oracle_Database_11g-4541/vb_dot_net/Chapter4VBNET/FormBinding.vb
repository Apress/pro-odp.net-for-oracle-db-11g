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
Class FormBinding
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
    Private _productsCmdObj As OracleCommand = Nothing
    Private _productComponentsCmdObj As OracleCommand = Nothing
    Private _productsAdpObj As OracleDataAdapter = Nothing
    Private _productComponentsAdpObj As OracleDataAdapter = Nothing
    Private _ds As New DataSet()
    'In this example, we load the Product identified by the ID value of "E1"
    Private _productID As String = "E1"


    Public Sub New()
        InitializeComponent()
    End Sub 'New


    Private Sub BindData()
        bsProducts.DataSource = _ds.Tables("Products")
        txtName.DataBindings.Add(New Binding("Text", bsProducts, "Name", True))
        numPrice.DataBindings.Add(New Binding("Value", bsProducts, "Price", True))
        txtRemarks.DataBindings.Add(New Binding("Text", bsProducts, "Remarks", True))
        dgComponents.DataSource = _ds.Tables("ProductComponents")
    End Sub 'BindData


    Private Sub LoadData()
        Dim _connstring As String = "Data Source=localhost/NEWDB;User Id=EDZEHOO;Password=PASS123;"
        Dim _sql As String
        Try
            Dim _connObj As New OracleConnection(_connstring)
            _connObj.Open()
            _ds = New DataSet()
            'Retrieve from the Products table
            _sql = "SELECT * FROM Products WHERE ID=:ID"
            _productsCmdObj = New OracleCommand(_sql, _connObj)
            _productsCmdObj.Parameters.Add(New OracleParameter("ID", _productID))
            _productsAdpObj = New OracleDataAdapter(_productsCmdObj)
            _productsAdpObj.Fill(_ds, "Products")
            'Retrieve from the ProductComponents table
            _sql = "SELECT * FROM ProductComponents WHERE ParentProductID=:ParentProductID"
            _productComponentsCmdObj = New OracleCommand(_sql, _connObj)
            _productComponentsCmdObj.Parameters.Add(New OracleParameter("ParentProductID", _productID))
            _productComponentsAdpObj = New OracleDataAdapter(_productComponentsCmdObj)
            _productComponentsAdpObj.Fill(_ds, "ProductComponents")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'LoadData


    Private Sub FormBinding_Load(ByVal sender As Object, ByVal e As EventArgs)
        'In this example, we load the Product identified by the ID value of "E1"
        LoadData()
        BindData()
    End Sub 'FormBinding_Load

End Class 'FormBinding
'
'ToDo: Error processing original source shown below
'
'
'-^--- expression expected