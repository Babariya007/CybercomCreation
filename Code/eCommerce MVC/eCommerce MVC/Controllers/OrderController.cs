using DAL;
using eCommerce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class OrderController : Controller
    {
        OrderDAL orderDAL = new OrderDAL();
        // GET: Order
        #region OrderList
        public ActionResult OrderList()
        {
            //List<OrderModel> orderList = orderDAL.OrderListSelectAll();
            //ViewData["OrderList"] = orderList;
            return View();
        }
        [HttpPost]
        public ActionResult OrderListDataTable()
        {
            var draw = Request.Form.GetValues("draw");
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            //string sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            int sortColumn = Convert.ToInt32(Request.Form.GetValues("order[0][column]")[0]);
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int pageSize = length != 0 ? Convert.ToInt32(length) : 0;
            int skip = start != 0 ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            List<OrderModel> orderList = orderDAL.OrderListSelectAll(length, start, sortColumn, sortColumnDir, searchValue);


            //total number of rows count     
            recordsTotal = orderList[0].filterCount;
            ////Paging     
            var data = orderList.Skip(skip).Take(pageSize).ToList();
            //draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, 
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = orderList}, JsonRequestBehavior.AllowGet);
        }
        #endregion OrderList
    }
}