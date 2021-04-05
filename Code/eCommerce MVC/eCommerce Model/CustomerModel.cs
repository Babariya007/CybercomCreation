using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Model
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public int OrderQuentity { get; set; }
        public decimal TotalBill { get; set; }

        public OrderModel Order { get; set; }

    }
}
