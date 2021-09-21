using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice
{
    public class UserNameViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserNameViewComponent(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var name = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = name.Name;
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
