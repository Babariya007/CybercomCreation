using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ENTOrderItem
/// </summary>
public class ENTOrderItem
{
    protected SqlInt32 _OrderItemID;
    public SqlInt32 OrderItemID
    {
        get
        {
            return _OrderItemID;
        }
        set
        {
            _OrderItemID = value;
        }
    }

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

    protected SqlInt32 _ProductID;
    public SqlInt32 ProductID
    {
        get
        {
            return _ProductID;
        }
        set
        {
            _ProductID = value;
        }
    }

    protected SqlInt32 _OrderQuantity;
    public SqlInt32 OrderQuantity
    {
        get
        {
            return _OrderQuantity;
        }
        set
        {
            _OrderQuantity = value;
        }
    }
}