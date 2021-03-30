using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using eCommerce_Model;

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
            if (ModelState.IsValid)
            {
                if (productMasterModel.ProductID != null)
                {
                    string strFilePath = "~/Content/Img/";
                    productMasterModel.ProductImage = strFilePath + productMasterModel.ProductImage;
                    productMasterDAL.Update(productMasterModel);
                    return RedirectToAction("ProductList");
                }
                else
                {
                    //if (file.ContentLength > 0)
                    //{
                    //    string fileExt = System.IO.Path.GetExtension(file.FileName);

                    //    if (fileExt.ToLower() == ".jpeg" || fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".png")
                    //    {
                    //        string strFilePath = "~/Content/ProductImage/";
                    //        file.SaveAs(Server.MapPath(strFilePath + file.FileName));
                    //        productMasterModel.ProductImage = Convert.ToString(strFilePath + file.FileName);
                    //    }
                    //}
                    string strFilePath = "~/Content/Img/";
                    productMasterModel.ProductImage = strFilePath + productMasterModel.ProductImage;
                    productMasterDAL.Insert(productMasterModel);
                    ViewBag.InsertMessage = "Data Inserted Successfully...";
                }
                ModelState.Clear();
            }
            return View("Create");
        }
        #endregion Create

        #region ProductList
        public ActionResult ProductList()
        {
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

        #region Home
        public ActionResult ProductDetils(int id)
        {
            ProductMasterDAL productMasterDAL = new ProductMasterDAL();
            var productDetails = productMasterDAL.ProductMasterShowDetailsByPK(id);
            return View(productDetails);
        }
        #endregion Home
    }
}