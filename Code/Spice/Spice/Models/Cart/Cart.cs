using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("ManuItemID")]
        public ManuItem ManuItem { get; set; }
        [Required]
        public int ManuItemID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, ForeignKey("Id")]
        public ApplicationUser AppUser { get; set; }
        public string Id { get; set; }
    }
}
