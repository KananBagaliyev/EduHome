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
    public class SubscriberController : Controller
    {

        private readonly AppDbContext _db;
        public SubscriberController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> Subscriber(HeaderFooterVM detailVM)
        {
            bool exists = _db.Subscribers.Any(s => s.Mail == detailVM.Subscriber.Mail);
            if (exists) 
            {
                return RedirectToAction(nameof(Error));
            }
            Subscriber sub = new Subscriber
            {
                Mail = detailVM.Subscriber.Mail
            };
            _db.Subscribers.Add(sub);
            await _db.SaveChangesAsync();
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
