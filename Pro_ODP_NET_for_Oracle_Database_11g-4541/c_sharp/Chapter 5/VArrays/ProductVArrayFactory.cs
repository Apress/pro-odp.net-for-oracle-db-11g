using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

[OracleCustomTypeMapping("EDZEHOO.PRODUCTVARRAY")]
public class ProductVArrayFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
{
    public IOracleCustomType CreateObject()
    {
        return new ProductVArray();
    }
    public Array CreateArray(int numElems)
    {
        return new String[numElems];
    }
    public Array CreateStatusArray(int numElems)
    {
        return new OracleUdtStatus[numElems];
    }
}