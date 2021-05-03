using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce_Model;
using DAL;
using System.Web.Script.Serialization;
using eCommerce_MVC.Models;
using System.Text;

namespace eCommerce_MVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAL customerDAL = new CustomerDAL();

        #region CheckOut
        [HttpGet]
        public ActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]

        public JsonResult CheckOut(string json)
        {
            var model = new JavaScriptSerializer().Deserialize<CartItems>(json);
            TempData["CartItems"] = model;
            return Json("success");
        }
        #endregion CheckOut

        #region Order
        [HttpPost]
        public ActionResult Order(CustomerViewModel customerViewModel)
        {
            #region Download pdf
            //StringBuilder sb = new StringBuilder();
            //sb.Append("Name : " + customerViewModel.FirstName + " " + customerViewModel.LastName + "\n");
            //sb.Append("Address : " + customerViewModel.Address + "\n\n\n");

            //sb.Append("Total Quantity : " + customerViewModel.OrderQuantity + "\n");
            //sb.Append("18% GST Charge : " + customerViewModel.GSTCharge + "\n\n");
            //sb.Append("Total Bill : " + customerViewModel.TotalBill + "\n");
            
            //Customer Insert
            CustomerModel customerModel = new CustomerModel();
            customerModel.Address = customerViewModel.Address;
            customerModel.FirstName = customerViewModel.FirstName;
            customerModel.LastName = customerViewModel.LastName;
            customerDAL.AddCustomer(customerModel);
            
            //Order Insert
            OrderModel ordermodel = new OrderModel();
            ordermodel.CustomerID = customerModel.CustomerID;
            ordermodel.FirstName = customerViewModel.FirstName;
            ordermodel.LastName = customerViewModel.LastName;
            ordermodel.TotalQuantity = customerViewModel.OrderQuantity;
            ordermodel.GSTAmount = customerViewModel.GSTCharge;
            ordermodel.TotalAmount = customerViewModel.TotalBill;
            customerDAL.AddOrder(ordermodel);

            //OrderItem Insert
            foreach (var product in customerViewModel.Products)
            {
                OrderItemModel orderitemmodel = new OrderItemModel();
                orderitemmodel.OrderID = ordermodel.OrderID;
                orderitemmodel.ProductID = product.Id;
                orderitemmodel.OrderQuantity = product.Quantity;
                //sb.Append("ProductName : " + Session["ProductName"] + "\n");
                //sb.Append("Quantity : " + customerViewModel.OrderQuantity + "\n");

                customerDAL.AddOrderItem(orderitemmodel);
            }

            customerDAL.TruncateCart();

            //Response.Clear();
            //Response.ContentType = "application/txt";
            //Response.Buffer = true;
            //Response.AppendHeader("content-disposition", "attachement;filename=ProductBill.txt");
            //Response.BinaryWrite(Encoding.UTF8.GetBytes(sb.ToString()));

            #endregion Download pdf
            return RedirectToAction("Home", "ProductMaster");

        }
        #endregion Order

    }
}