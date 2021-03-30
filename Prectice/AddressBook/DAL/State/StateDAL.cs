using AddressBook.Model;
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
    public class StateDAL : DatabaseConfig
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
        public Boolean Insert(StateModel stateModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_Insert";
                        objCmd.Parameters.AddWithValue("@CountryID", stateModel.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", stateModel.StateName);
                        objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(stateModel.UserID));
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
        #endregion Insert Operaction

        #region SelectAll
        public List<StateModel> SelectAll(SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectAll";
                        objCmd.Parameters.AddWithValue("@UserID", StateID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<StateModel> listState = new List<StateModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                StateModel stateModel = new StateModel();
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    stateModel.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    stateModel.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                {
                                    stateModel.StateName = Convert.ToString(objSDR["StateName"]);
                                }
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    stateModel.CountryName = Convert.ToString(objSDR["CountryName"]);
                                }
                                listState.Add(stateModel);
                            }
                        }
                        #endregion ReadData and Set Controls

                        return listState;
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
        public StateModel SelectByPK(SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command
                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_State_SelectByPK";
                        objcmd.Parameters.AddWithValue("@StateID", StateID);
                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        StateModel stateModel = new StateModel();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    stateModel.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                {
                                    stateModel.StateName = Convert.ToString(objSDR["StateName"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    stateModel.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    stateModel.CountryName = Convert.ToString(objSDR["CountryName"]);
                                }
                            }
                        }
                        return stateModel;
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

        public Boolean Update(StateModel stateModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StateID", stateModel.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", stateModel.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", stateModel.StateName);
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

        public Boolean Delete(SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
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

    }
}
