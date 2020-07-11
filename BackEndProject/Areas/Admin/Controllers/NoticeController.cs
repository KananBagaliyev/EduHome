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

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class NoticeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;

        public NoticeController(AppDbContext db,IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            NoticeVM noticeVM = new NoticeVM
            {
                Video = _db.NoticeVideos.FirstOrDefault(),
                Boards = _db.NoticeBoards.OrderByDescending(p=>p.Id)
            };
            return View(noticeVM);
        }

        public async Task<IActionResult> EditVideo(int? id) 
        {
            if (id == null) return NotFound();
            NoticeVideo video = await _db.NoticeVideos.FindAsync(id);
            if (video == null) return NotFound();
            return View(video);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditVideo")]
        public async Task<IActionResult> EditVideo(int? id, NoticeVideo _video,IFormFile File) 
        {
            if (id == null) return NotFound();
            NoticeVideo video = await _db.NoticeVideos.FindAsync(id);
            if (video == null) return NotFound();

            if (File != null) 
            {
                video.Image = await File.SaveImg(_env.WebRootPath, "img/notice");
            }


            video.Link = _video.Link;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create() 
        {
            return View(new NoticeBoard());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> Create(NoticeBoard _board)
        {
            NoticeBoard board = new NoticeBoard 
            {
                Content = _board.Content,
                Date = DateTime.Now
            };

            _db.NoticeBoards.Add(board);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            NoticeBoard board = await _db.NoticeBoards.FindAsync(id);
            if (board == null) return NotFound();
            return View(board);
        }

        public async Task<IActionResult> EditBoard(int? id) 
        {
            if (id == null) return NotFound();
            NoticeBoard board = await _db.NoticeBoards.FindAsync(id);
            if (board == null) return NotFound();


            return View(board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditBoard")]
        public async Task<IActionResult> EditBoard(int? id,NoticeBoard _board)
        {
            if (id == null) return NotFound();
            NoticeBoard board = await _db.NoticeBoards.FindAsync(id);
            if (board == null) return NotFound();

            board.Date = _board.Date;
            board.Content = _board.Content;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            NoticeBoard board = await _db.NoticeBoards.FindAsync(id);
            if (board == null) return NotFound();


            return View(board);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBoard(int? id)
        {
            if (id == null) return NotFound();
            NoticeBoard board = await _db.NoticeBoards.FindAsync(id);
            if (board == null) return NotFound();

            _db.NoticeBoards.Remove(board);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
