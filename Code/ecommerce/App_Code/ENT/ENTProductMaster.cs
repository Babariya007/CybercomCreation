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
        //protected SqlInt32 _ProductID;
        public SqlInt32 ProductID
        {
            get;
            //{
            //    return _ProductID;
            //}
            set;
            
        }

        //protected SqlString _ProductName;
        public SqlString ProductName
        {
            get;
            //{
            //    return _ProductName;
            //}
            set;
            //{
            //    _ProductName = value;
            //}
        }

        //protected SqlInt32 _ProductQuantity;
        public SqlInt32 ProductQuantity
        {
            get;
            //{
            //    return _ProductQuantity;
            //}
            set;
            //{
            //    _ProductQuantity = value;
            //}
        }

        //protected SqlString _ProductDetails;
        public SqlString ProductDetails
        {
            get;
            //{
            //    return _ProductDetails;
            //}
            set;
            //{
            //    _ProductDetails = value;
            //}
        }

        //protected SqlDecimal _ProductPrice;
        public SqlDecimal ProductPrice
        {
            get;
            //{
            //    return _ProductPrice;
            //}
            set;
            //{
            //    _ProductPrice = value;
            //}
        }

        //protected SqlString _ProductImage;
        public SqlString ProductImage
        {
            get;
            //{
            //    return _ProductImage;
            //}
            set;
            //{
            //    _ProductImage = value;
            //}
        }

    }

    public class ProductMasterDataTable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string error { get; set; }
        public List<ENTProductMaster> data { get; set; }
    }

    public class DataTableOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
        public string Search { get; set; }
    }
}