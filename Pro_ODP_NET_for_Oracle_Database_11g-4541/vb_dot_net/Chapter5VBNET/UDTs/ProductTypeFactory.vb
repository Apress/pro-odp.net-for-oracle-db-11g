Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Oracle.DataAccess.Types
Imports Oracle.DataAccess.Client

<OracleCustomTypeMappingAttribute("EDZEHOO.PRODUCTTYPE")> _
Public Class PRODUCTTYPEFactory
    Implements IOracleCustomTypeFactory

    Public Overridable Function CreateObject() As IOracleCustomType Implements Oracle.DataAccess.Types.IOracleCustomTypeFactory.CreateObject
        Dim obj As New PRODUCTTYPE()
        Return obj
    End Function 'CreateObject
End Class 'PRODUCTTYPEFactory