Imports System
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

 _

Public Class PRODUCTTYPE
    Implements IOracleCustomType
    Private m_IsNull As Boolean
    Private m_ID As String
    Private m_NAME As String
    Private m_PRICE As Decimal
    Private m_PRICEIsNull As Boolean


    Public Sub New()
        Me.m_PRICEIsNull = True
    End Sub 'New


    Public Overridable ReadOnly Property IsNull() As Boolean
        Get
            Return Me.m_IsNull
        End Get
    End Property


    Public Shared ReadOnly Property Null() As PRODUCTTYPE
        Get
            Dim obj As New PRODUCTTYPE()
            obj.m_IsNull = True
            Return obj
        End Get
    End Property

    <OracleObjectMappingAttribute("ID")> _
        Public Property ID() As String
        Get
            Return Me.m_ID
        End Get
        Set(ByVal value As String)
            Me.m_ID = value
        End Set
    End Property

    <OracleObjectMappingAttribute("NAME")> _
        Public Property NAME() As String
        Get
            Return Me.m_NAME
        End Get
        Set(ByVal value As String)
            Me.m_NAME = value
        End Set
    End Property

    <OracleObjectMappingAttribute("PRICE")> _
        Public Property PRICE() As Decimal
        Get
            Return Me.m_PRICE
        End Get
        Set(ByVal value As Decimal)
            Me.m_PRICE = value
        End Set
    End Property


    Public Property PRICEIsNull() As Boolean
        Get
            Return Me.m_PRICEIsNull
        End Get
        Set(ByVal value As Boolean)
            Me.m_PRICEIsNull = value
        End Set
    End Property


    'The FromCustomObject method is required as part of the IOracleCustomType
    'interface. This function allows you to define the mapping to use when filling a
    'UDT object with data from your UDT class
    Public Overridable Sub FromCustomObject(ByVal con As Oracle.DataAccess.Client.OracleConnection, ByVal pUdt As System.IntPtr) Implements Oracle.DataAccess.Types.IOracleCustomType.FromCustomObject
        Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "ID", Me.ID)
        Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "NAME", Me.NAME)
        If PRICEIsNull = False Then
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "PRICE", Me.PRICE)
        End If
    End Sub 'FromCustomObject

    'This method is the opposite. It allows you to define the mapping to use when
    'populating your UDT class with data from a retrieved UDT object.
    Public Overridable Sub ToCustomObject(ByVal con As Oracle.DataAccess.Client.OracleConnection, ByVal pUdt As System.IntPtr) Implements Oracle.DataAccess.Types.IOracleCustomType.ToCustomObject
        Me.ID = CStr(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "ID"))
        Me.NAME = CStr(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "NAME"))
        Me.PRICEIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "PRICE")
        If PRICEIsNull = False Then
            Me.PRICE = CDec(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "PRICE"))
        End If
    End Sub 'ToCustomObject

End Class 'PRODUCTTYPE