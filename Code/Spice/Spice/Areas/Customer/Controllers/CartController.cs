using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spice.Areas.Customer.ViewModels.Cart;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(ICartRepository cartRepository, UserManager<ApplicationUser> userManager)
        {
            this.cartRepository = cartRepository;
            this.userManager = userManager;
        }

        #region CartList
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                var model = cartRepository.GetCartList(userId);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Somthing was Worng" + ex.Message;   //Here show exception message only for develop time
            }
            return View();
        }
        #endregion CartList

        #region AddOrUpdateCart
        [HttpPost]
        public IActionResult AddCart(CartViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var itemInCart = cartRepository.GetManuIdByUserInCart(model.ManuItemID, userManager.GetUserId(User));

                    if (itemInCart == null)
                    {
                        Cart cart = new Cart
                        {
                            ManuItemID = model.ManuItemID,
                            Quantity = model.Quantity,
                            Id = userManager.GetUserId(User)
                        };

                        cartRepository.AddItemInCart(cart);
                    }
                    else
                    {
                        var quantity = itemInCart.Quantity + model.Quantity;

                        itemInCart.CartID = itemInCart.CartID;
                        itemInCart.ManuItemID = model.ManuItemID;
                        itemInCart.Quantity = quantity;
                        itemInCart.Id = userManager.GetUserId(User);

                        cartRepository.EditCart(itemInCart);
                    }

                    return RedirectToAction("Index", "Cart", new { area = "Customer" });
                    //return RedirectToAction("Details", new { Controller = "Home", area = "Customer", id = itemInCart.ManuItemID });
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Something was Worng" + ex.Message;
                return View();
            }
        }
        #endregion AddOrUpdateCart

        #region RemoveItemInCart
        public IActionResult DeleteCartItem(int id)
        {
            try
            {
                var cartId = cartRepository.GetByCartID(id);
                
                if(cartId == null)
                {
                    return RedirectToAction("NotFound");
                }

                cartRepository.DeleteCart(cartId.CartID);

                return RedirectToAction("Index","Cart", new { area = "Customer" });
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Something was Worng" + ex.Message;
                return View();
            }
        }
        #endregion RemoveItemInCart



    }
}
