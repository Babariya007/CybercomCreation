using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }

        [Required]
        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category {  get; set; }
        public bool IsDelete { get; set; }

    }
}
