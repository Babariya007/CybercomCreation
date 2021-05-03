using DAL;
using eCommerce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class OrderItemController : Controller
    {
        OrderItemDAL orderItemDAL = new OrderItemDAL();
        // GET: OrderItem
        public ActionResult OrderDetails(int id)
        {
            OrderItemModel orderItemModel = new OrderItemModel();
            List<OrderItemModel> orderItems = orderItemDAL.OrderDetailsByID(id);
            ViewData["OrderItemList"] = orderItems;
            ViewBag.FirstName = orderItems[0].FirstName;
            ViewBag.LastName = orderItems[0].LastName;
            ViewBag.Address = orderItems[0].Address;
            ViewBag.TotalQuantity = orderItems[0].TotalQuantity;
            ViewBag.GSTAmount = orderItems[0].GSTAmount;
            ViewBag.TotalAmount = orderItems[0].TotalAmount;
            ViewBag.OrderDate = orderItems[0].OrderDate;

            return View();
        }
    }
}