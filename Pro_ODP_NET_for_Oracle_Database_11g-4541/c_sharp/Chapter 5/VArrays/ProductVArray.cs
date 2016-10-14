using System;
using System.Data;
using System.Collections;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

public class ProductVArray : IOracleCustomType, INullable
{
    //You will need to define a local array to hold the VARRAY elements. The data
    //type must correspond to the type declared in the VARRAY. You’ve defined a VARRAY
    //of VARCHAR2(10) values, hence your local array will hold String objects.
    [OracleArrayMapping()]
    public String[] Array;
    //The status array is used to store the status of an array index - whether the
    //element at the index is a NULL value or not.
    private OracleUdtStatus[] m_statusArray;

    public OracleUdtStatus[] StatusArray
    {
        get
        {
            return this.m_statusArray;
        }
        set
        {
            this.m_statusArray = value;
        }
    }
    
    private bool m_bIsNull;
    public bool IsNull
    {
        get
        {
            return m_bIsNull;
        }
    }
    
    public static ProductVArray Null
    {
        get
        {
            ProductVArray obj = new ProductVArray();
            obj.m_bIsNull = true;
            return obj;
        }
    }
    
    //The ToCustomObject method is required as part of the IOracleCustomType
    //implementation. It maps the retrieved VARRAY to the local array.
    public void ToCustomObject(OracleConnection con, IntPtr pUdt)
    {
        object objectStatusArray = null;
        Array = (String[])OracleUdt.GetValue(con, pUdt, 0, out objectStatusArray);
        m_statusArray = (OracleUdtStatus[])objectStatusArray;
    }
    
    //The FromCustomObject method is the opposite equivalent. It maps a local array to a
    //VARRAY
    public void FromCustomObject(OracleConnection con, IntPtr pUdt)
    {
        OracleUdt.SetValue(con, pUdt, 0, Array, m_statusArray);
    }
    
    public override string ToString()
    {
        if (m_bIsNull)
            return "ProductVArray.Null";
        else
        {
            string rtnstr = String.Empty;
            if (m_statusArray[0] == OracleUdtStatus.Null)
                rtnstr = "NULL";
            else
                rtnstr = Array.GetValue(0).ToString();
            for (int i = 1; i < m_statusArray.Length; i++)
            {
                if (m_statusArray[i] == OracleUdtStatus.Null)
                    rtnstr += "," + "NULL";
                else
                    rtnstr += "," + Array.GetValue(i).ToString();
            }
            return "ProductVArray(" + rtnstr + ")";
        }
    }
}