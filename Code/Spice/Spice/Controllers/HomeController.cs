using Microsoft.AspNetCore.Mvc;
using Spice.Areas.Admin.ViewModels.ManuItem;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManuItemRepository manuItemRepository;
        private readonly AppDbContext _context;

        public HomeController(IManuItemRepository manuItemRepository, AppDbContext context)
        {
            this.manuItemRepository = manuItemRepository;
            this._context = context;
        }

        #region Home
        public IActionResult Index()
        {
            try
            {
                var model = manuItemRepository.GetAllManuItem();
                var cfm = new CommonFillMethod(_context);
                ViewBag.CategoryList = cfm.FillDropDownListCategoryID();
                return View(model);
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Exception - " + ex.Message;
                return View();
            }
        }
        #endregion Home

        #region CouponImages
        [HttpGet]
        public JsonResult CouponImage()
        {
            try
            {
                var image = _context.Coupons.Where(cou => cou.IsDelete == false && cou.IsActive == true).Select(cou => cou.Picture).ToList();
                return Json(image);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Exception - " + ex.Message;
                return Json("");
            }
        }
        #endregion CouponImages

    }
}
