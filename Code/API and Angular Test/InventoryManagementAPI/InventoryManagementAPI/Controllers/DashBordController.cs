using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementAPI.Controllers
{
    public class DashBordController : ApiController
    {
        #region DashBord
        public IHttpActionResult Get()
        {
            try
            {
                using (InventoryManagementEntities entities = new InventoryManagementEntities())
                {
                    var NoOfProduct = entities.Products.Where(pro => pro.Status == true && pro.Stock > 0).Count();
                    var TodayOrder = entities.Orders.Where(ord => ord.OrderDate == DateTime.Today).Count();
                    var LessQuntity = entities.Products.Where(pro => pro.Stock <= 10).Count();

                    string DashbordJsonData = @"{'NoOfProduct':'"+ NoOfProduct +"', 'TodayOrder': '"+ TodayOrder +"', 'LessQuantity': '"+ LessQuntity +"'}";
                    JObject json = JObject.Parse(DashbordJsonData);
                    return Ok(json);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion DashBord
    }
}
