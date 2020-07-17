using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SubscriberController : Controller
    {
        private readonly AppDbContext _db;
        public SubscriberController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Subscribers.OrderByDescending(p=>p.Id));
        }

        public async Task<IActionResult> Seen(int? id) 
        {
            if (id == null) return NotFound();
            Subscriber sub = await _db.Subscribers.FindAsync(id);
            if (sub == null) return NotFound();

            sub.isActivated = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AllRead(string value)
        {
            int[] values = JsonConvert.DeserializeObject<int[]>(value);

            foreach (int val in values)
            {
                _db.Subscribers.FirstOrDefault(r => r.Id == val).isActivated = true;
            }
            await _db.SaveChangesAsync();
            IEnumerable<Models.Subscriber> model = _db.Subscribers.OrderByDescending(r => r.Id).ToList();
            return PartialView("_Subscriber", model);
        }

        public async Task<IActionResult> AllDelete(string value)
        {
            int[] values = JsonConvert.DeserializeObject<int[]>(value);

            foreach (int val in values)
            {
                _db.Subscribers.Remove(_db.Subscribers.FirstOrDefault(r => r.Id == val));
            }
            await _db.SaveChangesAsync();
            IEnumerable<Models.Subscriber> model = _db.Subscribers.OrderByDescending(r => r.Id).ToList();
            return PartialView("_Subscriber", model);
        }

        public async Task<IActionResult> DeleteOne(int? key)
        {
            if (key == null) return NotFound();
            _db.Subscribers.Remove(_db.Subscribers.FirstOrDefault(r => r.Id == key));
            await _db.SaveChangesAsync();
            IEnumerable<Models.Subscriber> model = _db.Subscribers.OrderByDescending(r => r.Id).ToList();
            return PartialView("_Subscriber", model);
        }
        public async Task<IActionResult> Search(string key)
        {
            if (key == null) key = "";
            var sub = _db.Subscribers.OrderByDescending(p => p.Id).ToList();

            if (key.Length > 0 || key == "")
            {
                sub = _db.Subscribers.Where(c => c.Mail.Contains(key)).OrderByDescending(p => p.Id).ToList();
            }
            return PartialView("_SubSearch", sub);
        }
    }
}
