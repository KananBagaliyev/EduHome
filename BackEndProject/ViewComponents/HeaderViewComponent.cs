using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public HeaderViewComponent(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {
            if (User.Identity.IsAuthenticated) 
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Fullname = user.Fullname;
            }

            HeaderFooterVM headerVM = new HeaderFooterVM
            {
                Data = _db.Data.FirstOrDefault(),
                CenterPhoneNumbers = _db.CenterPhoneNumbers
            };
            

            return View(await Task.FromResult(headerVM));
        }
    }
}
