using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                AboutUs = _db.AboutUs.FirstOrDefault(),
                Teachers = _db.Teachers.Take(4),
                AboutTeachers = _db.AboutTeachers,
                Testimonials = _db.Testimonials,
                NoticeVideo = _db.NoticeVideos.FirstOrDefault(),
                NoticeBoards = _db.NoticeBoards.OrderByDescending(p=>p.Id)
            };
            return View(aboutVM);
        }
    }
}
