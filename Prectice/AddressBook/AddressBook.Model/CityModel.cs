using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    public class CityModel
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; }
        public string STDCode { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int UserID { get; set; }
    }
}
