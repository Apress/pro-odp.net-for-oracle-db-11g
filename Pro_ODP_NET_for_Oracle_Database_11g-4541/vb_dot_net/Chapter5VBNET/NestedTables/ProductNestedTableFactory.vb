Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

<OracleCustomTypeMappingAttribute("EDZEHOO.PRODUCTNESTEDTABLE")> _
Public Class ProductNestedTableFactory
    Implements IOracleArrayTypeFactory

    Public Function CreateArray(ByVal numElems As Integer) As Array Implements Oracle.DataAccess.Types.IOracleArrayTypeFactory.CreateArray
        Return New [String](numElems) {}
    End Function 'CreateArray

    Public Function CreateStatusArray(ByVal numElems As Integer) As Array Implements Oracle.DataAccess.Types.IOracleArrayTypeFactory.CreateStatusArray
        Return New OracleUdtStatus(numElems) {}
    End Function 'CreateStatusArray

End Class 'ProductNestedTableFactory