using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Migrations;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<User> users = _userManager.Users.ToList();
            List<UserVM> userVM = new List<UserVM>();
            foreach(User user in users) 
            {
                if (user.isDeleted == false) 
                {
                    userVM.Add(new UserVM
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Fullname = user.Fullname,
                        Username = user.UserName,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return View(userVM);
        }
        public async Task<IActionResult> Detail(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == await _userManager.GetUserAsync(User)) return NotFound();
            if (user == null) return NotFound();

            UserEditVM userVM = new UserEditVM
            {
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0],
                Course = _db.Courses.FirstOrDefault(c => c.Id == user.CourseID)
            };
            return View(userVM);
        }


        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == await _userManager.GetUserAsync(User)) return NotFound();
            if (user == null) return NotFound();
            if (user.isDeleted == true) return NotFound();

            ViewBag.ActiveRole = (await _userManager.GetRolesAsync(user))[0];

            UserEditVM userVM = new UserEditVM
            {
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0],
                Course = _db.Courses.FirstOrDefault(c=>c.Id == user.CourseID),
                Courses = _db.Courses
            };
            return View(userVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserEditVM userVM)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == await _userManager.GetUserAsync(User)) return NotFound();
            if (user == null) return NotFound();
            string oldRole = (await _userManager.GetRolesAsync(user))[0];
            userVM.Role = oldRole;
            if (oldRole == "Moderator")
            {
                userVM.Course = _db.Courses.FirstOrDefault(c => c.Id == user.CourseID);
                userVM.Courses = _db.Courses;
            }
            else 
            {
                userVM.Course = _db.Courses.First();
                userVM.Courses = _db.Courses;
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            user.Fullname = userVM.Fullname;
            user.UserName = userVM.Username;
            user.Email = userVM.Email;
            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(userVM);
            }
            string newRole = Request.Form["roles"].ToString();
            if (oldRole == "Moderator" && newRole != "Member")
            {
                int course = Int32.Parse(Request.Form["courses"].ToString());
                user.CourseID = course;
            }
            else 
            {
                user.CourseID = _db.Courses.First().Id;
            }
            await _userManager.RemoveFromRoleAsync(user, oldRole);
            await _userManager.AddToRoleAsync(user, newRole);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == await _userManager.GetUserAsync(User)) return NotFound();
            if (user == null) return NotFound();
            if (user.isDeleted == true) return NotFound();


            UserEditVM userVM = new UserEditVM
            {
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0],
                Course = _db.Courses.FirstOrDefault(c => c.Id == user.CourseID)
            };
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteUser(string id, UserVM userVM)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == await _userManager.GetUserAsync(User)) return NotFound();
            if (user == null) return NotFound();
            if (user.isDeleted == true) return NotFound();

            user.isDeleted = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Users");

        }

        [AllowAnonymous ]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");


        }
        public async Task<IActionResult> DeletedUser() 
        {
            List<User> users = _userManager.Users.ToList();
            List<UserVM> userVM = new List<UserVM>();
            foreach (User user in users)
            {
                if (user.isDeleted == true)
                {
                    userVM.Add(new UserVM
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Fullname = user.Fullname,
                        Username = user.UserName,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return View(userVM);
        }

        public async Task<IActionResult> Activate(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (user.isDeleted == false) return NotFound();


            UserEditVM userVM = new UserEditVM
            {
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0],
                Course = _db.Courses.FirstOrDefault(c => c.Id == user.CourseID)
            };
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Activate")]
        public async Task<IActionResult> ActivateUser(string id, UserVM userVM)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (user.isDeleted == false) return NotFound();

            user.isDeleted = false;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Search(string key)
        {
            if (key == null) key = "";
            List<User> users = _userManager.Users.ToList();
            List<UserVM> userVM = new List<UserVM>();

            if (key.Length > 0 || key == "")
            {
                users = _userManager.Users.Where(u => u.UserName.Contains(key) && u.isDeleted == false).ToList();
            }

            foreach (User user in users)
            {
                if (user.isDeleted == false)
                {
                    userVM.Add(new UserVM
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Fullname = user.Fullname,
                        Username = user.UserName,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return PartialView("_UserSearch", userVM);
        }

        public async Task<IActionResult> SearchDeletedUser(string clue)
        {
            if (clue == null) clue = "";
            List<User> users = _userManager.Users.Where(u=>u.isDeleted == true).ToList();
            List<UserVM> userVM = new List<UserVM>();

            if (clue.Length > 0 || clue == "")
            {
                users = _userManager.Users.Where(u => u.UserName.Contains(clue) && u.isDeleted == true).ToList();
            }

            foreach (User user in users)
            {
                if (user.isDeleted == true)
                {
                    userVM.Add(new UserVM
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Fullname = user.Fullname,
                        Username = user.UserName,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return PartialView("_DeletedUserSearch", userVM);
        }
    }
}
