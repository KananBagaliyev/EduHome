using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEndProject.Controllers
{
    public class ContactController : Controller
    {
        public readonly AppDbContext _db;

        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            DataVM dataVM = new DataVM
            {
                Data = _db.Data.FirstOrDefault(),
                Phone = _db.CenterPhoneNumbers.Where(p=>p.DataId == _db.Data.FirstOrDefault().Id)
            };
            return View(dataVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(DataVM dataVM)
        {
            dataVM.Data = _db.Data.FirstOrDefault();
            dataVM.Phone = _db.CenterPhoneNumbers.Where(p => p.DataId == _db.Data.FirstOrDefault().Id);
            if (!ModelState.IsValid) 
            {
                return View();
            }
            Reply reply = new Reply 
            {
                Name = dataVM.Reply.Name,
                Email = dataVM.Reply.Email,
                Subject = dataVM.Reply.Subject,
                Message = dataVM.Reply.Message
            };

            _db.Replies.Add(reply);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
