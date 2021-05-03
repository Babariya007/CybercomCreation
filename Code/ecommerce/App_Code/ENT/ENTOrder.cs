using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ENTOrder
/// </summary>
public class ENTOrder
{
    protected SqlInt32 _OrderID;
    public SqlInt32 OrderID
    {
        get
        {
            return _OrderID;
        }
        set
        {
            _OrderID = value;
        }
    }

    protected SqlInt32 _CustomerID;
    public SqlInt32 CustomerID
    {
        get
        {
            return _CustomerID;
        }
        set
        {
            _CustomerID = value;
        }
    }

    protected SqlString _FirstName;
    public SqlString FirstName
    {
        get
        {
            return _FirstName;
        }
        set
        {
            _FirstName = value;
        }
    }

    protected SqlString _LastName;
    public SqlString LastName
    {
        get
        {
            return _LastName;
        }
        set
        {
            _LastName = value;
        }
    }

    protected SqlInt32 _TotalQuantity;
    public SqlInt32 TotalQuantity
    {
        get
        {
            return _TotalQuantity;
        }
        set
        {
            _TotalQuantity = value;
        }
    }

    protected SqlDecimal _GSTAmount;
    public SqlDecimal GSTAmount
    {
        get
        {
            return _GSTAmount;
        }
        set
        {
            _GSTAmount = value;
        }
    }

    protected SqlDecimal _TotalAmount;
    public SqlDecimal TotalAmount
    {
        get
        {
            return _TotalAmount;
        }
        set
        {
            _TotalAmount = value;
        }
    }

    protected SqlDateTime _OrderDate;
    public SqlDateTime OrderDate
    {
        get
        {
            return _OrderDate;
        }
        set
        {
            _OrderDate = value;
        }
    }

}