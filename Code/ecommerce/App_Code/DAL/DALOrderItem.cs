using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALOrderItem
/// </summary>
namespace eCommerce
{
    public class DALOrderItem : DataBaseConfig
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

        #region Order Item Insert
        public Boolean AddOrderItem(ENTOrderItem entOrderItem)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_OrderItem_Insert";
                        objCmd.Parameters.AddWithValue("@OrderID", entOrderItem.OrderID);
                        objCmd.Parameters.AddWithValue("@ProductID", entOrderItem.ProductID);
                        objCmd.Parameters.AddWithValue("@OrderQuantity", entOrderItem.OrderQuantity);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    //catch (SqlException sqlex)
                    //{
                    //    Message = sqlex.InnerException.Message.ToString();
                    //    return false;
                    //}
                    //catch (Exception ex)
                    //{
                    //    Message = ex.InnerException.Message.ToString();
                    //    return false;
                    //}
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Order Item Insert
    }
}