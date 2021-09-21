using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.ViewModels.Coupon
{
    public class CouponViewModel
    {
        public int CouponID { get; set; }

        [Required]
        public string Name { get; set; }

        public IFormFile Picture { get; set; }

        public string ExsistingPhoto { get; set; }

        [Required]
        public int CouponTypeID { get; set; }
        public string CouponTypeName { get; set; }
        [Required]
        public decimal Discount { get; set; }

        [Required]
        public decimal MinimumAmount { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }
}
