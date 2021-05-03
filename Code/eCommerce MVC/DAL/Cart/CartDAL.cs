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
    public class CartDAL : DatabaseConfig
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

        #region ProductOrderAddCart
        public CartModel ProductOrderAddCart(SqlInt32 ProductID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_Cart_InsertProduct";
                        objcmd.Parameters.AddWithValue("@ProductID", ProductID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        CartModel cartModel = new CartModel();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    cartModel.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                            }
                        }
                        return cartModel;
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
        #endregion ProductOrderAddCart

        #region ItemInCart
        public List<CartModel> ItemInCart()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_CartItemShow_SelectAll";
                        #endregion Prepar Command

                        #region ReadData and Set Controls
                        List<CartModel> listCart = new List<CartModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                CartModel cartModel = new CartModel();
                                if (!objSDR["CartID"].Equals(DBNull.Value))
                                {
                                    cartModel.CartID = Convert.ToInt32(objSDR["CartID"]);
                                }
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    cartModel.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    cartModel.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    cartModel.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                                }
                                if (!objSDR["ProductQuantity"].Equals(DBNull.Value))
                                {
                                    cartModel.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);
                                }
                                if (!objSDR["ProductImage"].Equals(DBNull.Value))
                                {
                                    cartModel.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                                }
                                listCart.Add(cartModel);
                            }
                            return listCart;
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
        #endregion ItemInCart

        #region Delete Item From Cart
        public Boolean Delete(SqlInt32 CartID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_CartDeleteItem_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CartID", CartID);
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
        #endregion Delete Item From Cart

        #region CheckIteamOnCart
        public Boolean CheckItemInCart(SqlInt32 ProductID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Cart_CheckIteamSelectByID";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        #endregion Prepar Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        #endregion ReadData and Set Controls

                        if (dt.Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
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
        #endregion CheckIteamOnCart
    }
}
