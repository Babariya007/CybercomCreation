using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALOrderItem
/// </summary>
namespace eCommerce
{
    public class BALOrderItem
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
        public Boolean Insert(ENTOrderItem entOrderItem)
        {
            DALOrderItem dalOrderItem = new DALOrderItem();
            if (dalOrderItem.AddOrderItem(entOrderItem))
            {
                return true;
            }
            else
            {
                this.Message = dalOrderItem.Message;
                return false;
            }
        }
        #endregion Insert Operation
    }
}