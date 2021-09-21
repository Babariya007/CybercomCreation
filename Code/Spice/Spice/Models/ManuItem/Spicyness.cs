using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class Spicyness
    {
        [Key]
        public int SpicynessID { get; set; }
        public string SpicynessName { get; set; }
    }
}
