using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascaddingDropDown.Models;

namespace CascaddingDropDown.Controllers
{
    public class DropdownController : Controller
    {
        DropdownCS cs = new DropdownCS();

        // GET: Dropdown
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(CountryList(), "CountryID", "CountryName");
            //ViewBag.StateList = new SelectList(StateList(), "StateID", "StateName");
            return View();
        }

        public List<Country> CountryList()
        {
            List<Country> countryList = cs.Country.ToList();
            return countryList;
        }

        //public List<State> StateList()
        //{
        //    List<State> stateList = cs.State.ToList();
        //    return stateList;
        //}

        public JsonResult StateList(int CountryID)
        {
            List<State> stateList = cs.State.Where(x => x.CountryID == CountryID).ToList();
            //ViewBag.StateList = new SelectList(stateList, "StateID", "StateName");
            return Json(stateList.Where(x => x.CountryID == CountryID), JsonRequestBehavior.AllowGet);
        }
    }
}