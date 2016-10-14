using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


[OracleCustomTypeMappingAttribute("EDZEHOO.PRODUCTNESTEDTABLE")]
public class ProductNestedTableFactory : IOracleArrayTypeFactory
{
    public Array CreateArray(int numElems)
    {
        return new String[numElems];
    }
    public Array CreateStatusArray(int numElems)
    {
        return new OracleUdtStatus[numElems];
    }
}
