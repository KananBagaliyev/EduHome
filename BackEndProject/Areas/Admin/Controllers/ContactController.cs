using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public ContactController(AppDbContext db,IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Data.FirstOrDefault());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Data data = await _db.Data.FindAsync(id);
            if (data == null) return NotFound();

            ContactVM contactVM = new ContactVM
            {
                Data = data,
                Numbers = _db.CenterPhoneNumbers.Where(p => p.DataId == data.Id)
            };

            return View(contactVM);
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null) return NotFound();
            Data data = await _db.Data.FindAsync(id);
            if (data == null) return NotFound();
            TempData["Numbers"] = "";

            ContactVM contactVM = new ContactVM
            {
                Data = data,
                Numbers = _db.CenterPhoneNumbers.Where(p => p.DataId == data.Id),
                AllNumbers = _db.CenterPhoneNumbers.ToList()
            };
            return View(contactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditData(int? id,ContactVM _contactVM,IFormFile File)
        {
            if (id == null) return NotFound();
            Data data = await _db.Data.FindAsync(id);
            if (data == null) return NotFound();

            //ContactVM contactVM = new ContactVM
            //{
            //    Data = data,
            //    Numbers = _db.CenterPhoneNumbers.Where(p => p.DataId == data.Id),
            //    AllNumbers = _db.CenterPhoneNumbers.ToList()
            //};

            string numbers = Request.Form["numbers"];
            List<int> phone_id = new List<int>();
            if (numbers != null) 
            {
                string[] phone = numbers.Split(',');
                foreach(var item in phone) 
                {
                    phone_id.Add(Int32.Parse(item));
                }
                foreach (var item in _db.CenterPhoneNumbers.Where(p => p.DataId == data.Id).ToList()) 
                {
                    item.DataId = null;
                }
                foreach (var item in phone_id) 
                {
                    _db.CenterPhoneNumbers.FirstOrDefault(p => p.Id == item).DataId = data.Id;
                }
            }
            if (File != null) 
            {
                Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/logo", data.Logo);
                data.Logo = await File.SaveImg(_env.WebRootPath, "img/logo");
            }

            data.Location = _contactVM.Data.Location;
            data.Mail = _contactVM.Data.Mail;
            data.Web = _contactVM.Data.Web;
            data.Facebook = _contactVM.Data.Facebook;
            data.Pinterest = _contactVM.Data.Pinterest;
            data.Vimeo = _contactVM.Data.Vimeo;
            data.Twitter = _contactVM.Data.Twitter;
            if (data.Facebook == null)
            {
                data.Facebook = "https://www.facebook.com/";
            }
            if (data.Pinterest == null)
            {
                data.Pinterest = "https://www.pinterest.com/";
            }
            if (data.Vimeo == null)
            {
                data.Vimeo = "https://vimeo.com/";
            }
            if (data.Twitter == null)
            {
                data.Twitter = "https://twitter.com/explore";
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
