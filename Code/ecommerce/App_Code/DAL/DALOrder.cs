using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALOrder
/// </summary>
namespace eCommerce
{
    public class DALOrder : DataBaseConfig
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

        #region Order Insert
        public Boolean AddOrder(ENTOrder entOrder)
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
                        objCmd.Parameters.AddWithValue("@CustomerID", entOrder.CustomerID);
                        objCmd.Parameters.AddWithValue("@FirstName", entOrder.FirstName);
                        objCmd.Parameters.AddWithValue("@LastName", entOrder.LastName);
                        objCmd.Parameters.AddWithValue("@TotalQuantity", entOrder.TotalQuantity);
                        objCmd.Parameters.AddWithValue("@GSTAmount", entOrder.GSTAmount);
                        objCmd.Parameters.AddWithValue("@TotalAmount", entOrder.TotalAmount);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        entOrder.OrderID = (int)objCmd.Parameters["@OrderID"].Value;
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
    }
}