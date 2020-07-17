using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace BackEndProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [Authorize]
        public async Task<IActionResult> Index() 
        {
            User user = await _userManager.GetUserAsync(User);
            EditAccountVM accountVM = new EditAccountVM
            {
                Username = user.UserName,
                Fullname = user.Fullname,
                Email = user.Email
            };
            return View(accountVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EditAccountVM accountVM)
        {
            User user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid) 
            {
                return View(accountVM);
            }
            user.Email = accountVM.Email;
            user.Fullname = accountVM.Fullname;
            user.UserName = accountVM.Username;
            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(accountVM);
            }
            return Redirect("/home/index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Register")]
        public async Task<IActionResult> Register(RegisterVM _register) 
        {
            if (!ModelState.IsValid) 
            {
                return View(_register);
            }
            User user = new User
            {
                Fullname = _register.Fullname,
                Email = _register.Email,
                UserName = _register.Username
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, _register.Password);

            if (!identityResult.Succeeded) 
            {
                foreach (var error in identityResult.Errors) 
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            await _userManager.AddToRoleAsync(user, Helpers.Helper.Roles.Member.ToString());
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Login")]
        public async Task<IActionResult> Login(LoginVM _login)
        {
            if (!ModelState.IsValid) return View(_login);
            User active_user = await _userManager.FindByEmailAsync(_login.Email);
            if (active_user == null)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is incorrect");
                return View(_login);
            }
            if (active_user.isDeleted == true)
            {
                ModelState.AddModelError(string.Empty, "This user has been deleted or blocked");
                return View(_login);
            }   
            Microsoft.AspNetCore.Identity.SignInResult  signInResult;
            if (_login.isChecked == true)
            {
                signInResult = await _signInManager.PasswordSignInAsync(active_user, _login.Password, true, true);
            }
            else
            {
                signInResult = await _signInManager.PasswordSignInAsync(active_user, _login.Password, false, true);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or Password are wrong!!!");
                return View(_login);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task CreateRole()
        {

            if (!await _roleManager.RoleExistsAsync(Helpers.Helper.Roles.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Helper.Roles.Admin.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(Helpers.Helper.Roles.Moderator.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Helper.Roles.Moderator.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(Helpers.Helper.Roles.Member.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Helper.Roles.Member.ToString()));
            }


        }
    }
}
