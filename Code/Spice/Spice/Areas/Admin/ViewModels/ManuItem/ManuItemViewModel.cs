using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.ViewModels.ManuItem
{
    public class ManuItemViewModel
    {
        public int ManuItemID { get; set; }
        [Required(ErrorMessage = "Please Enter Item Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        public string Decription { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string ExsistingPhoto { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please Select Sub Category")]
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        [Required(ErrorMessage = "Please Select Spicyness")]
        public int SpicynessID { get; set; }
        public string SpicynessName { get; set; }
        public int Quantity { get; set; }
    }
}
