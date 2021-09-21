using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spice.Areas.Admin.ViewModels.SubCategory;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryRepository subCategoryRepository;
        private readonly AppDbContext _context;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository, AppDbContext context)
        {
            this.subCategoryRepository = subCategoryRepository;
            _context = context;
        }

        #region SubCategoryList
        public IActionResult Index()
        {
            try
            {
                var model = subCategoryRepository.GetAllSubCategories();
                if (model == null)
                {
                    ViewBag.NoData = "No have any Data";
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worng" + ex.Message;   //Here show exception message only for develop time
            }
            return View();
        }
        #endregion SubCategoryList

        #region AddSubCategory
        public IActionResult Create()
        {
            var cfm = new CommonFillMethod(_context);
            ViewBag.CategoryList = cfm.FillDropDownListCategoryID();
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubCategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubCategory subCategory = new SubCategory
                    {
                        CategoryID = model.CategoryID,
                        SubCategoryName = model.SubCategoryName
                    };
                    subCategoryRepository.AddSubCategory(subCategory);
                    ModelState.Clear();

                    var cfm = new CommonFillMethod(_context);
                    ViewBag.CategoryList = cfm.FillDropDownListCategoryID();

                    ViewBag.Success = "Sub Category Inserted Successfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worang" + ex.Message;
            }
            return View();
        }
        #endregion AddSubCategory

        #region EditSubCategory
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                SubCategory subCategory = subCategoryRepository.GetSubCategoryByID(id);

                if (subCategory == null)
                {
                    return View("NotFound");
                }

                var cfm = new CommonFillMethod(_context);
                ViewBag.CategoryList = cfm.FillDropDownListCategoryID();

                SubCategoryViewModel SubCategoryViewModel = new SubCategoryViewModel
                {
                    SubCategoryID = subCategory.SubCategoryID,
                    CategoryID = subCategory.CategoryID,
                    SubCategoryName = subCategory.SubCategoryName
                };

                return View(SubCategoryViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Something was Worng" + ex.Message;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(SubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SubCategory subCategory = subCategoryRepository.GetSubCategoryByID(model.SubCategoryID);
                    subCategory.CategoryID = model.CategoryID;
                    subCategory.SubCategoryName = model.SubCategoryName;

                    subCategoryRepository.EditSubCategory(subCategory);

                    var cfm = new CommonFillMethod(_context);
                    ViewBag.CategoryList = cfm.FillDropDownListCategoryID();

                    return RedirectToAction("", "SubCategory", new { area = "Admin" });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Somthing was Worang" + ex.Message;
                }
            }
            return View();
        }
        #endregion EditSubCategory

        #region DeleteSubCategory
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = subCategoryRepository.DeleteSubCategory(id);
                    if (result)
                    {
                        return RedirectToAction("", "SubCategory", new { area = "Admin" });
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return View();
            }
        }
        #endregion DeleteSubCategory

        #region DetailsCategory
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                SubCategory subCategory = subCategoryRepository.GetSubCategoryByID(id);

                if (subCategory == null)
                {
                    return View("NotFound");
                }

                SubCategoryViewModel subCategoryViewModel = new SubCategoryViewModel
                {
                    CategoryID = subCategory.Category.CategoryID,
                    CategoryName = subCategory.Category.CategoryName,
                    SubCategoryName = subCategory.SubCategoryName
                };

                return View(subCategoryViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return View();
            }
        }
        #endregion DetailsCategory

        #region SubCategoryList
        [HttpGet]
        public JsonResult SubCategoryList(int categotyId)
        {
            var subCategory = _context.SubCategories.Where(cat => cat.CategoryID == categotyId).Where(subCat => subCat.IsDelete == false).ToList();
            return Json(subCategory);
        }
        #endregion SubCategoryList

        //#region CategoryDropDownList
        //private List<Category> CategoryDropDownList()
        //{
        //    List<Category> listCategory = new List<Category>();
        //    listCategory = (from category in _context.Categories select category).Where(cat => cat.IsDelete == false).ToList();
        //    return listCategory;
        //}
        //#endregion CategoryDropDownList
    }
}
