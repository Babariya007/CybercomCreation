using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        #region UserList
        [HttpGet]
        public IActionResult Index()
        {
            var roles = userManager.Users;
            return View(roles);
        }
        #endregion UserList

        #region LockUser
        [HttpGet]
        public async Task<IActionResult> Lock(string email)
        {
            try
            {
                var userTask = userManager.FindByEmailAsync(email);

                if(userTask == null)
                {
                    ViewBag.Error = "Somthing was Wrong Please try again";
                }
                userTask.Wait();
                var user = userTask.Result;

                var lockUserTask = userManager.SetLockoutEnabledAsync(user, true);
                lockUserTask.Wait();

                var date = DateTime.Now.AddMonths(12);

                var lockDateTask = userManager.SetLockoutEndDateAsync(user, date);
                lockDateTask.Wait();

                if (lockUserTask.Result.Succeeded)
                {
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                else
                {
                    ViewBag.Error = "Somthing was Wrong";
                    return RedirectToAction("Index", "User", new { area = "Admin"});
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Error - " + ex.Message;
                return View();
            }
        }
        #endregion LockUser

        #region UnLockUser
        [HttpGet]
        public async Task<IActionResult> UnLock(string email)
        {
            try
            {
                var userTask = userManager.FindByEmailAsync(email);

                if (userTask == null)
                {
                    ViewBag.Error = "Somthing was Wrong Please try again";
                }
                userTask.Wait();
                var user = userTask.Result;

                var lockUserTask = userManager.SetLockoutEnabledAsync(user, false);
                lockUserTask.Wait();

                var lockDateTask = userManager.SetLockoutEndDateAsync(user, DateTime.Now);
                lockDateTask.Wait();

                if (lockUserTask.Result.Succeeded)
                {
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                else
                {
                    ViewBag.Error = "Somthing was Wrong";
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error - " + ex.Message;
                return View();
            }
        }
        #endregion UnLockUser
    }
}
