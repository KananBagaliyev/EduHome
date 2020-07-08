using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public CourseController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {

            return View(_db.Courses.OrderByDescending(p=>p.Id));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            CourseDetailVM detailVM = new CourseDetailVM
            {
                   Course = course,
                   CourseDetails = _db.CourseDetails.Where(p=>p.Id == course.CourseDetailId),
                   CourseFeatures = _db.CourseFeatures.Where(p=>p.Id == course.CourseFeatureId)
            };
            return View(detailVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> Create(BackEndProject.Areas.Admin.ViewModels.CourseVM courseVM)
        {
            //if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            //{
            //    return View();
            //}
            if (! courseVM.Course.Photo.isImage()) {
                ModelState.AddModelError(string.Empty, "Choose photo");
                return View();
            }

            CourseFeature feature = courseVM.CourseFeature;
            CourseDetail detail = courseVM.CourseDetail;
            Course course = courseVM.Course;
            course.CourseFeature = feature;
            course.CourseDetail = detail;
            course.Image = await courseVM.Course.Photo.SaveImg(_env.WebRootPath, "img/course");

            _db.Courses.Add(course);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            CourseDetailVM detailVM = new CourseDetailVM
            {
                Course = course,
                CourseDetails = _db.CourseDetails.Where(p => p.Id == course.CourseDetailId),
                CourseFeatures = _db.CourseFeatures.Where(p => p.Id == course.CourseFeatureId)
            };
            return View(detailVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCourse(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            //string filePath = Path.Combine(_env.WebRootPath, "img/course", course.Image);
            //if (System.IO.File.Exists(filePath))
            //{
            //    System.IO.File.Delete(filePath);
            //}
            Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/course", course.Image);
            _db.Courses.Remove(course);
            _db.CourseDetails.Remove(_db.CourseDetails.FirstOrDefault(p => p.Id == course.CourseDetailId));
            _db.CourseFeatures.Remove(_db.CourseFeatures.FirstOrDefault(p => p.Id == course.CourseFeatureId));
            
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
