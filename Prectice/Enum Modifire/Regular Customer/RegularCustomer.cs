using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer;

namespace Regular_Customer
{
    public class RegularCustomer : CustomerID
    {
        public void print()
        {
            CustomerID cid = new CustomerID();
            //cid.CustomerName = "Abhay";                 //Cutomer Name is public than we can access
            //base.CustomerCity = "Jamnagar";             //Customer city is protected internal then use it first time with base keyword



            //-------------   We can also write this way   ----------------------
            Console.WriteLine(cid.CustomerName);
            Console.WriteLine(base.CustomerCity);
            Console.WriteLine(cid.CustomerName + " " + base.CustomerCity);
        }
    }
}
