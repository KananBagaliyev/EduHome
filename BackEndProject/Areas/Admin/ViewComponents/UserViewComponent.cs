using BackEndProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public UserViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            if (User.Identity.IsAuthenticated) 
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Fullname = user.Fullname;
                TempData["User"] = (await _userManager.GetRolesAsync(user))[0];
            }


            return View();
        }
    }
}
