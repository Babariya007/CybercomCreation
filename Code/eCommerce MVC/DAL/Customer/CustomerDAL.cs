using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        #region CustomerOrderList
        public List<CustomerModel> OrderListSelectAll()
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
                        List<CustomerModel> listCustomer = new List<CustomerModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                CustomerModel customerModel = new CustomerModel();
                                if (!objSDR["CustomerID"].Equals(DBNull.Value))
                                {
                                    customerModel.CustomerID = Convert.ToInt32(objSDR["CustomerID"]);
                                }
                                if (!objSDR["FirstName"].Equals(DBNull.Value))
                                {
                                    customerModel.FirstName = Convert.ToString(objSDR["FirstName"]);
                                }
                                if (!objSDR["LastName"].Equals(DBNull.Value))
                                {
                                    customerModel.LastName = Convert.ToString(objSDR["LastName"]);
                                }
                                if (!objSDR["OrderQuentity"].Equals(DBNull.Value))
                                {
                                    customerModel.OrderQuentity = Convert.ToInt32(objSDR["OrderQuentity"]);
                                }
                                if (!objSDR["TotalBill"].Equals(DBNull.Value))
                                {
                                    customerModel.TotalBill = Convert.ToInt32(objSDR["TotalBill"]);
                                }
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    customerModel.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                {
                                    customerModel.ProductName = Convert.ToString(objSDR["ProductName"]);
                                }
                                listCustomer.Add(customerModel);
                            }
                            return listCustomer;
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
