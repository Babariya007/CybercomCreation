using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALCustomer
/// </summary>
namespace eCommerce
{
    public class DALCustomer : DataBaseConfig
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
        public Boolean Insert(ENTCustomer entCustomer)
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
                        objCmd.Parameters.AddWithValue("@FirstName", entCustomer.FirstName);
                        objCmd.Parameters.AddWithValue("@LastName", entCustomer.LastName);
                        objCmd.Parameters.AddWithValue("@Address", entCustomer.Address);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        entCustomer.CustomerID = (int)objCmd.Parameters["@CustomerID"].Value;
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

        #region CustomerOrderList

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
                        objCmd.CommandText = "PR_CustomerOrderList_SelectAll";
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

        #endregion CustomerOrderList
    }
}