using BackEndProject.DAL;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class BlogViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;

        public BlogViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? page) {

            BlogVM blogVM = new BlogVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Blogs = _db.Blogs.OrderByDescending(p => p.Id).Take(4),
                Events = _db.Events.OrderByDescending(p => p.Id).Take(3)
            };
            ViewBag.PageIndicator = 1;
            if (page != null)
            {
                ViewBag.PageIndicator = page;
                blogVM.Blogs = _db.Blogs.OrderByDescending(p => p.Id).Skip((int)(page - 1) * 4).Take(4);
            }

            ViewBag.PageCount = Math.Ceiling((decimal)_db.Blogs.Count() / 4);

            ViewBag.Page = page;
            return View(await Task.FromResult(blogVM));
        }
    }
}
