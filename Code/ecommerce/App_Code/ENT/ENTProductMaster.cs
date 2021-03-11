using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ENTProductMaster
/// </summary>
namespace eCommerce
{
    public class ENTProductMaster
    {
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

        protected SqlString _ProductName;
        public SqlString ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
            }
        }

        protected SqlInt32 _ProductQuantity;
        public SqlInt32 ProductQuantity
        {
            get
            {
                return _ProductQuantity;
            }
            set
            {
                _ProductQuantity = value;
            }
        }

        protected SqlString _ProductDetails;
        public SqlString ProductDetails
        {
            get
            {
                return _ProductDetails;
            }
            set
            {
                _ProductDetails = value;
            }
        }

        protected SqlDecimal _ProductPrice;
        public SqlDecimal ProductPrice
        {
            get
            {
                return _ProductPrice;
            }
            set
            {
                _ProductPrice = value;
            }
        }

        protected SqlString _ProductImage;
        public SqlString ProductImage
        {
            get
            {
                return _ProductImage;
            }
            set
            {
                _ProductImage = value;
            }
        }

    }
}