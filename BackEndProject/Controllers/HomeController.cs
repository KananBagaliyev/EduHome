using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = _db.Sliders,
                AboutSlider = _db.AboutSliders.FirstOrDefault(),
                Services = _db.Services,
                AboutUs = _db.AboutUs.FirstOrDefault(),
                Courses = _db.Courses.OrderByDescending(p=>p.Id).Take(3),
                CourseDetails = _db.CourseDetails,
                NoticeVideo = _db.NoticeVideos.FirstOrDefault(),
                NoticeBoards = _db.NoticeBoards.OrderByDescending(p=>p.Id),
                Events = _db.Events.OrderByDescending(p=>p.Id).Take(4),
                Testimonials = _db.Testimonials,
                Blogs = _db.Blogs.OrderByDescending(p=>p.Id).Take(3)
                
            };
            return View(homeVM);
        }
    }
}
