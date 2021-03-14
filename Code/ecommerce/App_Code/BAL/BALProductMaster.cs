using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALProductMaster
/// </summary>
namespace eCommerce
{
    public class BALProductMaster
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
        public Boolean Insert(ENTProductMaster entProductMaster)
        {
            DALProductMaster dalProductMaster = new DALProductMaster();
            if (dalProductMaster.Insert(entProductMaster))
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

        #region Update Operation
        public Boolean Update(ENTProductMaster entProductMaster)
        {
            DALProductMaster dalProductMaster = new DALProductMaster();
            if (dalProductMaster.Update(entProductMaster))
            {
                return true;
            }
            else
            {
                this.Message = dalProductMaster.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ProductID)
        {
            DALProductMaster dalProductMaster = new DALProductMaster();
            if (dalProductMaster.Delete(ProductID))
            {
                return true;
            }
            else
            {
                this.Message = dalProductMaster.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation
        public DataTable SelectAll()
        {
            DALProductMaster dalProductMaster = new DALProductMaster();
            return dalProductMaster.SelectAll();
        }
        public ENTProductMaster SelectByPK(SqlInt32 BranchID)
        {
            DALProductMaster dalBranch = new DALProductMaster();
            return dalBranch.SelectByPK(BranchID);
        }
        #endregion Select Operation

        //-----------------------------------------------------------------
        #region Show Product
        public DataTable ShowProducts()
        {
            DALProductMaster dalProductMaster = new DALProductMaster();
            return dalProductMaster.ShowProducts();
        }
        public ENTProductMaster ProductMasterShowDetailsByPK(SqlInt32 ProductID)
        {
            DALProductMaster dalProductMaster = new DALProductMaster();
            return dalProductMaster.ProductMasterShowDetailsByPK(ProductID);
        }
        #endregion Show Product

        
        
    }
}