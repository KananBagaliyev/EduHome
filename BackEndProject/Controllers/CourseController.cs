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
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            CourseVM courseVM = new CourseVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Course = _db.Courses.Take(9),
                CourseDetails = _db.CourseDetails,
                CourseFeatures = _db.CourseFeatures

            };
            return View(courseVM);
        }
        public async Task<IActionResult> Detail(int? id) {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            CourseDetailVM detailVM = new CourseDetailVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Course = course,
                CourseDetails = _db.CourseDetails,
                CourseFeatures = _db.CourseFeatures
            };
            return View(detailVM);
        }
    }
}
