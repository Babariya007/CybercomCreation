using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce_MVC.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ProductID { get; set; }
        public int OrderQuantity { get; set; }
        public decimal TotalBill { get; set; }
        public decimal GSTCharge { get; set; }
        public List<Product> Products { get; set; }
    }
}