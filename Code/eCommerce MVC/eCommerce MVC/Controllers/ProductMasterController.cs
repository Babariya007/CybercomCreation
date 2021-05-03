using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using eCommerce_Model;
using Newtonsoft.Json;
using PagedList;
using PagedList.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class ProductMasterController : Controller
    {
        ProductMasterDAL productMasterDAL = new ProductMasterDAL();

        #region Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.PageTitle = "Update Record";
                ViewBag.Title = "Update Product Details";
                ViewBag.Button = "Update";
                var product = productMasterDAL.SelectByPK(Convert.ToInt32(id));
                return View(product);
            }
            else
            {
                ViewBag.PageTitle = "Add New Record";
                ViewBag.Title = "Add New Product";
                ViewBag.Button = "Save";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductMasterModel productMasterModel)
        {
            if (productMasterModel.ProductID != null)
            {
                if (productMasterModel.ImageFile != null)
                {
                    string FilePath = "~/Content/Img/";
                    string filefullPath = Server.MapPath(FilePath + productMasterModel.ImageFile.FileName);
                    productMasterModel.ImageFile.SaveAs(filefullPath);
                    productMasterModel.ProductImage = Convert.ToString(FilePath + productMasterModel.ImageFile.FileName);
                }
                productMasterDAL.Update(productMasterModel);
                return RedirectToAction("ProductList");
            }
            else
            {
                string fileExt = System.IO.Path.GetExtension(productMasterModel.ImageFile.FileName);

                if (fileExt.ToLower() == ".jpeg" || fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".png")
                {
                    string FilePath = "~/Content/Img/";
                    string filefullPath = Server.MapPath(FilePath + productMasterModel.ImageFile.FileName);
                    productMasterModel.ImageFile.SaveAs(filefullPath);
                    productMasterModel.ProductImage = Convert.ToString(FilePath + productMasterModel.ImageFile.FileName);
                }
                productMasterDAL.Insert(productMasterModel);
                ViewBag.InsertMessage = "Data Inserted Successfully...";
            }
            ModelState.Clear();
            return View("Create");
        }
        #endregion Create

        #region ProductList
        public ActionResult ProductList()
        {
            //var draw = Request.Form.GetValues("draw");
            //var start = Request.Form.GetValues("start");
            //var length = Request.Form.GetValues("length");
            List<ProductMasterModel> product = productMasterDAL.SelectAll();
            ViewData["Product"] = product;

            return View();
        }
        #endregion ProductList

        #region Delete
        public ActionResult Delete(int id)
        {
            productMasterDAL.Delete(id);
            return RedirectToAction("ProductList");
        }
        #endregion Delete

        //----------------------------------------------------------------

        #region Home
        public ActionResult Home()
        {
            ProductMasterDAL productMasterDAL = new ProductMasterDAL();
            List<ProductMasterModel> showProductList = productMasterDAL.ShowProductSelectAll();
            ViewData["ShowProductList"] = showProductList;
            return View();
        }
        #endregion Home

        #region ProductDetils
        public ActionResult ProductDetils(int id)
        {
            var productDetails = productMasterDAL.ProductMasterShowDetailsByPK(id);
            CartDAL cartDAL = new CartDAL();
            ViewBag.Button = cartDAL.CheckItemInCart(id);
            return View(productDetails);
        }
        #endregion ProductDetils

        #region ProductOrderAddCart
        [HttpPost]
        public ActionResult AddToCart(CartModel cartModel)
        {
            CartDAL cartDAL = new CartDAL();
            cartDAL.ProductOrderAddCart(cartModel.ProductID);
            return RedirectToAction("ProductDetils", new { id = cartModel.ProductID });
        }
        #endregion ProductOrderAddCart

    }
}