using System;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

public class JobClass : INullable, IOracleCustomType
{
    private bool _isNull;
    private int _jobPrice;
    private string _jobDescription;
    private string _jobID;
    private string _jobName;
    public virtual bool IsNull
    {
        get
        {
        return _isNull;
        }
    }

    [OracleObjectMappingAttribute("JOBPRICE")]
    public int JobPrice
    {
        get
        {
            return _jobPrice;
        }
        set
        {
            _jobPrice = value;
        }
    }
    
    [OracleObjectMappingAttribute("JOBNAME")]
    public string JobName
    {
        get
        {
            return _jobName;
        }
        set
        {
            _jobName = value;
        }
    }
    
    [OracleObjectMappingAttribute("JOBID")]
    public string JobID
    {
        get
        {
            return _jobID;
        }
        set
        {
            _jobID = value;
        }
    }
    
    [OracleObjectMappingAttribute("JOBDESCRIPTION")]
    public string JobDescription
    {
        get
        {
            return _jobDescription;
        }
        set
        {
            _jobDescription = value;
        }
    }

    // IOracleCustomType.FromCustomObject() implementation
    // Writes a JobClass object into the JOBS_TYPE Oracle UDT
    public virtual void FromCustomObject(OracleConnection con, IntPtr pUdt)
    {
        if (_jobID != null)
        {
            OracleUdt.SetValue(con, pUdt, "JOBID", _jobID);
        }
        if (_jobName != null)
        {
            OracleUdt.SetValue(con, pUdt, "JOBNAME", _jobName);
        }
        if (_jobPrice != null)
        {
            OracleUdt.SetValue(con, pUdt, "JOBPRICE", _jobPrice);
        }
        if (_jobDescription != null)
        {
            OracleUdt.SetValue(con, pUdt, "JOBDESCRIPTION", _jobDescription);
        }
    }

    // IOracleCustomType.ToCustomObject() implementation
    // Writes a JOBS_TYPE Oracle UDT into a JobClass object
    public virtual void ToCustomObject(OracleConnection con, IntPtr pUdt)
    {
        _jobID = (string)OracleUdt.GetValue(con, pUdt, "JOBID");
        _jobName = (string)OracleUdt.GetValue(con, pUdt, "JOBNAME");
        _jobDescription = (string)OracleUdt.GetValue(con, pUdt, "JOBDESCRIPTION");
        _jobPrice = (int)OracleUdt.GetValue(con, pUdt, "JOBPRICE");
    }
    // Prints out a summary of the job record this object represents
    public override string ToString()
    {
        return "Job ID : " + _jobID + "\n"
        + "Job Name : " + _jobName + "\n"
        + "Job Description : " + _jobDescription + "\n"
        + "Job Price : " + _jobPrice;
    }
}