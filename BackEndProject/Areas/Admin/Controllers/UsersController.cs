using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            if (user == null) return NotFound();

            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0]
            };
            return View(userVM);
        }


        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (user.isDeleted == true) return NotFound();

            ViewBag.ActiveRole = (await _userManager.GetRolesAsync(user))[0];

            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0]
            };
            return View(userVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            string oldRole = (await _userManager.GetRolesAsync(user))[0];
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
            await _userManager.RemoveFromRoleAsync(user, oldRole);
            await _userManager.AddToRoleAsync(user, newRole);

            return RedirectToAction("Index", "Users");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (user.isDeleted == true) return NotFound();


            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0]
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
            if (user == null) return NotFound();
            if (user.isDeleted == true) return NotFound();

            user.isDeleted = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Users");

        }

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


            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0]
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
    }
}
