Imports System
Imports System.Data
Imports System.Collections
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

 _

Public Class ProductVArray
    Implements INullable

    <OracleArrayMapping()> _
    Public Array() As [String]
    'The status array is used to store the status of an array index - whether the
    'element at the index is a NULL value or not.
    Private m_statusArray() As OracleUdtStatus


    Public Property StatusArray() As OracleUdtStatus()
        Get
            Return Me.m_statusArray
        End Get
        Set(ByVal value As OracleUdtStatus())
            Me.m_statusArray = value
        End Set
    End Property

    Private m_bIsNull As Boolean

    Public ReadOnly Property IsNull() As Boolean Implements Oracle.DataAccess.Types.INullable.IsNull
        Get
            Return m_bIsNull
        End Get
    End Property


    Public Shared ReadOnly Property Null() As ProductVArray
        Get
            Dim obj As New ProductVArray()
            obj.m_bIsNull = True
            Return obj
        End Get
    End Property


    'The ToCustomObject method is required as part of the IOracleCustomType
    'implementation. It maps the retrieved VARRAY to the local array.
    Public Sub ToCustomObject(ByVal con As OracleConnection, ByVal pUdt As IntPtr)
        Dim objectStatusArray As Object = Nothing
        Array = CType(OracleUdt.GetValue(con, pUdt, 0, objectStatusArray), [String]())
        m_statusArray = CType(objectStatusArray, OracleUdtStatus())
    End Sub 'ToCustomObject


    'The FromCustomObject method is the opposite equivalent. It maps a local array to a
    'VARRAY
    Public Sub FromCustomObject(ByVal con As OracleConnection, ByVal pUdt As IntPtr)
        OracleUdt.SetValue(con, pUdt, 0, Array, m_statusArray)
    End Sub 'FromCustomObject


    Public Overrides Function ToString() As String
        If m_bIsNull Then
            Return "ProductVArray.Null"
        Else
            Dim rtnstr As String = [String].Empty
            If m_statusArray(0) = OracleUdtStatus.Null Then
                rtnstr = "NULL"
            Else
                rtnstr = Array.GetValue(0).ToString()
            End If
            Dim i As Integer
            For i = 1 To m_statusArray.Length - 1
                If m_statusArray(i) = OracleUdtStatus.Null Then
                    rtnstr += "," + "NULL"
                Else
                    rtnstr += "," + Array.GetValue(i).ToString()
                End If
            Next i
            Return "ProductVArray(" + rtnstr + ")"
        End If
    End Function 'ToString


End Class 'ProductVArray