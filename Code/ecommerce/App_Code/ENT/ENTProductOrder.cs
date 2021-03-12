using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ENTProductOrder
/// </summary>
namespace eCommerce
{
    public class ENTProductOrder
    {
        protected SqlInt32 _ProductOrderID;
        public SqlInt32 ProductOrderID
        {
            get
            {
                return _ProductOrderID;
            }
            set
            {
                _ProductOrderID  = value;
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

    }
}