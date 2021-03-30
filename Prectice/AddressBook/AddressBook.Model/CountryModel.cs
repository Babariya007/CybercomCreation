using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Model
{
    public class CountryModel
    {
        public int? CountryID { get; set; }

        [Required(ErrorMessage = "Please Enter Country Name")]
        public string CountryName { get; set; }
        
        [Required(ErrorMessage = "Please Enter Country Code")]
        public string CountryCode { get; set; }

        public string UserID { get; set; }

    }
}
