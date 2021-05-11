using InventoryManagementAPI.Models;
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
    public class OrdersController : ApiController
    {
        #region OrdersSelectAll
        // We can also useing Store Procedure
        //Heare use Store Procedure for Demo Purpose
        public IHttpActionResult Get(int PageNo, int PageSize, string Dir)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagementCS"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Orders_SelectAllPagination";
                objCmd.Parameters.AddWithValue("@PageNo", PageNo);
                objCmd.Parameters.AddWithValue("@PageSize", PageSize);
                objCmd.Parameters.AddWithValue("@Direction", Dir);

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
                    return Ok("No have any Data");
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
                objCmd.CommandText = "PR_Orders_CountOrders";

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
        #endregion OrdersSelectAll

        #region Orders Search By Date
        [HttpPost]
        public IHttpActionResult SearchByDate([FromBody] DateFilterModel dateFilter)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagementCS"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Orders_SelectAllByDate";
                objCmd.Parameters.AddWithValue("@FromDate", dateFilter.FromDate);
                objCmd.Parameters.AddWithValue("@ToDate", dateFilter.ToDate);

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
                    return Ok("No Data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion Orders Search By Date

        //-------------------   This are not currently use  ---------------------

        #region OrdersInsert
        //public IHttpActionResult Post([FromBody] Order order)
        //{
        //    try
        //    {
        //        using (InventoryManagementEntities entities = new InventoryManagementEntities())
        //        {
        //            order.Status = true;
        //            order.CreatedDate = DateTime.Now;
        //            entities.Orders.Add(order);
        //            entities.SaveChanges();

        //            return Ok("Data Inserted Successfully");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}
        #endregion OrdersInsert

        #region OrdersUpdate
        public IHttpActionResult Put(int id, [FromBody] Order order)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var ord = entities.Orders.FirstOrDefault(ot => ot.OrderID == id);

                    if (ord != null)
                    {
                        ord.OrderTypeID = order.OrderTypeID;
                        ord.OrderDate = order.OrderDate;
                        ord.ProductID = order.ProductID;
                        ord.Quantity = order.Quantity;
                        ord.TotalPrice = order.TotalPrice;
                        ord.UpdatedDate = DateTime.Now;

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
        #endregion OrdersUpdate

        #region OrdersDelete
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var order = entities.Orders.Where(ord => ord.Status == true).FirstOrDefault(o => o.OrderID == id);
                    if (order != null)
                    {
                        //entities.Orders.Remove(order);
                        order.Status = false;
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
        #endregion OrdersDelete
    }
}
