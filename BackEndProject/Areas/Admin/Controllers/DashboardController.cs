using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        public DashboardController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            ReplySubscriberVM VM = new ReplySubscriberVM
            {
                Reply = _db.Replies.Where(r => r.Checked == false),
                Subscriber = _db.Subscribers.Where(s => s.isActivated == false),
                Role = (await _userManager.GetRolesAsync(await _userManager.FindByNameAsync(User.Identity.Name)))[0]

            };
            return View(VM);
        }
    }
}
