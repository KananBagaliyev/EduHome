using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public EventController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Events.OrderByDescending(p=>p.Id));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Event _event = await _db.Events.FindAsync(id);
            if (_event == null) return NotFound();
            List<EventSpeaker> eventspeakers = _db.EventSpeakers.Where(p => p.EventId == id).ToList();
            List<Speaker> speakers = new List<Speaker>();
            foreach (EventSpeaker event_speaker in eventspeakers)
            {

                speakers.Add(_db.Speakers.FirstOrDefault(p => p.Id == event_speaker.SpeakerId));
            }
            EventDetailVM detailVM = new EventDetailVM
            {
                Event = _event,
                Speakers = speakers
            };
            return View(detailVM);
        }

        public IActionResult Create() 
        {
            //List<int> list = _db.Speakers.Select(p => p.Id).ToList();
            //List<string> listx = new List<string>();
            //foreach (var item in list) 
            //{
            //    listx.Add(item.ToString());
            //}
            //TempData["Speakers"] = listx;
            ViewBag.Speakers = _db.Speakers.ToList();
            EventDetailVM detailVM = new EventDetailVM
            {
                Speakers = _db.Speakers.ToList()
            };
            return View(detailVM);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(EventDetailVM eventVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(new EventDetailVM { Speakers = _db.Speakers.ToList() });
            //}
            //if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            //{
            //    return View();
            //}urn View(eventVM);
            //}
            string keys = Request.Form["speakers"];
            if (keys == null)
            {
                ModelState.AddModelError(string.Empty, "Choose at Least one speaker");
                return View(new EventDetailVM {Speakers = _db.Speakers.ToList() });
            }
            string[] _keys = keys.Split(',');
            List<int> ids = new List<int>();
            foreach (var item in _keys)
            {
                ids.Add(Int32.Parse(item));
            }
            if (!eventVM.Event.Photo.isImage())
            {
                ModelState.AddModelError(string.Empty, "Choose photo");
                return View(new EventDetailVM { Speakers = _db.Speakers.ToList() });
            }


            Event _event = eventVM.Event;
            //_event.Image = "event9.jpg";
            _event.Image = await eventVM.Event.Photo.SaveImg(_env.WebRootPath, "img/event");
            List<EventSpeaker> eSpeaker = new List<EventSpeaker>();

            foreach (int item in ids)
            {
                eSpeaker.Add(new EventSpeaker
                {
                    EventId = _event.Id,
                    SpeakerId = item
                });
            }

            _event.EventSpeakers = eSpeaker;

            _db.Events.Add(_event);
            await _db.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            Event _event = await _db.Events.FindAsync(id);
            if (_event == null) return NotFound();
            List<EventSpeaker> eSpeaker = _db.EventSpeakers.Where(p => p.EventId == _event.Id).ToList();
            List<Speaker> speakers = new List<Speaker>();
            foreach (var item in eSpeaker) 
            {
                speakers.Add(_db.Speakers.FirstOrDefault(p => p.Id == item.SpeakerId));
            }
            ViewBag.Speakers = "";

            BackEndProject.Areas.Admin.ViewModels.EventVM detailVM = new ViewModels.EventVM
            {
                Event = _event,
                AllSpeakers = _db.Speakers.ToList(),
                Speakers = speakers
            };
            return View(detailVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id, ViewModels.EventVM eventVM)
        {
            if (id == null) return NotFound();
            Event _event = await _db.Events.FindAsync(id);
            if (_event == null) return NotFound();

            List<EventSpeaker> event_speaker = _db.EventSpeakers.Where(p => p.EventId == _event.Id).ToList();
            List<EventSpeaker> current_EventSpeaker = _db.EventSpeakers.Where(p => p.EventId == _event.Id).ToList();
            List<Speaker> current_speakers = new List<Speaker>();
            foreach (var item in current_EventSpeaker)
            {
                current_speakers.Add(_db.Speakers.FirstOrDefault(p => p.Id == item.SpeakerId));
            }
            if (!eventVM.Event.Photo.isImage())
            {
                ModelState.AddModelError(string.Empty, "Choose photo");
                return View(new ViewModels.EventVM
                {
                    Event = _event,
                    AllSpeakers = _db.Speakers.ToList(),
                    Speakers = current_speakers
                });
            }

            string keys = Request.Form["speakers"];
            List<EventSpeaker> new_EventSpeaker = new List<EventSpeaker>();
            if (keys != null)
            {
                string[] _keys = keys.Split(',');
                List<int> ids = new List<int>();
                foreach (var item in _keys)
                {
                    ids.Add(Int32.Parse(item));
                }
                foreach (int item in ids)
                {
                    new_EventSpeaker.Add(new EventSpeaker
                    {
                        EventId = _event.Id,
                        SpeakerId = item
                    });
                }
                current_EventSpeaker = new_EventSpeaker;
                foreach (var item in event_speaker)
                {
                    _db.EventSpeakers.Remove(item);
                }
                foreach (var item in current_EventSpeaker)
                {
                    _db.EventSpeakers.Add(item);
                }
            }
            if (eventVM.Event.Photo != null) 
            {

                _event.Image = await eventVM.Event.Photo.SaveImg(_env.WebRootPath, "img/event");
            }
            _event.Header = eventVM.Event.Header;
            _event.Date = eventVM.Event.Date;
            _event.Interval = eventVM.Event.Interval;
            _event.Location = eventVM.Event.Location;
            _event.Definition = eventVM.Event.Definition;
            _event.Content = eventVM.Event.Content;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Event _event = await _db.Events.FindAsync(id);
            if (_event == null) return NotFound();
            List<EventSpeaker> eventspeakers = _db.EventSpeakers.Where(p => p.EventId == id).ToList();
            List<Speaker> speakers = new List<Speaker>();
            foreach (EventSpeaker event_speaker in eventspeakers)
            {

                speakers.Add(_db.Speakers.FirstOrDefault(p => p.Id == event_speaker.SpeakerId));
            }
            EventDetailVM detailVM = new EventDetailVM
            {
                Event = _event,
                Speakers = speakers
            };
            return View(detailVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Event _event = await _db.Events.FindAsync(id);
            if (_event == null) return NotFound();

            Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/event", _event.Image);
            _db.Events.Remove(_event);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
