using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALProductOrder
/// </summary>
namespace eCommerce
{
    public class BALProductOrder
    {
        #region Local Veriable
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local Veriable

        #region Insert Operation
        public Boolean Insert(ENTProductOrder entProductOrder)
        {
            DALProductOrder dalProductMaster = new DALProductOrder();
            if (dalProductMaster.Insert(entProductOrder))
            {
                return true;
            }
            else
            {
                this.Message = dalProductMaster.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region ProductOrderAddCart
        public ENTProductOrder ProductOrderAddCart(SqlInt32 Product)
        {
            DALProductOrder dalProductOrder = new DALProductOrder();
            return dalProductOrder.ProductOrderAddCart(Product);
        }
        #endregion ProductOrderAddCart
    }
}