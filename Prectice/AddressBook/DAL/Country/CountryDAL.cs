using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Model;

namespace DAL
{
    public class CountryDAL : DatabaseConfig
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

        public Boolean Insert(CountryModel countryModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_Insert";
                        objCmd.Parameters.AddWithValue("@CountryName", countryModel.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", countryModel.CountryCode);
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(countryModel.UserID));
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

        #region SelectAll
        public List<CountryModel> SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectAll";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        //DataTable dt = new DataTable();
                        
                        List<CountryModel> listCountry = new List<CountryModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //dt.Load(objSDR);
                            while (objSDR.Read())
                            {
                                CountryModel entCountry = new CountryModel();
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);
                                }
                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);
                                }
                                listCountry.Add(entCountry);
                            }
                        }
                        #endregion ReadData and Set Controls

                        return listCountry;
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
        #endregion SelectAll

        #region SelectByPK
        public CountryModel SelectByPK(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_Country_SelectByPK";
                        objcmd.Parameters.AddWithValue("@CountryID", CountryID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        CountryModel entCountry = new CountryModel();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);
                                }
                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);
                                }
                            }
                        }
                        return entCountry;
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
        #endregion SelectByPK

        #region Update

        public Boolean Update(CountryModel countryModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", countryModel.CountryID);
                        objCmd.Parameters.AddWithValue("@CountryName", countryModel.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", countryModel.CountryCode);
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

        #endregion Update

        #region Delete 

        public Boolean Delete(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
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

        #endregion Delete

        #region CountryDropDown
        public List<CountryModel> SelectDropDownList(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectDropDownList";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<CountryModel> listCountry = new List<CountryModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //dt.Load(objSDR);
                            while (objSDR.Read())
                            {
                                CountryModel countryModel = new CountryModel();
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    countryModel.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    countryModel.CountryName = Convert.ToString(objSDR["CountryName"]);
                                }
                                listCountry.Add(countryModel);
                            }
                            return listCountry;
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
        #endregion CountryDropDown
    }
}
