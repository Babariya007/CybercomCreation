using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.ViewModels.Cart
{
    public class CartViewModel
    {
        public int CartID { get; set; }

        public int ManuItemID { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

        public string Id { get; set; }

    }
}
