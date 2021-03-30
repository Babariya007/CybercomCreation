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
    public class LoginController : Controller
    {
        MasterUserDAL dalMasterUser = new MasterUserDAL();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MasterUserModel masterUserModel)
        {
            DataTable dtMasterUser = dalMasterUser.SelectByUserNamePassword(masterUserModel.UserName, masterUserModel.Password);
            if (dtMasterUser != null && dtMasterUser.Rows.Count > 0)
            {
                foreach (DataRow drow in dtMasterUser.Rows)
                {
                    if (!drow["UserID"].Equals(System.DBNull.Value))
                        Session["UserID"] = drow["UserID"].ToString();

                    if (!drow["UserName"].Equals(System.DBNull.Value))
                        Session["UserName"] = drow["UserName"].ToString();
                }
                return RedirectToAction("CountryList", "Country");
            }
            else
            {
                ViewBag.Text = "Invalid Username or Password";
            }
            return View();

        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}