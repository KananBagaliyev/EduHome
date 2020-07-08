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

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            BackEndProject.Areas.Admin.ViewModels.TeacherVM teacherVM = new ViewModels.TeacherVM
            {
                Departments = _db.Departments,
                Hobbies = _db.Hobbies,
            };
            return View(teacherVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(BackEndProject.Areas.Admin.ViewModels.TeacherVM teacherVM)
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
            string _hobbies = Request.Form["hobbies"];
            string _department = Request.Form["department"];
            if (_hobbies == null)
            {
                ModelState.AddModelError(string.Empty, "Choose at Least one hobby");
                return View(new ViewModels.TeacherVM
                {
                    Departments = _db.Departments,
                    Hobbies = _db.Hobbies,
                });
            }
            if (_department == null)
            {
                ModelState.AddModelError(string.Empty, "Choose a department");
                return View(new ViewModels.TeacherVM
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

            if (!teacherVM.Teacher.Photo.isImage())
            {
                ModelState.AddModelError(string.Empty, "Choose photo");
                return View(new ViewModels.TeacherVM
                {
                    Departments = _db.Departments,
                    Hobbies = _db.Hobbies,
                });
            }


            Teacher teacher = teacherVM.Teacher;
            teacher.Image = await teacherVM.Teacher.Photo.SaveImg(_env.WebRootPath, "img/teacher");

            //if (teacherVM.AboutTeacher.Facebook == null)
            //{
            //    teacherVM.AboutTeacher.Facebook = "https://www.facebook.com/";
            //}
            //if (teacherVM.AboutTeacher.Pinterest == null)
            //{
            //    teacherVM.AboutTeacher.Pinterest = "https://www.pinterest.com/";
            //}
            //if (teacherVM.AboutTeacher.Vimeo == null)
            //{
            //    teacherVM.AboutTeacher.Vimeo = "https://vimeo.com/";
            //}
            //if (teacherVM.AboutTeacher.Twitter == null)
            //{
            //    teacherVM.AboutTeacher.Twitter = "https://twitter.com/explore";
            //}
            teacher.AboutTeacher = teacherVM.AboutTeacher;
            teacher.Skill = teacherVM.Skill;
            List<TeacherHobby> tHobby = new List<TeacherHobby>();

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
            return Json(teacherVM.AboutTeacher);

        }
    }
}
