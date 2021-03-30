using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Model;
using DAL;

namespace AddressBook.Controllers
{
    public class CountryController : Controller
    {
        CountryDAL dalCountry = new CountryDAL();

        #region Create Update
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.PageTitle = "Update Record";
                ViewBag.Title = ViewBag.Button = "Update";
                var Country = dalCountry.SelectByPK(Convert.ToInt32(id));
                return View(Country);
            }
            else
            {
                ViewBag.PageTitle = "Add New Record";
                ViewBag.Title = "Add New";
                ViewBag.Button = "Save";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                if (countryModel.CountryID != null)
                {
                    dalCountry.Update(countryModel);
                    return RedirectToAction("CountryList");
                }
                else 
                {
                    countryModel.UserID = Session["UserID"].ToString();
                    dalCountry.Insert(countryModel);
                    ViewBag.InsertMessage = "Data Inserted Successfully...";
                }
                ModelState.Clear();
                return View();
            }
            return View("Create");
        }
        #endregion Creazte Update

        #region CountryList
        public ActionResult CountryList()
        {
            List<CountryModel> country = dalCountry.SelectAll(Convert.ToInt32(Session["UserID"]));
            ViewData["Country"] = country;
            return View();
        }
        #endregion CountryList

        #region Delete
        public ActionResult Delete(int id)
        {
            dalCountry.Delete(id);
            return RedirectToAction("CountryList");
        }
        #endregion Delete

    }
}