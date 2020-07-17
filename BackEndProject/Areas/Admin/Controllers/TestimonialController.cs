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
    [Authorize(Roles = "Admin")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public TestimonialController(AppDbContext db, IHostingEnvironment env)
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

            if (!_testimonial.Photo.isImage())
            {
                ModelState.AddModelError(string.Empty, "Chose Photo");
                return View(_testimonial);
            }
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
        public async Task<IActionResult> Detail(int? id) 
        {
            if (id == null) return NotFound();
            Models.Testimonial testimonial = await _db.Testimonials.FindAsync(id);
            if (testimonial == null) return NotFound();

            return View(testimonial);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            Models.Testimonial testimonial = await _db.Testimonials.FindAsync(id);
            if (testimonial == null) return NotFound();

            return View(testimonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditTestimonial(int? id,Models.Testimonial _testimonial,IFormFile File)
        {
            if (id == null) return NotFound();
            Models.Testimonial testimonial = await _db.Testimonials.FindAsync(id);
            if (testimonial == null) return NotFound();

            if (File != null) 
            {
                if (!File.isImage()) 
                {
                    ModelState.AddModelError(string.Empty, "Chose Photo");
                    return View(_testimonial);
                }
                Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/testimonial", testimonial.Image);
                testimonial.Image = await File.SaveImg(_env.WebRootPath, "img/testimonial");
            }

            testimonial.Name = _testimonial.Name;
            testimonial.Speciality = _testimonial.Speciality;
            testimonial.Description = _testimonial.Description;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (_db.Testimonials.Count() <= 1) return NotFound();
            if (id == null) return NotFound();
            Models.Testimonial testimonial = await _db.Testimonials.FindAsync(id);
            if (testimonial == null) return NotFound();

            return View(testimonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteTestimonial(int? id)
        {
            if (_db.Testimonials.Count() <= 1) return NotFound();
            if (id == null) return NotFound();
            Models.Testimonial testimonial = await _db.Testimonials.FindAsync(id);
            if (testimonial == null) return NotFound();

            _db.Testimonials.Remove(testimonial);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
