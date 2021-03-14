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
    public class ENTCart
    {
        protected SqlInt32 _CartID;
        public SqlInt32 CartID
        {
            get
            {
                return _CartID;
            }
            set
            {
                _CartID  = value;
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