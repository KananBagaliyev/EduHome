using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Models;
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
            ViewBag.PageCount = Math.Ceiling((decimal)_db.Blogs.Count() / 4);
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
            }

            return View(blogVM);

        }
        public async Task<IActionResult> Detail(int? id) {
            if (id == null) return NotFound();
            Blog blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            BlogDetailVM detailVM = new BlogDetailVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Courses = _db.Courses.Take(6),
                Events = _db.Events.OrderByDescending(p=>p.Id).Take(3),
                Blog = blog,
            };
            return View(detailVM);
        }
        public IActionResult Search(string key)
        {
            var model = _db.Blogs.Where(b => b.Header.Contains(key)).Select(b => new Blog
            {
                Id = b.Id,
                Header = b.Header
            }).Take(8);
            return PartialView("_BlogSearch", model);
        }
    }
}
