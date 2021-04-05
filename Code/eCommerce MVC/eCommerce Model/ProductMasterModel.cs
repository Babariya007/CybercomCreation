using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace eCommerce_Model
{
    public class ProductMasterModel
    {
        public int? ProductID { get; set; }
        
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter Product Quantity")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Please Enter Product Details")]
        public string ProductDetails { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Please Select Image")]
        public string ProductImage { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
