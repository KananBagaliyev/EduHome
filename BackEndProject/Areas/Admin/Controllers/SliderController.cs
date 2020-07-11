using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static BackEndProject.Helpers.Helper;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public SliderController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Sliders);
        }
        public IActionResult Create() 
        {
            Slider slider = new Slider();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(Slider slider )
        {
            Slider _slider = slider;
            if (!slider.Photo.isImage()) 
            {
                ModelState.AddModelError("Photo", "Choose photo");
                return View();
            }

            _slider.Image = await slider.Photo.SaveImg(_env.WebRootPath, "img/slider");
            _db.Sliders.Add(_slider);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id) 
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id, Slider _slider) 
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();


            if (!_slider.Photo.isImage()) 
            {
                ModelState.AddModelError("Photo", "Choose Photo");
                return View(_slider);
            }

            slider.Image = await _slider.Photo.SaveImg(_env.WebRootPath, "img/slider");
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (_db.Sliders.Count() <= 3) return NotFound();
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (_db.Sliders.Count() <= 3) return NotFound();
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/slider", slider.Image);
            _db.Sliders.Remove(slider);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }


}
