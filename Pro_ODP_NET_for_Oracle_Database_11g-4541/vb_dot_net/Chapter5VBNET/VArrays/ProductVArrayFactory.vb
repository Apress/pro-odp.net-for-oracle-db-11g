Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

<OracleCustomTypeMapping("EDZEHOO.PRODUCTVARRAY")> _
Public Class ProductVArrayFactory
    Implements IOracleArrayTypeFactory

    Public Function CreateObject() As IOracleCustomType
        Return New ProductVArray()
    End Function 'CreateObject

    Public Function CreateArray(ByVal numElems As Integer) As Array Implements Oracle.DataAccess.Types.IOracleArrayTypeFactory.CreateArray
        Return New [String](numElems) {}
    End Function 'CreateArray

    Public Function CreateStatusArray(ByVal numElems As Integer) As Array Implements Oracle.DataAccess.Types.IOracleArrayTypeFactory.CreateStatusArray
        Return New OracleUdtStatus(numElems) {}
    End Function 'CreateStatusArray
End Class 'ProductVArrayFactory