Imports System
Imports System.Text
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

 _

Public Class JobClass
    Implements IOracleCustomType
    Private _isNull As Boolean
    Private _jobPrice As Integer
    Private _jobDescription As String
    Private _jobID As String
    Private _jobName As String

    Public Overridable ReadOnly Property IsNull() As Boolean
        Get
            Return _isNull
        End Get
    End Property

    <OracleObjectMappingAttribute("JOBPRICE")> _
    Public Property JobPrice() As Integer
        Get
            Return _jobPrice
        End Get
        Set(ByVal value As Integer)
            _jobPrice = value
        End Set
    End Property

    <OracleObjectMappingAttribute("JOBNAME")> _
        Public Property JobName() As String
        Get
            Return _jobName
        End Get
        Set(ByVal value As String)
            _jobName = value
        End Set
    End Property

    <OracleObjectMappingAttribute("JOBID")> _
        Public Property JobID() As String
        Get
            Return _jobID
        End Get
        Set(ByVal value As String)
            _jobID = value
        End Set
    End Property

    <OracleObjectMappingAttribute("JOBDESCRIPTION")> _
        Public Property JobDescription() As String
        Get
            Return _jobDescription
        End Get
        Set(ByVal value As String)
            _jobDescription = value
        End Set
    End Property


    ' IOracleCustomType.FromCustomObject() implementation
    ' Writes a JobClass object into the JOBS_TYPE Oracle UDT
    Public Overridable Sub FromCustomObject(ByVal con As OracleConnection, ByVal pUdt As IntPtr) Implements Oracle.DataAccess.Types.IOracleCustomType.FromCustomObject
        If Not (_jobID Is Nothing) Then
            OracleUdt.SetValue(con, pUdt, "JOBID", _jobID)
        End If
        If Not (_jobName Is Nothing) Then
            OracleUdt.SetValue(con, pUdt, "JOBNAME", _jobName)
        End If
        OracleUdt.SetValue(con, pUdt, "JOBPRICE", _jobPrice)
        If Not (_jobDescription Is Nothing) Then
            OracleUdt.SetValue(con, pUdt, "JOBDESCRIPTION", _jobDescription)
        End If
    End Sub 'FromCustomObject


    ' IOracleCustomType.ToCustomObject() implementation
    ' Writes a JOBS_TYPE Oracle UDT into a JobClass object
    Public Overridable Sub ToCustomObject(ByVal con As OracleConnection, ByVal pUdt As IntPtr) Implements Oracle.DataAccess.Types.IOracleCustomType.ToCustomObject
        _jobID = CStr(OracleUdt.GetValue(con, pUdt, "JOBID"))
        _jobName = CStr(OracleUdt.GetValue(con, pUdt, "JOBNAME"))
        _jobDescription = CStr(OracleUdt.GetValue(con, pUdt, "JOBDESCRIPTION"))
        _jobPrice = CInt(OracleUdt.GetValue(con, pUdt, "JOBPRICE"))
    End Sub 'ToCustomObject

    ' Prints out a summary of the job record this object represents
    Public Overrides Function ToString() As String
        Return "Job ID : " + _jobID + ControlChars.Lf + "Job Name : " + _jobName + ControlChars.Lf + "Job Description : " + _jobDescription + ControlChars.Lf + "Job Price : " + _jobPrice
    End Function 'ToString


End Class 'JobClass