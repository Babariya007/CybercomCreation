using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spice.Areas.Admin.ViewModels.ManuItem;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManuItemController : Controller
    {
        private readonly IManuItemRepository manuItemRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public AppDbContext _context { get; }

        public ManuItemController(IManuItemRepository manuItemRepository, AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            this.manuItemRepository = manuItemRepository;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region ManuItemList
        public IActionResult Index()
        {
            try
            {
                var model = manuItemRepository.GetAllManuItem();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worng" + ex.Message;   //Here show ex.Message exception message only for develop time
            }
            return View();
        }
        #endregion ManuItemList

        #region AddManuItem
        public IActionResult Create()
        {
            ViewBag.CategoryList = CategoryDropDownList();
            ViewBag.SpicynessList = SpicynessDropDownList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ManuItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = UploadImage(model);

                    ManuItem manuItem = new ManuItem
                    {
                        Name = model.Name,
                        Decription = model.Decription,
                        Price = model.Price,
                        Image = uniqueFileName,
                        CategoryID = model.CategoryID,
                        SubCategoryID = model.SubCategoryID,
                        SpicynessID = model.SpicynessID,
                };
                    manuItemRepository.AddManuItem(manuItem);
                    ModelState.Clear();

                    ViewBag.CategoryList = CategoryDropDownList();
                    ViewBag.SpicynessList = SpicynessDropDownList();

                    ViewBag.Success = "Manu Item Inserted Successfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worang" + ex.Message;
            }
            return View();
        }
        #endregion AddManuItem

        #region EditManuItem
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                ManuItem manuItem = manuItemRepository.GetManuItemByID(id);

                if (manuItem == null)
                {
                    return View("NotFound");
                }

                ViewBag.CategoryList = CategoryDropDownList();
                ViewBag.SpicynessList = SpicynessDropDownList();

                ManuItemViewModel manuItemViewModel = new ManuItemViewModel
                {
                    ManuItemID = manuItem.ManuItemID,
                    Name = manuItem.Name,
                    Decription = manuItem.Decription,
                    Price = manuItem.Price,
                    ExsistingPhoto = manuItem.Image,
                    CategoryID = manuItem.CategoryID,
                    SubCategoryID = manuItem.SubCategoryID,
                    SpicynessID = manuItem.SpicynessID
                };

                return View(manuItemViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Something was Worng" + ex.Message;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(ManuItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ManuItem manuItem = manuItemRepository.GetManuItemByID(model.ManuItemID);
                    manuItem.ManuItemID = model.ManuItemID;
                    manuItem.Name = model.Name;
                    manuItem.Decription = model.Decription;
                    manuItem.Price = model.Price;
                    manuItem.CategoryID = model.CategoryID;
                    manuItem.SubCategoryID = model.SubCategoryID;
                    manuItem.SpicynessID = model.SpicynessID;

                    if (model.Image != null)
                    {
                        if(model.ExsistingPhoto != null)
                        {
                            Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExsistingPhoto);
                        }
                        manuItem.Image = UploadImage(model);
                    }

                    manuItemRepository.EditManuItem(manuItem);

                    ViewBag.CategoryList = CategoryDropDownList();

                    return RedirectToAction("", "ManuItem", new { area = "Admin" });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Somthing was Worang" + ex.Message;
                }
            }
            return View();
        }
        #endregion EditManuItem

        #region DeleteManuItem
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = manuItemRepository.DeleteManuItem(id);
                    if (result)
                    {
                        return RedirectToAction("", "ManuItem", new { area = "Admin" });
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
        #endregion DeleteManuItem

        #region DetailsManuItem
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
                    Name = manuItem.Name,
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
        #endregion DetailsManuItem

        #region DropDownList

        #region CategoryDropDownList
        private List<Category> CategoryDropDownList()
        {
            List<Category> listCategory = new List<Category>();
            listCategory = (from category in _context.Categories select category).Where(cat => cat.IsDelete == false).ToList();
            return listCategory;
        }
        #endregion 

        #region SubCategoryList
        [HttpGet]
        public JsonResult SubCategoryDropDownList(int categoryId)
        {
            var subCategory = _context.SubCategories.Where(cat => cat.CategoryID == categoryId && cat.IsDelete == false).ToList();
            return Json(subCategory);
        }
        #endregion SubCategoryList

        #region SpicynessDropDownList
        private List<Spicyness> SpicynessDropDownList()
        {
            List<Spicyness> listSpicyness = new List<Spicyness>();
            listSpicyness = (from spicyness in _context.Spicynesses select spicyness).ToList();
            return listSpicyness;
        }
        #endregion SpicynessDropDownList

        #endregion DropDownList

        #region UploadImage
        private string UploadImage(ManuItemViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        #endregion UploadImage
    }
}
