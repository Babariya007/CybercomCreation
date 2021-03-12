using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALCustomer
/// </summary>
namespace eCommerce
{
    public class BALCustomer
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
        public Boolean Insert(ENTCustomer entCustomer)
        {
            DALCustomer dalProductMaster = new DALCustomer();
            if (dalProductMaster.Insert(entCustomer))
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

        #region CustomerOrderList
        public DataTable SelectAll()
        {
            DALCustomer dalCustomer = new DALCustomer();
            return dalCustomer.SelectAll();
        }
        #endregion CustomerOrderList
    }
}