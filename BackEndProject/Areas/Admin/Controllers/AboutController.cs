using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public AboutController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.AboutUs.FirstOrDefault());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            AboutUs about = await _db.AboutUs.FindAsync(id);
            if (about == null) return NotFound();
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id,AboutUs _about,IFormFile File )
        {
            if (id == null) return NotFound();
            AboutUs about = await _db.AboutUs.FindAsync(id);
            if (about == null) return NotFound();
            if (File != null) {
                about.Image = await File.SaveImg(_env.WebRootPath,"img/about");
            }
            about.Header = _about.Header;
            about.Content = _about.Content;
            about.ShortContent = _about.ShortContent;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
