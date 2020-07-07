using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db)
        {
            _db = db;
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
            CourseFeature feature = courseVM.CourseFeature;
            CourseDetail detail = courseVM.CourseDetail;
            Course course = courseVM.Course;
            course.CourseFeature = feature;
            course.CourseDetail = detail;
            course.Image = "course1";

            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return Content("Ok");
        }
    }
}
