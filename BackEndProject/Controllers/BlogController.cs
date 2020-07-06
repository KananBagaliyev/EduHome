using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? page)
        {
            BlogVM blogVM = new BlogVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Blogs = _db.Blogs.OrderByDescending(p=>p.Id).Take(4),
                Events = _db.Events.OrderByDescending(p=>p.Id).Take(3)
            };

            ViewBag.PageCount = Math.Ceiling((decimal)_db.Blogs.Count() / 4);
            ViewBag.Page = page;
            return View(blogVM);
        }
    }
}
