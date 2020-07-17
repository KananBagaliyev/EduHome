using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BackEndProject.Helpers.Helper;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public BlogController(AppDbContext db,IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Blogs.OrderByDescending(p=>p.Id));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            return View(blog);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(BackEndProject.Areas.Admin.ViewModels.BlogCreateVM blogVM) 
        {
            if (!ModelState.IsValid) 
            {
                return View(blogVM);
            }
            if (!blogVM.Photo.isImage()) 
            {
                ModelState.AddModelError(string.Empty, "Choose Photo");
                return View(blogVM);
            }
            Blog blog = new Blog
            {
                Image = await blogVM.Photo.SaveImg(_env.WebRootPath, "img/blog"),
                Header = blogVM.Header,
                Publisher = blogVM.Publisher,
                Date = blogVM.Date,
                Content = blogVM.Content
            };
            
            _db.Blogs.Add(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) return NotFound();
            Blog blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            ViewModels.BlogEditVM blogVM = new ViewModels.BlogEditVM
            {
                Image = blog.Image,
                Header = blog.Header,
                Publisher = blog.Publisher,
                Date = blog.Date,
                Content = blog.Content
            };
            return View(blogVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id,BackEndProject.Areas.Admin.ViewModels.BlogEditVM blogVM,IFormFile File)
        {
            if (id == null) return NotFound();
            Blog blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            blogVM.Image = blog.Image;
            if (!ModelState.IsValid) 
            {
                return View(blogVM);
            }

            if (File != null) 
            {
                if (!File.isImage())
                {
                    ModelState.AddModelError(string.Empty, "Chose photo type");
                    return View(blogVM);
                }
                Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/blog", blog.Image);
                blog.Image = await File.SaveImg(_env.WebRootPath, "img/blog");
            }
           
            blog.Header = blogVM.Header;
            blog.Publisher = blogVM.Publisher;
            blog.Date = blogVM.Date;
            blog.Content = blogVM.Content;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            Helpers.Helper.DeleteIMG(_env.WebRootPath,"img/blog" ,blog.Image);
            _db.Blogs.Remove(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string key)
        {
            if (key == null) key = "";
            var blog = _db.Blogs.OrderByDescending(p => p.Id).ToList();

            if (key.Length > 0 || key == "")
            {
                blog = _db.Blogs.Where(c => c.Header.Contains(key)).OrderByDescending(p => p.Id).ToList();
            }
            return PartialView("_BlogSearch", blog);
        }


    }
}
