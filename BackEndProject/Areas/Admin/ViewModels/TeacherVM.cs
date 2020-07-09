using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class TeacherVM
    {
        public Teacher Teacher { get; set; }
        public Department Department { get; set; }
        public AboutTeacher AboutTeacher { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
        public Skill Skill { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Hobby> AllHobbies { get; set; }
    }
}
