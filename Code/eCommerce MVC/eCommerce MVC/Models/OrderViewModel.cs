using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce_MVC.Models
{
    public class OrderViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderQuentity { get; set; }
        public int GSTAmount { get; set; }
        public decimal TotalBill { get; set; }

    }
}