using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        public TeacherController(AppDbContext db)
        {
            _db = db;
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
    }
}
