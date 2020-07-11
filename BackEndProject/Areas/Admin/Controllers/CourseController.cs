using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BackEndProject.Helpers.Helper;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<User> _userManager;
        private readonly string _userId;
        public CourseController(AppDbContext db, IHostingEnvironment env,UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _env = env;
            _userManager = userManager;
            _userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.FindByIdAsync(_userId);
            if (user.isDeleted == false && (await _userManager.GetRolesAsync(user))[0] == "Moderator") 
            {
                CourseUserVM courseVM = new CourseUserVM
                {
                    Course = _db.Courses.Where(p => p.Id == user.CourseID),
                    User = user,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                };
                return View(courseVM);
            }
            return View(new CourseUserVM {
                Course = _db.Courses.OrderByDescending(p=>p.Id),
                User = user,
                Role = (await _userManager.GetRolesAsync(user))[0]
            });
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
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> Create(BackEndProject.Areas.Admin.ViewModels.CourseVM courseVM)
        {
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

        [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            BackEndProject.Areas.Admin.ViewModels.CourseVM courseVM = new ViewModels.CourseVM
            {
                Course = course,
                CourseDetail = _db.CourseDetails.FirstOrDefault(p=>p.Id == course.CourseDetailId),
                CourseFeature = _db.CourseFeatures.FirstOrDefault(p=>p.Id == course.CourseFeatureId),
                
            };
            return View(courseVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id,ViewModels.CourseVM courseVM)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();

            if (courseVM.Course.Photo != null) 
            {
                course.Image = await courseVM.Course.Photo.SaveImg(_env.WebRootPath, "img/course");
            }

            CourseDetail detail = courseVM.CourseDetail;
            CourseFeature feature = courseVM.CourseFeature;
            course.CourseDetail = detail;
            course.CourseFeature = feature;
            course = courseVM.Course;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
