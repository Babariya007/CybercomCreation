using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("OrderSummaryID")]
        public OrderSummary OrderSummary { get; set; }
        [Required]
        public int OrderSummaryID { get; set; }

        [ForeignKey("CartID")]
        public Cart Cart { get; set; }
        [Required]
        public int CartID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string AditionalInstruction { get; set; }
    }
}
