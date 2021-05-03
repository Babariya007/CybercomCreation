using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for DALProductMaster
/// </summary>
namespace eCommerce
{
    public class DALProductMaster : DataBaseConfig
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

        public Boolean Insert(ENTProductMaster entProductMaster)
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
                        objCmd.Parameters.AddWithValue("@ProductName", entProductMaster.ProductName);
                        objCmd.Parameters.AddWithValue("@ProductQuntity", entProductMaster.ProductQuantity);
                        objCmd.Parameters.AddWithValue("@ProductDetails", entProductMaster.ProductDetails);
                        objCmd.Parameters.AddWithValue("@ProductPrice", entProductMaster.ProductPrice);
                        objCmd.Parameters.AddWithValue("@ProductImage", entProductMaster.ProductImage);

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

        public Boolean Update(ENTProductMaster entProductMaster)
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
                        objCmd.Parameters.AddWithValue("@ProductID", entProductMaster.ProductID);
                        objCmd.Parameters.AddWithValue("@ProductName", entProductMaster.ProductName);
                        objCmd.Parameters.AddWithValue("@ProductQuntity", entProductMaster.ProductQuantity);
                        objCmd.Parameters.AddWithValue("@ProductDetails", entProductMaster.ProductDetails);
                        objCmd.Parameters.AddWithValue("@ProductPrice", entProductMaster.ProductPrice);
                        objCmd.Parameters.AddWithValue("@ProductImage", entProductMaster.ProductImage);
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

        public ENTProductMaster SelectByPK(SqlInt32 ProductID)
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

