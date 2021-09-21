using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spice.Areas.Admin.ViewModels.Category;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #region CategoryList
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var model = categoryRepository.GetAllCategory();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worng" + ex.Message;   //Here show exception message only for develop time
            }
            return View();
        }
        #endregion CategoryList

        #region AddCategory
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = new Category
                    {
                        CategoryName = model.CategoryName
                    };
                    categoryRepository.AddCategory(category);
                    ModelState.Clear();

                    ViewBag.Success = "Category Inserted Successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Somthing was Worang" + ex.Message;
                }
            }
            return View();
        }
        #endregion AddCategory

        #region EditCategory
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Category category = categoryRepository.GetCategoryByID(id);

                if (category == null)
                {
                    return View("NotFound");
                }

                CategoryViewModel categoryViewModel = new CategoryViewModel
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                };

                return View(categoryViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Something was Worng" + ex.Message;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = categoryRepository.GetCategoryByID(model.CategoryID);
                    category.CategoryName = model.CategoryName;

                    categoryRepository.EditCategory(category);

                    return RedirectToAction("", "Category", new { area = "Admin" });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Somthing was Worang" + ex.Message;
                }
            }
            return View();
        }
        #endregion EditCategory

        #region DeleteCategory
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = categoryRepository.DeleteCategory(id);
                    if (result)
                    {
                        return RedirectToAction("", "Category", new { area = "Admin" });
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
        #endregion DeleteCategory

        #region DetailsCategory
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                Category category = categoryRepository.GetCategoryByID(id);

                if (category == null)
                {
                    return View("NotFound");
                }

                CategoryViewModel categoryViewModel = new CategoryViewModel
                {
                    CategoryName = category.CategoryName
                };

                return View(categoryViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return View();
            }
        }
        #endregion DetailsCategory

    }
}
