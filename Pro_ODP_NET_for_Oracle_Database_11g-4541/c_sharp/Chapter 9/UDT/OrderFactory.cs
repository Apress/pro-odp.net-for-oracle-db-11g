using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

//JobClass factory class
[OracleCustomTypeMappingAttribute("EDZEHOO.JOBS_TYPE")]
public class OrderFactory : IOracleCustomTypeFactory
{
    // Implementation of IOracleCustomTypeFactory.CreateObject()
    public IOracleCustomType CreateObject()
    {
        return new JobClass();
    }
}