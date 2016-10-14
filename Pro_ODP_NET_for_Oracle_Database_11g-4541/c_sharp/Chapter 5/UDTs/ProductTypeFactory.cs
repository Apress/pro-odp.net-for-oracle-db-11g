using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

[OracleCustomTypeMappingAttribute("EDZEHOO.PRODUCTTYPE")]
public class PRODUCTTYPEFactory : IOracleCustomTypeFactory
{
    public virtual IOracleCustomType CreateObject()
    {
        PRODUCTTYPE obj = new PRODUCTTYPE();
        return obj;
    }
}