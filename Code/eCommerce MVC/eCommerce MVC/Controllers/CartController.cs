using DAL;
using eCommerce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class CartController : Controller
    {
        CartDAL cartDAL = new CartDAL();

        #region Cart
        public ActionResult Cart()
        {
            List<CartModel> cartItem = cartDAL.ItemInCart();
            if (cartItem.Count > 0)
            {
                ViewData["CartItem"] = cartItem;
            }
            else
            {
                ViewData["CartItem"] = null;
                ViewBag.NotInCart = "Item Not in Cart";
            }
            return View();
        }
        #endregion Cart

        #region Delete Cart Item
        public ActionResult Delete(int id)
        {
            cartDAL.Delete(id);
            return RedirectToAction("Cart");
        }
        #endregion Delete Cart Item

    }
}