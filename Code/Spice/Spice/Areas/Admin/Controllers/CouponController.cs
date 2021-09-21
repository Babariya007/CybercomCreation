using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spice.Areas.Admin.ViewModels.Coupon;
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
    public class CouponController : Controller
    {
        private readonly ICouponRepository couponRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public AppDbContext _context { get; }

        public CouponController(ICouponRepository couponRepository, AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            this.couponRepository = couponRepository;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region CouponList
        public IActionResult Index()
        {
            try
            {
                var model = couponRepository.GetAllCoupon();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worng" + ex.Message;   //Here show ex.Message exception message only for develop time
            }
            return View();
        }
        #endregion CouponList

        #region AddCoupon
        public IActionResult Create()
        {
            ViewBag.CouponType = CouponTypeDropDownList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CouponViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = UploadImage(model);

                    Coupon coupon = new Coupon
                    {
                        Name = model.Name,
                        Picture = uniqueFileName,
                        CouponTypeID = model.CouponTypeID,
                        Discount = model.CouponTypeID,
                        MinimumAmount = model.MinimumAmount,
                        IsActive = model.IsActive
                };
                    couponRepository.AddCoupon(coupon);
                    ModelState.Clear();

                    ViewBag.CouponType = CouponTypeDropDownList();

                    ViewBag.Success = "Coupon Inserted Successfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worang" + ex.Message;
            }
            return View();
        }
        #endregion AddCoupon

        #region EditCoupon
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Coupon coupon = couponRepository.GetCouponByID(id);

                if (coupon == null)
                {
                    return View("NotFound");
                }

                ViewBag.CouponType = CouponTypeDropDownList();

                CouponViewModel couponViewModel = new CouponViewModel
                {
                    CouponID = coupon.CouponID,
                    Name = coupon.Name,
                    ExsistingPhoto = coupon.Picture,
                    CouponTypeID = coupon.CouponTypeID,
                    Discount = coupon.Discount,
                    MinimumAmount = coupon.MinimumAmount,
                    IsActive = coupon.IsActive
                };

                return View(couponViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Something was Worng" + ex.Message;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(CouponViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Coupon coupon = couponRepository.GetCouponByID(model.CouponID);
                    coupon.Name = model.Name;
                    coupon.CouponTypeID = model.CouponTypeID;
                    coupon.Discount = model.Discount;
                    coupon.MinimumAmount = model.MinimumAmount;
                    coupon.IsActive = model.IsActive;

                    if (model.Picture != null)
                    {
                        if (model.ExsistingPhoto != null)
                        {
                            Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExsistingPhoto);
                        }
                        coupon.Picture = UploadImage(model);
                    }

                    couponRepository.EditCoupon(coupon);

                    ViewBag.CouponType = CouponTypeDropDownList();

                    return RedirectToAction("", "Coupon", new { area = "Admin" });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Somthing was Worang" + ex.Message;
                }
            }
            return View();
        }
        #endregion EditCoupon

        #region DeleteCoupon
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = couponRepository.DeleteCoupon(id);
                    if (result)
                    {
                        return RedirectToAction("", "Coupon", new { area = "Admin" });
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
        #endregion DeleteCoupon

        #region DetailsCoupon
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                Coupon coupon = couponRepository.GetCouponByID(id);

                if (coupon == null)
                {
                    return View("NotFound");
                }

                CouponViewModel couponViewModel = new CouponViewModel
                {
                    Name = coupon.Name,
                    ExsistingPhoto = coupon.Picture,
                    CouponTypeID = coupon.CouponTypeID,
                    CouponTypeName = coupon.CouponType.CouponTypeName,
                    Discount = coupon.Discount,
                    MinimumAmount = coupon.MinimumAmount,
                    IsActive = coupon.IsActive
                };

                return View(couponViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return View();
            }
        }
        #endregion DetailsCoupon

        #region CouponTypeDropDownList
        private List<CouponType> CouponTypeDropDownList()
        {
            List<CouponType> listCouponType = new List<CouponType>();
            listCouponType = (from couponType in _context.CouponTypes select couponType).ToList();
            return listCouponType;
        }
        #endregion CouponTypeDropDownList

        #region UploadImage
        private string UploadImage(CouponViewModel model)
        {
            string uniqueFileName = null;

            if (model.Picture != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Picture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        #endregion UploadImage
    }
}
