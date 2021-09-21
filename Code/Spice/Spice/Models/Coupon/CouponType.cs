using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class CouponType
    {
        [Key]
        public int CouponTypeID { get; set; }
        public string CouponTypeName { get; set; }
    }
}
