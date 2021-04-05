using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Model
{
    public class CartModel
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }

    }
}
