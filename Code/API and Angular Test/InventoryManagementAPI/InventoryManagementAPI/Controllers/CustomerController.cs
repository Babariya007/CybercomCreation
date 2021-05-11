using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementAPI.Controllers
{
    public class CustomerController : ApiController
    {
        #region CustomerSelectAll
        //Here Use Store Procedure because of server side pagination ussing Store Procedure 
        public IHttpActionResult Get(int PageNo, int PageSize)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagementCS"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Customer_SelectAllPagination";
                objCmd.Parameters.AddWithValue("@PageNo", PageNo);
                objCmd.Parameters.AddWithValue("@PageSize", PageSize);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    string message = "No have any Data";
                    return Ok(message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //Count Total Records
        public IHttpActionResult Get()
        {
            try
            {
                int TotalRecords = 0;
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagementCS"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Customer_CountCustomers";

                using (SqlDataReader objSDR = objCmd.ExecuteReader())
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["TotalRecord"].Equals(DBNull.Value))
                        {
                            TotalRecords = Convert.ToInt32(objSDR["TotalRecord"]);
                        }
                    }
                }

                if (TotalRecords > 0)
                {
                    return Ok(TotalRecords);
                }
                else
                {
                    return Ok("No have any Data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion CustomerSelectAll

        #region CustomerSelectAllByID
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var customer = entities.Customers.Where(cus => cus.Status == true).FirstOrDefault(cus => cus.CustomerID == id);
                    if (customer != null)
                    {
                        return Ok(customer);
                    }
                    else
                    {
                        return Ok("No have any Data");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion CustomerSelectAllByID

        #region CustomerInsert
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    customer.Status = true;
                    customer.CreatedDate = DateTime.Now;
                    entities.Customers.Add(customer);
                    entities.SaveChanges();

                    return Ok("Data Inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion CustomerInsert

        #region CustomerUpdate
        public IHttpActionResult Put(int id, [FromBody] Customer customer)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var cus = entities.Customers.FirstOrDefault(c => c.CustomerID == id);

                    if (cus != null)
                    {
                        cus.CustomerName = customer.CustomerName;
                        cus.Email = customer.Email;
                        cus.Phone = customer.Phone;
                        cus.UpdatedDate = DateTime.Now;

                        entities.SaveChanges();

                        return Ok("Data Updated Successfully");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion CustomerUpdate

        #region DeleteCustomer
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var cusID = entities.Customers.Where(cus => cus.Status == true).FirstOrDefault(e => e.CustomerID == id);
                    if (cusID != null)
                    {
                        //entities.Customers.Remove(cusID);
                        cusID.Status = false;
                        entities.SaveChanges();
                        return Ok("Data Deleted");
                    }
                    else
                    {
                        return Ok("This Data Already Deleted");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion DeleteCustomer

        #region Search Customer
        public IHttpActionResult Get(int PageNo, int PageSize, string SearchText)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagementCS"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Customer_SearchByCustomerName";
                objCmd.Parameters.AddWithValue("@PageNo", PageNo);
                objCmd.Parameters.AddWithValue("@PageSize", PageSize);
                objCmd.Parameters.AddWithValue("@SearchText", SearchText);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    string message = "No have any Data";
                    return Ok(message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion Search Customer

    }
}
