using Spice.Areas.Admin.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.ViewModels.SubCategory
{
    public class SubCategoryViewModel
    {
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "Please Enter Sub Category Name")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "Select a Category")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
