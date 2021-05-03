using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce_Model;

namespace DAL
{
    public class CustomerDAL : DatabaseConfig
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

        #region Customer And Order Insert

        #region Order Insert
        public Boolean AddOrder(OrderModel orderModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Order_Insert";
                        objCmd.Parameters.Add("@OrderID", SqlDbType.Int, 5);
                        objCmd.Parameters["@OrderID"].Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@CustomerID", orderModel.CustomerID);
                        objCmd.Parameters.AddWithValue("@FirstName", orderModel.FirstName);
                        objCmd.Parameters.AddWithValue("@LastName", orderModel.LastName);
                        objCmd.Parameters.AddWithValue("@TotalQuantity", orderModel.TotalQuantity);
                        objCmd.Parameters.AddWithValue("@GSTAmount", orderModel.GSTAmount);
                        objCmd.Parameters.AddWithValue("@TotalAmount", orderModel.TotalAmount);
                        
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        
                        orderModel.OrderID = (int)objCmd.Parameters["@OrderID"].Value;
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Order Insert

        #region Customer Insert
        public Boolean AddCustomer(CustomerModel customerModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_CustomerConfiramOrder_Insert";
                        objCmd.Parameters.Add("@CustomerID", SqlDbType.Int, 5);
                        objCmd.Parameters["@CustomerID"].Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@FirstName", customerModel.FirstName);
                        objCmd.Parameters.AddWithValue("@LastName", customerModel.LastName);
                        objCmd.Parameters.AddWithValue("@Address", customerModel.Address);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        customerModel.CustomerID = (int)objCmd.Parameters["@CustomerID"].Value;
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Customer Insert

        #region Order Item Insert
        public Boolean AddOrderItem(OrderItemModel orderModel)
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
                        objCmd.Parameters.AddWithValue("@OrderID", orderModel.OrderID);
                        objCmd.Parameters.AddWithValue("@ProductID", orderModel.ProductID);
                        objCmd.Parameters.AddWithValue("@OrderQuantity", orderModel.OrderQuantity);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Order Item Insert

        #region Detele Item In Cart
        public Boolean TruncateCart()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Cart_TruncateData";
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Number == 547)
                        {
                            Message = "This Product is Purches Do not able to Delete This Record";
                        }
                        else
                        {
                            Message = sqlex.InnerException.Message.ToString();
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Detele Item In Cart

        #endregion Customer And Order Insert

    }
}
