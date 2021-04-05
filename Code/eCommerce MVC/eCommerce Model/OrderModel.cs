using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Model
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderItemModel OrderItem { get; set; }
    }
}
