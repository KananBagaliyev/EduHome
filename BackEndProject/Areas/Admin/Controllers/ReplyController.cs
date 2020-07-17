using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ReplyController : Controller
    {
        private readonly AppDbContext _db;
        public ReplyController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Replies.OrderByDescending(p=>p.Id));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Models.Reply reply = await _db.Replies.FindAsync(id);
            if (reply == null) return NotFound();
            return View(reply);
        }

        public async Task<IActionResult> Answer(int? id)
        {
            if (id == null) return NotFound();
            Models.Reply reply = await _db.Replies.FindAsync(id);
            if (reply == null) return NotFound();

            ReplyAnswerVM answerVM = new ReplyAnswerVM
            {
                Reply = reply
            };
            return View(answerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(int? id,ReplyAnswerVM answerVM)
        {
            if (id == null) return NotFound();
            Models.Reply reply = await _db.Replies.FindAsync(id);
            if (reply == null) return NotFound();
            answerVM.Reply = reply;
            if (!ModelState.IsValid) 
            {
                return View(answerVM);
            }

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply.codetutorial@gmail.com", "No-Reply");
            mail.To.Add(new MailAddress(reply.Email));

            mail.Subject = answerVM.Subject;
            mail.Body = $"<h2>Hi {reply.Name}</h2> <p>{answerVM.Message}</p>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("noreply.codetutorial@gmail.com", "kb6853917");
            smtp.Send(mail);

            if (reply.Checked == false) 
            {
                reply.Checked = true;
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Read(int? id) 
        {
            if (id == null) return NotFound();
            Models.Reply reply = await _db.Replies.FindAsync(id);
            if (reply == null) return NotFound();
            if (reply.Checked == true) return NotFound();

            reply.Checked = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Unread(int? id)
        {
            if (id == null) return NotFound();
            Models.Reply reply = await _db.Replies.FindAsync(id);
            if (reply == null) return NotFound();
            if (reply.Checked == false) return NotFound();

            reply.Checked = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> AllRead(string value) 
        {
            int[] values = JsonConvert.DeserializeObject<int[]>(value);

            foreach (int val in values)
            {
                _db.Replies.FirstOrDefault(r => r.Id == val).Checked = true;
            }
            await _db.SaveChangesAsync();
            IEnumerable<Models.Reply> model = _db.Replies.OrderByDescending(r => r.Id).ToList();
            return PartialView("_Reply",model);
        }

        public async Task<IActionResult> AllDelete(string value)
        {
            int[] values = JsonConvert.DeserializeObject<int[]>(value);

            foreach (int val in values)
            {
                _db.Replies.Remove(_db.Replies.FirstOrDefault(r => r.Id == val));
            }
            await _db.SaveChangesAsync();
            IEnumerable<Models.Reply> model = _db.Replies.OrderByDescending(r => r.Id).ToList();
            return PartialView("_Reply", model);
        }

        public async Task<IActionResult> DeleteOne(int? key)
        {
            if (key == null) return NotFound();
            _db.Replies.Remove(_db.Replies.FirstOrDefault(r => r.Id == key));
            await _db.SaveChangesAsync();
            IEnumerable<Models.Reply> model = _db.Replies.OrderByDescending(r => r.Id).ToList();
            return PartialView("_Reply", model);
        }
        public async Task<IActionResult> Search(string key)
        {
            if (key == null) key = "";
            var reply = _db.Replies.OrderByDescending(p => p.Id).ToList();

            if (key.Length > 0 || key == "")
            {
                reply = _db.Replies.Where(c => c.Email.Contains(key)).OrderByDescending(p => p.Id).ToList();
            }
            return PartialView("_ReplySearch", reply);
        }
    }
}
