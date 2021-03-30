using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee.Db.DbOperation;
using MyApp.Models;
using Newtonsoft.Json;

namespace EmployeeMVCPrectice.Controllers
{
    public class AddressController : Controller
    {
        AddressRepository repository = null;

        public AddressController()
        {
            repository = new AddressRepository();
        }

        #region GetAllData
        public ActionResult AddressList()
        {
            var empList = repository.AllAddressList();

            return View(empList);
        }
        #endregion GetAllData

        #region AddRecord
        public ActionResult AddRecord()
        {
            ViewBag.PageTitle = "Add New Record";
            return View();
        }
        [HttpPost]
        public ActionResult AddRecord(AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddAddress(addressModel);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Inserted Sucessfully...";
                }
            }
            return View();
        }
        #endregion AddRecord

        #region EditRecord
        public ActionResult UpdateAddress(int id)
        {
            ViewBag.PageTitle = "Update Record";
            var result = repository.UpdateAddress(id);

            return View("AddRecord", result);
        }
        [HttpPost]
        public ActionResult UpdateAddress(AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                var result = repository.UpdateAddress(addressModel);
                return View("AddRecord", result);
            }
            return View();
        }
        #endregion EditRecord

    }
}