using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementAPI.Controllers
{
    public class InventoryController : ApiController
    {
        //Heare we can use one Controller or multipal controller
        //If use One controller then get route every every method or give in route {Controller}/{action}

        #region Customer

        #region CustomerSelectAll
        [HttpGet]
        public IHttpActionResult CustomerSelectAll()
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var customerList = entities.Customers.ToList();
                    if (customerList != null)
                    {
                        return Ok(customerList);
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
        #endregion CustomerSelectAll

        #region CustomerSelectAllByID
        [HttpGet]
        public IHttpActionResult CustomerSelectAll(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var customer = entities.Customers.FirstOrDefault(cus => cus.CustomerID == id);
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
        [HttpPost]
        public IHttpActionResult CustomerInsert([FromBody] Customer customer)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
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
        [HttpPut]
        public IHttpActionResult CustomerUpdate(int id, [FromBody] Customer customer)
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
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var cusID = entities.Customers.FirstOrDefault(e => e.CustomerID == id);
                    if (cusID != null)
                    {
                        entities.Customers.Remove(cusID);
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

        #endregion Customer

        #region Products

        #region ProductSelectAll
        [HttpGet]
        public IHttpActionResult ProductSelectAll()
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var productList = entities.Products.ToList();
                    if (productList != null)
                    {
                        return Ok(productList);
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
        #endregion ProductSelectAll

        #region ProductSelectAllByID
        [HttpGet]
        public IHttpActionResult ProductSelectAll(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var product = entities.Products.FirstOrDefault(pro => pro.ProductID == id);
                    if (product != null)
                    {
                        return Ok(product);
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
        #endregion ProductSelectAllByID

        #region ProductInsert
        [HttpPost]
        public IHttpActionResult ProductInsert([FromBody] Product product)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    entities.Products.Add(product);
                    entities.SaveChanges();

                    return Ok("Data Inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion ProductInsert

        #region ProductUpdate
        [HttpPut]
        public IHttpActionResult ProductUpdate(int id, [FromBody] Product product)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var pro = entities.Products.FirstOrDefault(p => p.ProductID == id);

                    if (pro != null)
                    {
                        pro.ProductName = product.ProductName;
                        pro.Stock = product.Stock;
                        pro.Price = product.Price;
                        pro.UpdatedDate = DateTime.Now;

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
        #endregion ProductUpdate

        #region DeleteCustomer
        [HttpDelete]
        public IHttpActionResult ProductDelete(int id)
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var proID = entities.Products.FirstOrDefault(p => p.ProductID == id);
                    if (proID != null)
                    {
                        entities.Products.Remove(proID);
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

        #endregion Products

    }
}
