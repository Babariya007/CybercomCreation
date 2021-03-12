using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ENTCustomer
/// </summary>
namespace eCommerce
{
    public class ENTCustomer
    {
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

        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
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

        protected SqlInt32 _OrderQuentity;
        public SqlInt32 OrderQuentity
        {
            get
            {
                return _OrderQuentity;
            }
            set
            {
                _OrderQuentity = value;
            }
        }

        protected SqlDecimal _TotalBill;
        public SqlDecimal TotalBill
        {
            get
            {
                return _TotalBill;
            }
            set
            {
                _TotalBill = value;
            }
        }
    }
}