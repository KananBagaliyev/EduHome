using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                Course = _db.Courses.OrderByDescending(p=>p.Id).Take(9),
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
                Teachers = _db.Teachers.Take(3),
                Blogs = _db.Blogs.OrderByDescending(p=>p.Id).Take(5),
                CourseFeatures = _db.CourseFeatures
            };
            return View(detailVM);
        }
        public IActionResult Search(string key)
        {
            var model = _db.Courses.Where(b => b.Name.Contains(key)).Select(b => new Course
            {
                Id = b.Id,
                Name = b.Name
            }).Take(8);
            return PartialView("_CourseSearch", model);
        }
        public IActionResult Filter(string search)
        {
            if (search == null)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Course> courses;
            bool check = _db.Courses.Any(c => c.Name.Contains(search));
            if (check)
            {
                courses = _db.Courses.Where(c => c.Name.Contains(search)).Include(c=>c.CourseDetail).Take(9);
            }
            else
            {
                courses = null;
            }
            CourseVM model = new CourseVM()
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Course = courses
            };

            return View(model);
        }
    }
}
