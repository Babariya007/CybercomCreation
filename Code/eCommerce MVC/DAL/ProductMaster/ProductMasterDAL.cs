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
    public class ProductMasterDAL : DatabaseConfig
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

        #region Insert Operaction

        public Boolean Insert(ProductMasterModel productMasterModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ProductMaster_Insert";
                        objCmd.Parameters.AddWithValue("@ProductName", productMasterModel.ProductName);
                        objCmd.Parameters.AddWithValue("@ProductQuntity", productMasterModel.ProductQuantity);
                        objCmd.Parameters.AddWithValue("@ProductDetails", productMasterModel.ProductDetails);
                        objCmd.Parameters.AddWithValue("@ProductPrice", productMasterModel.ProductPrice);
                        objCmd.Parameters.AddWithValue("@ProductImage", productMasterModel.ProductImage);

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

        #endregion Insert Operaction

        #region Update Operaction

        public Boolean Update(ProductMasterModel productMasterModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ProductMaster_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", productMasterModel.ProductID);
                        objCmd.Parameters.AddWithValue("@ProductName", productMasterModel.ProductName);
                        objCmd.Parameters.AddWithValue("@ProductQuntity", productMasterModel.ProductQuantity);
                        objCmd.Parameters.AddWithValue("@ProductDetails", productMasterModel.ProductDetails);
                        objCmd.Parameters.AddWithValue("@ProductPrice", productMasterModel.ProductPrice);
                        objCmd.Parameters.AddWithValue("@ProductImage", productMasterModel.ProductImage);
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

        #endregion Update Operaction

        #region Delete Operaction

        public Boolean Delete(SqlInt32 ProductID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ProductMaster_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
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

        #endregion Delete Operaction

        #region Select Operaction
        public ProductMasterModel SelectByPK(SqlInt32 ProductID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_ProductMaster_SelectByPK";
                        objcmd.Parameters.AddWithValue("@ProductID", ProductID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        ProductMasterModel productMasterModel = new ProductMasterModel();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductQuantity"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);
                                }
                                if (!objSDR["ProductDetails"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                                }
                                if (!objSDR["ProductImage"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                                }
                            }
                        }
                        return productMasterModel;
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

        public List<ProductMasterModel> SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ProductMaster_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<ProductMasterModel> listProductMaster = new List<ProductMasterModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                ProductMasterModel productMasterModel = new ProductMasterModel();
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductQuantity"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);
                                }
                                if (!objSDR["ProductDetails"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                                }
                                if (!objSDR["ProductImage"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                                }
                                listProductMaster.Add(productMasterModel);
                            }
                            return listProductMaster;
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
        #endregion Select Operaction

        //-----------------------------------------------------------------------------------

        #region ShowProductSelectAll
        public List<ProductMasterModel> ShowProductSelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ShowProducts_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<ProductMasterModel> listProductMaster = new List<ProductMasterModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                ProductMasterModel productMasterModel = new ProductMasterModel();
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductImage"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                                }
                                listProductMaster.Add(productMasterModel);
                            }
                            return listProductMaster;
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
        #endregion ShowProductSelectAll

        #region ProductDetailsByID
        public ProductMasterModel ProductMasterShowDetailsByPK(SqlInt32 ProductID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ProductMasterShowDetails_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        ProductMasterModel productMasterModel = new ProductMasterModel();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductDetails"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                                }
                                if (!objSDR["ProductImage"].Equals(DBNull.Value))
                                {
                                    productMasterModel.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                                }
                            }
                        }
                        return productMasterModel;
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
        #endregion ProductDetailsByID
    }
}
