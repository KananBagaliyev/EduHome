using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class TeacherEditVM
    {
        public string Image { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public AboutTeacher AboutTeacher { get; set; }
        public Skill Skill { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
        public IEnumerable<Hobby> AllHobbies { get; set; }
    }
}
