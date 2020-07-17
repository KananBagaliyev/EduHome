using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Migrations;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static BackEndProject.Helpers.Helper;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
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
            return View();
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(EventCreateVM eventVM)
        {
            ViewBag.Speakers = _db.Speakers.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            string keys = Request.Form["speakers"];
            if (keys == null)
            {
                ModelState.AddModelError(string.Empty, "Choose at Least one speaker");
                return View();
            }
            string[] _keys = keys.Split(',');
            List<int> ids = new List<int>();
            foreach (var item in _keys)
            {
                ids.Add(Int32.Parse(item));
            }
            if (!eventVM.Photo.isImage())
            {
                ModelState.AddModelError(string.Empty, "Choose photo");
                return View();
            }


            Event _event =new Event 
            {
                Date = eventVM.Date,
                Header = eventVM.Header,
                Definition = eventVM.Definition,
                Interval  = eventVM.Interval,
                Location = eventVM.Location,
                Content = eventVM.Content,
                Image = await eventVM.Photo.SaveImg(_env.WebRootPath, "img/event")
        };
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

            BackEndProject.Areas.Admin.ViewModels.EventEditVM eventVM = new ViewModels.EventEditVM
            {
                Image = _event.Image,
                Content = _event.Content,
                Header = _event.Header,
                Date = _event.Date,
                Interval = _event.Interval,
                Definition = _event.Definition,
                Location = _event.Location,
                Speakers = speakers,
                AllSpeakers = _db.Speakers.ToList()
            };
            return View(eventVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id, ViewModels.EventEditVM eventVM,IFormFile File)
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
            eventVM.AllSpeakers = _db.Speakers.ToList();
            eventVM.Speakers = current_speakers;
            eventVM.Image = _event.Image;
            if (!ModelState.IsValid) 
            {
                return View(eventVM);
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
            if (File != null) 
            {
                if (!File.isImage())
                {
                    ModelState.AddModelError(string.Empty, "Choose photo type");
                    return View(eventVM);
                }
                Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/event", _event.Image);
                _event.Image = await File.SaveImg(_env.WebRootPath, "img/event");
            }
            _event.Header = eventVM.Header;
            _event.Date = eventVM.Date;
            _event.Interval = eventVM.Interval;
            _event.Location = eventVM.Location;
            _event.Definition = eventVM.Definition;
            _event.Content = eventVM.Content;
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

        public IActionResult Speakers() 
        {
            return View(_db.Speakers.OrderByDescending(s=>s.Id).ToList());
        }

        public IActionResult CreateSpeaker() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpeaker(Speaker _speaker)
        {
            if (!_speaker.Photo.isImage())
            {
                ModelState.AddModelError(string.Empty, "Chose photo type");
                return View(_speaker);
            }
            Speaker speaker = new Speaker
            {
                Image =await _speaker.Photo.SaveImg(_env.WebRootPath, "img/event"),
                Name = _speaker.Name,
                Speciality = _speaker.Speciality
            };

            _db.Speakers.Add(speaker);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Speakers));
        }

        public async Task<IActionResult> EditSpeaker(int? id) 
        {
            if (id == null) return NotFound();
            Speaker speaker = await _db.Speakers.FindAsync(id);
            if (speaker == null) return NotFound();
            SpeakerVM speakerVM = new SpeakerVM
            {
                Image = speaker.Image,
                Name = speaker.Name,
                Speciality = speaker.Speciality
            };

            return View(speakerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpeaker(int? id,SpeakerVM speakerVM, IFormFile File)
        {
            if (id == null) return NotFound();
            Speaker speaker = await _db.Speakers.FindAsync(id);
            if (speaker == null) return NotFound();
            speakerVM.Image = speaker.Image;
            if (File != null) 
            {
                if (!File.isImage()) 
                {
                    ModelState.AddModelError(string.Empty, "Choose photo");
                    return View(speakerVM);
                }
                Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/event", speaker.Image);
                speaker.Image =await File.SaveImg(_env.WebRootPath, "img/event");
            }

            speaker.Name = speakerVM.Name;
            speaker.Speciality = speakerVM.Speciality;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string key)
        {
            if (key == null) key = "";
            var _event = _db.Events.OrderByDescending(p => p.Id).ToList();

            if (key.Length > 0 || key == "")
            {
                _event = _db.Events.Where(c => c.Header.Contains(key)).OrderByDescending(p => p.Id).ToList();
            }
            return PartialView("_EventSearch", _event);
        }

        public async Task<IActionResult> SearchSpeakers(string clue)
        {
            if (clue == null) clue = "";
            var speaker = _db.Speakers.OrderByDescending(p => p.Id).ToList();

            if (clue.Length > 0 || clue == "")
            {
                speaker = _db.Speakers.Where(c => c.Name.Contains(clue)).OrderByDescending(p => p.Id).ToList();
            }
            return PartialView("_SpeakerSearch", speaker);
        }
    }
}
