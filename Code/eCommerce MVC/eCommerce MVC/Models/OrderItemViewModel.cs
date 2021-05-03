using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce_MVC.Models
{
    public class OrderItemViewModel
    {
        public int OrderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int OrderQuantity { get; set; }

    }
}