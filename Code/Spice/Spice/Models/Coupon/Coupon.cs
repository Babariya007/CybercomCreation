using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class Coupon
    {
        [Key]
        public int CouponID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Picture { get; set; }
        
        [Required]
        public int CouponTypeID { get; set; }
        
        [ForeignKey("CouponTypeID")]
        public CouponType CouponType { get; set; }
        
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Discount { get; set; }
        
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal MinimumAmount { get; set; }
        
        [Required]
        public bool IsActive { get; set; }
        
        public bool IsDelete { get; set; }
    }
}
