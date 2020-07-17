using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BackEndProject.Migrations;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public TeacherController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Teachers);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            List<TeacherHobby> techerhobbies = _db.TeacherHobbies.Where(p => p.TeacherId == id).ToList();
            List<Hobby> hobbies = new List<Hobby>();
            foreach (TeacherHobby teacherhobby in techerhobbies)
            {
                hobbies.Add(_db.Hobbies.FirstOrDefault(p => p.Id == teacherhobby.HobbyId));
            }
            TeacherDetailVM detailVM = new TeacherDetailVM
            {
                Teacher = teacher,
                AboutTeacher = _db.AboutTeachers.FirstOrDefault(p => p.Id == teacher.AboutTeacherId),
                Department = _db.Departments.FirstOrDefault(p => p.Id == teacher.DepartmentId),
                Hobbies = hobbies,
                Skill = _db.Skills.FirstOrDefault(p => p.Id == teacher.SkillId)

            };
            return View(detailVM);
        }
        public IActionResult Create() 
        {
            BackEndProject.Areas.Admin.ViewModels.TeacherCreateVM teacherVM = new ViewModels.TeacherCreateVM
            {
                Departments = _db.Departments,
                Hobbies = _db.Hobbies,
            };
            return View(teacherVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(BackEndProject.Areas.Admin.ViewModels.TeacherCreateVM teacherVM)
        {
            teacherVM.Departments = _db.Departments;
            teacherVM.Hobbies = _db.Hobbies;
            if (teacherVM.AboutTeacher.Facebook == null)
            {
                teacherVM.AboutTeacher.Facebook = "https://www.facebook.com/";
            }
            if (teacherVM.AboutTeacher.Pinterest == null)
            {
                teacherVM.AboutTeacher.Pinterest = "https://www.pinterest.com/";
            }
            if (teacherVM.AboutTeacher.Vimeo == null)
            {
                teacherVM.AboutTeacher.Vimeo = "https://vimeo.com/";
            }
            if (teacherVM.AboutTeacher.Twitter == null)
            {
                teacherVM.AboutTeacher.Twitter = "https://twitter.com/explore";
            }
            if (!ModelState.IsValid)
            {
                return View(teacherVM);
            }

            string _hobbies = Request.Form["hobbies"];
            string _department = Request.Form["department"];
            if (_hobbies == null)
            {
                ModelState.AddModelError(string.Empty, "Choose at Least one hobby");
                return View(teacherVM);
            }
            if (_department == null)
            {
                ModelState.AddModelError(string.Empty, "Choose a department");
                return View(new ViewModels.TeacherCreateVM
                {
                    Departments = _db.Departments,
                    Hobbies = _db.Hobbies,
                });
            }
            string[] sHobbies = _hobbies.Split(',');
            List<int> hobbies = new List<int>();
            int department = Int32.Parse(_department);
            foreach (var item in sHobbies)
            {
                hobbies.Add(Int32.Parse(item));
            }

            if (!teacherVM.Photo.isImage())
            {
                ModelState.AddModelError(string.Empty, "Choose photo");
                return View(teacherVM);
            }

            

            AboutTeacher about = teacherVM.AboutTeacher;
            Skill skill = teacherVM.Skill;
            List<TeacherHobby> tHobby = new List<TeacherHobby>();
            Teacher teacher = new Teacher
            {
                Name = teacherVM.Name,
                Image = await teacherVM.Photo.SaveImg(_env.WebRootPath, "img/teacher"),
                AboutTeacher = about,
                Skill = skill
            };
            foreach (int item in hobbies)
            {
                tHobby.Add(new TeacherHobby
                {
                    TeacherId = teacher.Id,
                    HobbyId = item
                });
            }
            teacher.Department = await _db.Departments.FindAsync(department);
            teacher.TeacherHobbies = tHobby;

            _db.Teachers.Add(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            List<TeacherHobby> teacher_hobbies = _db.TeacherHobbies.Where(p => p.TeacherId == teacher.Id).ToList();
            List<Hobby> hobbies = new List<Hobby>();
            foreach (var item in teacher_hobbies)
            {
                hobbies.Add(_db.Hobbies.FirstOrDefault(p => p.Id == item.HobbyId));
            }
            ViewBag.Hobbies = "";
            BackEndProject.Areas.Admin.ViewModels.TeacherEditVM teacherVM = new ViewModels.TeacherEditVM
            {
                Image = teacher.Image,
                Name = teacher.Name,
                AboutTeacher = _db.AboutTeachers.FirstOrDefault(p => p.Id == teacher.AboutTeacherId),
                Skill = _db.Skills.FirstOrDefault(p => p.Id == teacher.SkillId),
                Departments = _db.Departments.ToList(),
                Department = _db.Departments.FirstOrDefault(p => p.Id == teacher.DepartmentId),
                AllHobbies = _db.Hobbies,
                Hobbies = hobbies
            };
            return View(teacherVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id, BackEndProject.Areas.Admin.ViewModels.TeacherEditVM teacherVM, IFormFile File)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            List<TeacherHobby> teacher_hobby = _db.TeacherHobbies.Where(p => p.TeacherId == teacher.Id).ToList();
            List<TeacherHobby> teacher_hobbies = _db.TeacherHobbies.Where(p => p.TeacherId == teacher.Id).ToList();
            List<Hobby> hobbies = new List<Hobby>();
            foreach (var item in teacher_hobbies)
            {
                hobbies.Add(_db.Hobbies.FirstOrDefault(p => p.Id == item.HobbyId));
            }
            teacherVM.Image = teacher.Image;
            teacherVM.Departments = _db.Departments.ToList();
            teacherVM.Department = _db.Departments.FirstOrDefault(p => p.Id == teacher.DepartmentId);
            teacherVM.AllHobbies = _db.Hobbies;
            teacherVM.Hobbies = hobbies;

            if (!ModelState.IsValid) 
            {
                return View(teacherVM);
            }

            string new_hobby = Request.Form["hobbies"];
            List<TeacherHobby> new_teacher_hobbies = new List<TeacherHobby>();
            if (new_hobby != null)
            {
                string[] string_new_hobbies = new_hobby.Split(',');
                List<int> new_hobbies = new List<int>();
                foreach (var item in string_new_hobbies)
                {
                    new_hobbies.Add(Int32.Parse(item));
                }
                foreach (var item in new_hobbies)
                {
                    new_teacher_hobbies.Add(new TeacherHobby
                    {
                        TeacherId = teacher.Id,
                        HobbyId = item
                    });
                }
                teacher_hobbies = new_teacher_hobbies;
                foreach (var item in teacher_hobby)
                {
                    _db.TeacherHobbies.Remove(item);
                }
                foreach (var item in teacher_hobbies)
                {
                    _db.TeacherHobbies.Add(item);
                }
            }



            if (File != null)
            {
                if (!File.isImage()) 
                {
                    ModelState.AddModelError(string.Empty, "Chose photo type ");
                    return View(teacherVM);
                }
                Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/teacher", teacher.Image);
                teacher.Image = await File.SaveImg(_env.WebRootPath, "img/teacher");

            }


            teacher.AboutTeacher = teacherVM.AboutTeacher;
            teacher.Skill = teacherVM.Skill;
            string department = Request.Form["department"];
            if (department != null)
            {
                teacher.Department = await _db.Departments.FindAsync(Int32.Parse(department));
            }
            teacher.Name = teacherVM.Name;
            await _db.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            List<TeacherHobby> techerhobbies = _db.TeacherHobbies.Where(p => p.TeacherId == id).ToList();
            List<Hobby> hobbies = new List<Hobby>();
            foreach (TeacherHobby teacherhobby in techerhobbies)
            {
                hobbies.Add(_db.Hobbies.FirstOrDefault(p => p.Id == teacherhobby.HobbyId));
            }
            TeacherDetailVM detailVM = new TeacherDetailVM
            {
                Teacher = teacher,
                AboutTeacher = _db.AboutTeachers.FirstOrDefault(p => p.Id == teacher.AboutTeacherId),
                Department = _db.Departments.FirstOrDefault(p => p.Id == teacher.DepartmentId),
                Hobbies = hobbies,
                Skill = _db.Skills.FirstOrDefault(p => p.Id == teacher.SkillId)

            };
            return View(detailVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();

            Helpers.Helper.DeleteIMG(_env.WebRootPath, "img/teacher", teacher.Image);
            _db.Teachers.Remove(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Hobby() 
        {
            return View(_db.Hobbies);
        }
        public IActionResult CreateHobby()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHobby(Hobby _hobby)
        {
            if(_db.Hobbies.Any(h=>h.Name.ToLower() == _hobby.Name.ToLower())) 
            {
                ModelState.AddModelError(string.Empty, "This hobby is already exist");
                return View();
            }
            Hobby hobby = new Hobby
            {
                Name = _hobby.Name
            };

            _db.Hobbies.Add(hobby);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult HobbyDetail(int? id)
        {
            if (id == null) return NotFound();
            Hobby hobby = _db.Hobbies.FirstOrDefault(h => h.Id == id);
            if (hobby == null) return NotFound();

            return View(hobby);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HobbyDetail(int? id,Hobby _hobby)
        {
            if (id == null) return NotFound();
            Hobby hobby = await _db.Hobbies.FindAsync(id);
            Hobby checkedHobby = _db.Hobbies.FirstOrDefault(h => h.Name.ToLower() == _hobby.Name.ToLower());

            if (hobby.Id != checkedHobby.Id) 
            {
                ModelState.AddModelError(string.Empty, "This hobby is already exist");
                return View();
            }
            if (hobby == null) return NotFound();

            hobby.Name = _hobby.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Departments()
        {
            return View(_db.Departments);
        }

        public IActionResult CreateDep() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDep(Department department)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_db.Departments.Any(d => d.Name.ToLower() == department.Name.ToLower())) 
            {
                ModelState.AddModelError(string.Empty, "This deparment is aready exist");
                return View();
            }

            Department dep = new Department 
            {
                Abbreviation = department.Abbreviation,
                Name = department.Name
            };

            _db.Departments.Add(dep);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DepDetail(int? id)
        {
            if (id == null) return NotFound();
            Department dep = _db.Departments.FirstOrDefault(h => h.Id == id);
            if (dep == null) return NotFound();

            return View(dep);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepDetail(int? id, Department _dep)
        {
            if (id == null) return NotFound();
            Department dep = await _db.Departments.FindAsync(id);
            Department checkedDep = _db.Departments.FirstOrDefault(d => d.Name.ToLower() == _dep.Name.ToLower());

            if (dep.Id != checkedDep.Id)
            {
                ModelState.AddModelError(string.Empty, "This hobby is already exist");
                return View();
            }
            if (dep == null) return NotFound();

            dep.Name = _dep.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Search(string key)
        {
            if (key == null) key = "";
            var teacher = _db.Teachers.ToList();

            if (key.Length > 0 || key == "")
            {
                teacher = _db.Teachers.Where(c => c.Name.Contains(key)).ToList();
            }
            return PartialView("_TeacherSearch", teacher);
        }
        public async Task<IActionResult> SearchHobby(string clue)
        {
            if (clue == null) clue = "";
            var hobby = _db.Hobbies.ToList();

            if (clue.Length > 0 || clue == "")
            {
                hobby = _db.Hobbies.Where(c => c.Name.Contains(clue)).ToList();
            }
            return PartialView("_HobbySearch", hobby);
        }
        public async Task<IActionResult> SearchDepartments(string clue)
        {
            if (clue == null) clue = "";
            var dep = _db.Departments.ToList();

            if (clue.Length > 0 || clue == "")
            {
                dep = _db.Departments.Where(c => c.Name.Contains(clue)).ToList();
            }
            return PartialView("_DepSearch", dep);
        }
    }
}
