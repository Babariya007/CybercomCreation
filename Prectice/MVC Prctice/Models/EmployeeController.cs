using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Prctice.Models
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var data = GetDetails();
            return View(data);
        }

        public ActionResult GetDetailsByID(int ID)
        {
            var data = GetDetails().FirstOrDefault(x=>x.ID == ID);
            return View(data);
        }

        public ActionResult GetNameByID(int ID)
        {
            var data = GetDetails().Where(x => x.ID == ID).Select(x => x.Name).FirstOrDefault();
            return View(data);
        }

        private List<MyDetails> GetDetails()
        {
            return new List<MyDetails>()
            {
                new MyDetails()
                {
                    ID=1,
                    Name="Abhay",
                    Address="Jamnagar"
                },

                new MyDetails()
                {
                    ID=2,
                    Name="Meet",
                    Address="Rajkot"
                },

                new MyDetails()
                {
                    ID=3,
                    Name="Dhaval",
                    Address="Baroda"
                },

                new MyDetails()
                {
                    ID=4,
                    Name="Maulik",
                    Address="Morbi"
                },

                new MyDetails()
                {
                    ID=5,
                    Name="Ajubhai",
                    Address="Rajkot"
                }
            };
        }
    }
}