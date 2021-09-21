using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class ManuItem
    {
        [Key]
        public int ManuItemID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Decription { get; set; }
        
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [Required]
        public string Image { get; set; }
        
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
        
        public int SubCategoryID { get; set; }
        [ForeignKey("SubCategoryID")]
        public SubCategory SubCategory { get; set; }
        
        [Required]
        public int SpicynessID { get; set; }
        [ForeignKey("SpicynessID")]
        public Spicyness Spicyness { get; set; }
        
        public bool IsDelete { get; set; }
        
    }
}
