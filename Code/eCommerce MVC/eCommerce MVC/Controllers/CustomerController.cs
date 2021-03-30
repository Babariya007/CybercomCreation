using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce_Model;
using DAL;

namespace eCommerce_MVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAL customerDAL = new CustomerDAL();

        #region OrderList
        public ActionResult OrderList()
        {
            List<CustomerModel> orderList = customerDAL.OrderListSelectAll();
            ViewData["OrderList"] = orderList;
            return View();
        }
        #endregion OrderList

        

    }
}