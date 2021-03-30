﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    public class StateModel
    {
        public int? StateID { get; set; }
        public int CountryID { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        //public DateTime CreationDate { get; set; }
        public int UserID { get; set; }

    }
}
