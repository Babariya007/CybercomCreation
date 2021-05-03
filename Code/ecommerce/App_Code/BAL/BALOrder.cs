using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALOrder
/// </summary>
namespace eCommerce
{
    public class BALOrder
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
        public Boolean Insert(ENTOrder entOrder)
        {
            DALOrder dalOrder = new DALOrder();
            if (dalOrder.AddOrder(entOrder))
            {
                return true;
            }
            else
            {
                this.Message = dalOrder.Message;
                return false;
            }
        }
        #endregion Insert Operation
    }
}