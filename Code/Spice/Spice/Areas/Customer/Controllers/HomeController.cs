using Microsoft.AspNetCore.Mvc;
using Spice.Areas.Admin.ViewModels.ManuItem;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IManuItemRepository manuItemRepository;

        public HomeController(IManuItemRepository manuItemRepository)
        {
            this.manuItemRepository = manuItemRepository;
        }

        #region Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                ManuItem manuItem = manuItemRepository.GetManuItemByID(id);

                if (manuItem == null)
                {
                    return View("NotFound");
                }

                ManuItemViewModel manuItemViewModel = new ManuItemViewModel
                {
                    ManuItemID = manuItem.ManuItemID,
                    Name = manuItem.Name,
                    //Decription = Regex.Replace(manuItem.Decription, "<.*?>", String.Empty),
                    Decription = manuItem.Decription,
                    Price = manuItem.Price,
                    ExsistingPhoto = manuItem.Image,
                    CategoryName = manuItem.Category.CategoryName,
                    SubCategoryName = manuItem.SubCategory.SubCategoryName,
                    SpicynessName = manuItem.Spicyness.SpicynessName
                };

                return View(manuItemViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return View();
            }
        }
        #endregion Details


    }
}
