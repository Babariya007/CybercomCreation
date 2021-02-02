using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerID
    {
        internal int CustomerId = 1;

        protected internal string CustomerCity = "Jamnagar";

        public string CustomerName = "Elon";

    }

    public class CustomerName
    {
        public void CustomerIDName()
        {
            CustomerID cid = new CustomerID();
            Console.WriteLine(cid.CustomerId);

            Console.WriteLine(cid.CustomerName);
        }
    }
}
