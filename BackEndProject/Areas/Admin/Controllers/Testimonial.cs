using System;
using System.Collections.Generic;
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
    public class Testimonial : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public Testimonial(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Testimonials);
        }
        public IActionResult Create() 
        {
            return View(new Models.Testimonial());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreateTestimonial(Models.Testimonial _testimonial)
        {
            Models.Testimonial testimonial = new Models.Testimonial
            {
                Name = _testimonial.Name,
                Speciality = _testimonial.Speciality,
                Description = _testimonial.Description,
                Image = await _testimonial.Photo.SaveImg(_env.WebRootPath,"img/testimonial")
            };

            _db.Testimonials.Add(testimonial);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
