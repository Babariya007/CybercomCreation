using eCommerce_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderItemDAL : DatabaseConfig
    {
        #region OrderDetailsByID
        public List<OrderItemModel> OrderDetailsByID(SqlInt32 OrderID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_OrderItems_ShowOrderDetailsSelectByPK";
                        objCmd.Parameters.AddWithValue("@OrderID", OrderID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<OrderItemModel> listOrderItem = new List<OrderItemModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                OrderItemModel orderItemModel = new OrderItemModel();
                                if (!objSDR["OrderItemID"].Equals(DBNull.Value))
                                {
                                    orderItemModel.OrderItemID = Convert.ToInt32(objSDR["OrderItemID"]);
                                }
                                if (!objSDR["FirstName"].Equals(DBNull.Value))
                                {
                                    orderItemModel.FirstName = Convert.ToString(objSDR["FirstName"]);
                                }
                                if (!objSDR["LastName"].Equals(DBNull.Value))
                                {
                                    orderItemModel.LastName = Convert.ToString(objSDR["LastName"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    orderItemModel.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["TotalQuntity"].Equals(DBNull.Value))
                                {
                                    orderItemModel.TotalQuantity = Convert.ToInt32(objSDR["TotalQuntity"]);
                                }
                                if (!objSDR["GSTAmount"].Equals(DBNull.Value))
                                {
                                    orderItemModel.GSTAmount = Convert.ToDecimal(objSDR["GSTAmount"]);
                                }
                                if (!objSDR["TotalAmount"].Equals(DBNull.Value))
                                {
                                    orderItemModel.TotalAmount = Convert.ToDecimal(objSDR["TotalAmount"]);
                                }
                                if (!objSDR["OrderDate"].Equals(DBNull.Value))
                                {
                                    orderItemModel.OrderDate = Convert.ToDateTime(objSDR["OrderDate"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    orderItemModel.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    orderItemModel.ProductPrice = Convert.ToInt32(objSDR["ProductPrice"]);
                                }
                                if (!objSDR["OrderQuantity"].Equals(DBNull.Value))
                                {
                                    orderItemModel.OrderQuantity = Convert.ToInt32(objSDR["OrderQuantity"]);
                                }
                                listOrderItem.Add(orderItemModel);
                            }
                            return listOrderItem;
                        }
                        #endregion ReadData and Set Controls
                    }
                    //catch (SqlException sqlex)
                    //{
                    //    Message = sqlex.InnerException.Message.ToString();
                    //    return null;
                    //}
                    //catch (Exception ex)
                    //{
                    //    Message = ex.InnerException.Message.ToString();
                    //    return null;
                    //}
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion OrderDetailsByID
    }
}
