using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly ICartRepository cartRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public CartCountViewComponent(ICartRepository cartRepository, UserManager<ApplicationUser> userManager)
        {
            this.cartRepository = cartRepository;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userID = userManager.GetUserId(HttpContext.User);
            var cartItem = cartRepository.CoutCartItem(userID);
            ViewBag.CartItem = cartItem;
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
