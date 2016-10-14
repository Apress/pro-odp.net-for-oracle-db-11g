using System;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

public class PRODUCTTYPE : INullable, IOracleCustomType {
    private bool m_IsNull;
    private string m_ID;
    private string m_NAME;
    private decimal m_PRICE;
    private bool m_PRICEIsNull;
   
    public PRODUCTTYPE() {
        this.m_PRICEIsNull = true;
    }
    
    public virtual bool IsNull {
        get 
        {
                return this.m_IsNull;
            }
        }
    
    public static PRODUCTTYPE Null {
        get 
        {
            PRODUCTTYPE obj = new PRODUCTTYPE();
            obj.m_IsNull = true;
            return obj;
        }
    }
    
    [OracleObjectMappingAttribute("ID")]
    public string ID {
        get 
        {
            return this.m_ID;
        }   
        set 
        {
            this.m_ID = value;
        }
    }
    
    [OracleObjectMappingAttribute("NAME")]
    public string NAME {
        get 
        {
            return this.m_NAME;
        }
        set 
        {
            this.m_NAME = value;
        }
    }
    
    [OracleObjectMappingAttribute("PRICE")]
    public decimal PRICE {
        get 
        {
            return this.m_PRICE;
        }
        set 
        {
            this.m_PRICE = value;
        }
    }

    public bool PRICEIsNull 
    {
        get 
        {
            return this.m_PRICEIsNull;
        }
        set 
        {
            this.m_PRICEIsNull = value;
        }
    }
    
    //The FromCustomObject method is required as part of the IOracleCustomType
    //interface. This function allows you to define the mapping to use when filling a
    //UDT object with data from your UDT class
    public virtual void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con,
    System.IntPtr pUdt)
    {
       Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "ID", this.ID);
        Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "NAME", this.NAME);
        if ((PRICEIsNull == false))
        {
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "PRICE",
            this.PRICE);
        }
    }
    //This method is the opposite. It allows you to define the mapping to use when
    //populating your UDT class with data from a retrieved UDT object.
    public virtual void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con,
    System.IntPtr pUdt)
    {
        this.ID = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt,
        "ID")));
        this.NAME = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt,
        "NAME")));
        this.PRICEIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt,
        "PRICE");
        if ((PRICEIsNull == false))
        {
            this.PRICE =
            ((decimal)(Oracle.DataAccess.Types.OracleUdt.GetValue(con,
            pUdt, "PRICE")));
        }
    }
}