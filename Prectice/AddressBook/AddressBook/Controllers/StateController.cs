using AddressBook.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class StateController : Controller
    {
        StateDAL dalState = new StateDAL();

        #region Create Update
        public ActionResult Create(int? id)
        {
            ViewBag.CountryList = new SelectList(CountryList(), "CountryID", "CountryName");
            if (id != null)
            {
                ViewBag.PageTitle = "Update Record";
                ViewBag.Title = ViewBag.Button = "Update";
                var State = dalState.SelectByPK(Convert.ToInt32(id));
                return View(State);
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
        public ActionResult Create(StateModel stateModel)
        {
            if (ModelState.IsValid)
            {
                if (stateModel.StateID != null)
                {
                    dalState.Update(stateModel);
                    return RedirectToAction("StateList");
                }
                else
                {
                    stateModel.UserID = Convert.ToInt32(Session["UserID"]);
                    dalState.Insert(stateModel);
                    ViewBag.InsertMessage = "Data Inserted Successfully...";
                }
                ModelState.Clear();
            }
            return RedirectToAction("Create");
        }

        public List<CountryModel> CountryList()
        {
            CountryDAL dalCountry = new CountryDAL();
            List<CountryModel> countryList = dalCountry.SelectDropDownList(Convert.ToInt32(Session["UserID"]));
            return countryList;
        }
        #endregion Create Update

        #region CountryList
        public ActionResult StateList()
        {
            List<StateModel> stateList = dalState.SelectAll(Convert.ToInt32(Session["UserID"]));
            ViewData["State"] = stateList;
            return View();
        }
        #endregion CountryList

        #region Delete
        public ActionResult Delete(int id)
        {
            dalState.Delete(id);
            return RedirectToAction("StateList");
        }
        #endregion Delete

    }
}