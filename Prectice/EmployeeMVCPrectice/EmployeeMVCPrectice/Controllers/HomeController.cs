using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using Employee.Db.DbOperation;

namespace EmployeeMVCPrectice.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repository = null;

        #region HomeControllerConstructor
        public HomeController()
        {
            repository = new EmployeeRepository();
        }
        #endregion HomeControllerConstructor

        #region Insert
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel empModel)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddEmployee(empModel);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Inserted Sucessfully...";
                }
            }
            return View();
        }
        #endregion Insert

        #region Update
        public ActionResult GetAllRecord()
        {
            var result = repository.UpdateEmployee();
            return View(result);
        }
        public ActionResult Details(int id)
        {
            var result = repository.UpdateEmployee(id);
            return View(result);
        }
        #endregion Update

        #region Edit
        public ActionResult Edit(int id)
        {
            var result = repository.UpdateEmployee(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel empModel)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEmployee(empModel);

                return RedirectToAction("GetAllRecord");
            }
            return View();
        }
        #endregion Edit

        #region Delete
        public ActionResult Delete(int id)
        {
            repository.DeleteEmployee(id);

            return RedirectToAction("GetAllRecord");
        }
        #endregion Delete

    }
}