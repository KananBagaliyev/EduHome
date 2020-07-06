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
                Event = _event,
                Speakers = speakers
            };

            return View(detailVM);
        }
    }
}
