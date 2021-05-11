using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementAPI.Controllers
{
    public class OrderTypesController : ApiController
    {
        //---------------------  This Controller is not Currently Use  ------------------------------

        #region OrderTypeSelectAll
        public IHttpActionResult Get()
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var orderTypeList = entities.OrderTypes.Where(o => o.Status == true).ToList();
                    if (orderTypeList != null)
                    {
                        return Ok(orderTypeList);
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
        #endregion OrderTypeSelectAll

        #region OrderTypeSelectAllByID
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var orderType = entities.OrderTypes.Where(o => o.Status == true).FirstOrDefault(ot => ot.OrderTypeID == id);
                    if (orderType != null)
                    {
                        return Ok(orderType);
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
        #endregion OrderTypeSelectAllByID

        #region OrderTypeInsert
        public IHttpActionResult Post([FromBody] OrderType orderType)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    orderType.Status = true;
                    orderType.CreatedDate = DateTime.Now;
                    entities.OrderTypes.Add(orderType);
                    entities.SaveChanges();

                    return Ok("Data Inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion OrderTypeInsert

        #region OrderTypeUpdate
        public IHttpActionResult Put(int id, [FromBody] OrderType orderType)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var ordType = entities.OrderTypes.FirstOrDefault(ot => ot.OrderTypeID == id);

                    if (ordType != null)
                    {
                        ordType.Name = orderType.Name;
                        ordType.Detail = orderType.Detail;
                        ordType.UpdatedDate = DateTime.Now;

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
        #endregion OrderTypeUpdate

        #region OrderTypeDelete
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var ordTypeID = entities.OrderTypes.Where(or => or.Status == true).FirstOrDefault(ot => ot.OrderTypeID == id);
                    if (ordTypeID != null)
                    {
                        ordTypeID.Status = false;
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
        #endregion OrderTypeDelete

    }
}
