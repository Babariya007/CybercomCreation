using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class OrderSummary
    {
        [Key]
        public int OrderSummaryID { get; set; }
        
        public Cart Cart { get; set; }
        [Required]
        public int CartID { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [ForeignKey("Id")]
        public ApplicationUser AppUser { get; set; }
        public int UserID { get; set; }
    }
}
