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
    public class BALCart
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
        public Boolean Insert(ENTCart entProductOrder)
        {
            DALCart dalCart = new DALCart();
            if (dalCart.Insert(entProductOrder))
            {
                return true;
            }
            else
            {
                this.Message = dalCart.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delete Iteam From Cart
        public Boolean Delete(SqlInt32 CartID)
        {
            DALCart dalCart = new DALCart();
            return dalCart.Delete(CartID);
        }
        #endregion Delete Iteam From Cart

        #region ProductOrderAddCart
        public ENTCart ProductOrderAddCart(SqlInt32 Product)
        {
            DALCart dalProductOrder = new DALCart();
            return dalProductOrder.ProductOrderAddCart(Product);
        }
        #endregion ProductOrderAddCart

        #region ItemInCartBy
        public DataTable ItemInCart()
        {
            DALCart dalCart = new DALCart();
            return dalCart.ItemInCart();
        }
        #endregion ItemInCart

        #region Delete Iteam From Cart
        public Boolean CheckItemInCart(SqlInt32 ProductID)
        {
            DALCart dalCart = new DALCart();
            return dalCart.CheckItemInCart(ProductID);
        }
        #endregion Delete Iteam From Cart

    }
}