using eCommerce_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDAL : DatabaseConfig
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

        #region CustomerOrderList
        public List<OrderModel> OrderListSelectAll(int Length, int Start,int Column, string Dir, string Search)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Order_SelectAllDataTable";
                        objCmd.Parameters.AddWithValue("@DisplayLength", Length);
                        objCmd.Parameters.AddWithValue("@DisplayStart", Start);
                        objCmd.Parameters.AddWithValue("@SortColumn", Column);
                        objCmd.Parameters.AddWithValue("@SortDirection", Dir);
                        objCmd.Parameters.AddWithValue("@Search", Search);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<OrderModel> listOrder = new List<OrderModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                OrderModel orderModel = new OrderModel();
                                if (!objSDR["OrderID"].Equals(DBNull.Value))
                                {
                                    orderModel.OrderID = Convert.ToInt32(objSDR["OrderID"]);
                                }
                                if (!objSDR["FirstName"].Equals(DBNull.Value))
                                {
                                    orderModel.FirstName = Convert.ToString(objSDR["FirstName"]);
                                }
                                if (!objSDR["LastName"].Equals(DBNull.Value))
                                {
                                    orderModel.LastName = Convert.ToString(objSDR["LastName"]);
                                }
                                if (!objSDR["TotalQuntity"].Equals(DBNull.Value))
                                {
                                    orderModel.TotalQuantity = Convert.ToInt32(objSDR["TotalQuntity"]);
                                }
                                if (!objSDR["TotalAmount"].Equals(DBNull.Value))
                                {
                                    orderModel.TotalAmount = Convert.ToDecimal(objSDR["TotalAmount"]);
                                }
                                if (!objSDR["OrderDate"].Equals(DBNull.Value))
                                {
                                    orderModel.OrderDate = Convert.ToDateTime(objSDR["OrderDate"]);
                                }
                                if (!objSDR["TotalCount"].Equals(DBNull.Value))
                                {
                                    orderModel.filterCount = Convert.ToInt32(objSDR["TotalCount"]);
                                }
                                listOrder.Add(orderModel);
                            }
                            return listOrder;
                        }
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion CustomerOrderList
    }
}
