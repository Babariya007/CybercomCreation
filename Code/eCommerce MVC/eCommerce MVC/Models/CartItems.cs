using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce_MVC.Models
{
    public class CartItems
    {
        public int OrderQuentity { get; set; }
        public decimal GSTCharge { get; set; }
        public decimal TotalBill { get; set; }
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}