                        ENTProductMaster entProductMaster = new ENTProductMaster();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductQuantity"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);
                                }
                                if (!objSDR["ProductDetails"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                                }
                                if (!objSDR["ProductImage"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                                }
                            }
                        }
                        return entProductMaster;
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

        public DataTable SelectAll()
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
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
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

        #region Show Data Using DataTable
        [WebMethod(), ScriptMethod()]
        public string SelectAllByDataTable()
        {
            List<ENTProductMaster> listProductMaster = new List<ENTProductMaster>();

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_ProductMaster_SelectAll";
                    #endregion Prepare Command

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {

                        while (objSDR.Read())
                        {
                            ENTProductMaster entProductMaster = new ENTProductMaster();

                            if (!objSDR["ProductID"].Equals(DBNull.Value))
                            {
                                entProductMaster.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                            }
                            if (!objSDR["ProductName"].Equals(DBNull.Value))
                            {
                                entProductMaster.ProductName = Convert.ToString(objSDR["ProductName"]);
                            }
                            if (!objSDR["ProductQuantity"].Equals(DBNull.Value))
                            {
                                entProductMaster.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);
                            }
                            if (!objSDR["ProductDetails"].Equals(DBNull.Value))
                            {
                                entProductMaster.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
                            }
                            if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                            {
                                entProductMaster.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                            }
                            if (!objSDR["ProductImage"].Equals(DBNull.Value))
                            {
                                entProductMaster.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                            }
                            listProductMaster.Add(entProductMaster);
                        }
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(listProductMaster);
            return jsonData;
        }
        #endregion Show Data Using DataTable

        //#region Show Data Server Side DataTable
        //[WebMethod(), ScriptMethod()]
        //public string SelectAllDataByServerSide(int iDisplayLength,int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        //{
        //    HttpContext context = HttpContext.Current;
        //    context.Response.ContentType = "text/plain";

        //    int displayLength = iDisplayLength;
        //    int displayStart = iDisplayStart;
        //    int sortColumn = iSortCol_0;
        //    string sortDir = sSortDir_0;
        //    string search = sSearch;
        //    int filterCount = 0;

        //    List<ENTProductMaster> listProductMaster = new List<ENTProductMaster>();

        //    using (SqlConnection objConn = new SqlConnection(ConnectionString))
        //    {
        //        objConn.Open();
        //        using (SqlCommand objCmd = objConn.CreateCommand())
        //        {
        //            #region Prepare Command
        //            objCmd.CommandType = CommandType.StoredProcedure;
        //            objCmd.CommandText = "PR_ProductMaster_SelectAllDataTable";
        //            objCmd.Parameters.AddWithValue("@DisplayLength", displayLength);
        //            objCmd.Parameters.AddWithValue("@DisplayStart", displayStart);
        //            objCmd.Parameters.AddWithValue("@SortColumn", sortColumn);
        //            objCmd.Parameters.AddWithValue("@SortDirection", sortDir);
        //            objCmd.Parameters.AddWithValue("@Search", search);
        //            #endregion Prepare Command

        //            using (SqlDataReader objSDR = objCmd.ExecuteReader())
        //            {

        //                while (objSDR.Read())
        //                {
        //                    ENTProductMaster entProductMaster = new ENTProductMaster();

        //                    if (!objSDR["ProductID"].Equals(DBNull.Value))
        //                    {
        //                        entProductMaster.ProductID = Convert.ToInt32(objSDR["ProductID"]);
        //                    }
        //                    if (!objSDR["TotalCount"].Equals(DBNull.Value))
        //                    {
        //                        filterCount = Convert.ToInt32(objSDR["TotalCount"]);
        //                    }
        //                    if (!objSDR["ProductName"].Equals(DBNull.Value))
        //                    {
        //                        entProductMaster.ProductName = Convert.ToString(objSDR["ProductName"]);
        //                    }
        //                    if (!objSDR["ProductQuantity"].Equals(DBNull.Value))
        //                    {
        //                        entProductMaster.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);
        //                    }
        //                    if (!objSDR["ProductDetails"].Equals(DBNull.Value))
        //                    {
        //                        entProductMaster.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
        //                    }
        //                    if (!objSDR["ProductPrice"].Equals(DBNull.Value))
        //                    {
        //                        entProductMaster.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
        //                    }
        //                    if (!objSDR["ProductImage"].Equals(DBNull.Value))
        //                    {
        //                        entProductMaster.ProductImage = Convert.ToString(objSDR["ProductImage"]);
        //                    }
        //                    listProductMaster.Add(entProductMaster);
        //                }
        //            }
        //        }
        //    }

        //    var result = new
        //    {
        //        iTotalRecords = GetTotalProduct(),
        //        iTotalDisplayRecords = filterCount,
        //        aaData = listProductMaster
        //    };
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    context.Response.Write(js.Serialize(result));
        //}
        //private int GetTotalProduct()
        //{
        //    int totalProductCount = 0;
        //    using (SqlConnection objConn = new SqlConnection(ConnectionString))
        //    {
        //        objConn.Open();
        //        SqlCommand objCmd = new SqlCommand("Select count(*) from ProductMaster", objConn);
        //        objConn.Open();
        //        totalProductCount = (int)objCmd.ExecuteScalar();
        //    }
        //    return totalProductCount;
        //}
        //#endregion Show Data Server Side DataTable

        //-----------------------------------------------------------------------

        #region ShowProducts

        public DataTable ShowProducts()
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
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
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

        #endregion ShowProducts

        #region ProductDetailsByID
        public ENTProductMaster ProductMasterShowDetailsByPK(SqlInt32 ProductID)
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

                        ENTProductMaster entProductMaster = new ENTProductMaster();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                if (!objSDR["ProductDetails"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
                                }
                                if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                                }
                                if (!objSDR["ProductImage"].Equals(DBNull.Value))
                                {
                                    entProductMaster.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                                }
                            }
                        }
                        return entProductMaster;
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

        #region GetProductNamePriceSelectAll
        public DataTable GetProductNamePriceSelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ProductMaster_GetProductNamePriceSelectAll";
                        #endregion Prepar Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
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
        #endregion GetProductNamePriceSelectAll
    }
}