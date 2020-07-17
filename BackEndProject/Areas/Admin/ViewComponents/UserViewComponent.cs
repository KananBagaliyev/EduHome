using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
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
        private readonly AppDbContext _db;

        public UserViewComponent(UserManager<User> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            if (User.Identity.IsAuthenticated) 
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Fullname = user.Fullname;
                TempData["User"] = (await _userManager.GetRolesAsync(user))[0];
            }

            ReplySubscriberVM navVM = new ReplySubscriberVM
            {
                Reply = _db.Replies.OrderByDescending(p=>p.Id).Take(3),
                Subscriber = _db.Subscribers.OrderByDescending(p=>p.Id).Take(3)
            };

            return View(navVM);
        }
    }
}
