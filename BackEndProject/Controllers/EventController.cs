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
    public class EventController : Controller
    {
        private readonly AppDbContext _db;

        public EventController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            EventVM eventVM = new EventVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Event = _db.Events.OrderByDescending(p=>p.Id).Take(6),
                Speakers = _db.Speakers,
                EventSpeakers = _db.EventSpeakers,
                Blogs = _db.Blogs.OrderByDescending(p=>p.Id).Take(3)
            };
            return View(eventVM);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Event _event = await _db.Events.FindAsync(id);
            if (_event == null) return NotFound();
            List<EventSpeaker> eventspeakers = _db.EventSpeakers.Where(p => p.EventId == id).ToList();
            List<Speaker> speakers = new List<Speaker>();
            foreach (EventSpeaker event_speaker in eventspeakers) {

                speakers.Add(_db.Speakers.FirstOrDefault(p => p.Id == event_speaker.SpeakerId));
            }
            EventDetailVM detailVM = new EventDetailVM
            {
                Background = _db.Backgrounds.FirstOrDefault(),
                Blogs = _db.Blogs.OrderByDescending(p=>p.Id).Take(5),
                Courses = _db.Courses.Take(3),
                Event = _event,
                Speakers = speakers
            };

            return View(detailVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(EventDetailVM detailVM) 
        {
            Reply reply = new Reply
            {
                Name = detailVM.Reply.Name,
                Email = detailVM.Reply.Email,
                Subject = detailVM.Reply.Subject,
                Message = detailVM.Reply.Message
            };

            _db.Replies.Add(reply);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Detail));
        }
        public IActionResult Search(string key)
        {
            var model = _db.Events.Where(b => b.Header.Contains(key)).Select(b => new Event
            {
                Id = b.Id,
                Header = b.Header
            }).Take(8);
            return PartialView("_EventSearch", model);
        }
    }
}
