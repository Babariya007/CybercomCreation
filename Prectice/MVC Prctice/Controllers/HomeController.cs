using MVC_Prctice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Prctice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            var data = GetDetails();
            return View(data);
        }

        

        private MyDetails GetDetails()
        {
            MyDetails details = new MyDetails();
            details.ID = 1;
            details.Name = "Abhay";
            details.Address = "Jamnagar";
            return details;
        }
    }
}