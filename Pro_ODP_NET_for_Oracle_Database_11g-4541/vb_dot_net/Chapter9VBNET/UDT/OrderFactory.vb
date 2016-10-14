Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

'JobClass factory class
<OracleCustomTypeMappingAttribute("EDZEHOO.JOBS_TYPE")> _
Public Class OrderFactory
    Implements IOracleCustomTypeFactory

    ' Implementation of IOracleCustomTypeFactory.CreateObject()
    Public Function CreateObject() As IOracleCustomType Implements Oracle.DataAccess.Types.IOracleCustomTypeFactory.CreateObject
        Return New JobClass()
    End Function 'CreateObject

End Class 'OrderFactory