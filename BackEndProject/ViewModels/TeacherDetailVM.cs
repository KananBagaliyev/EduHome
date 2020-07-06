using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class TeacherDetailVM
    {
        public Background Background { get; set; }
        public Teacher Teacher { get; set; }
        public Department Department { get; set; }
        public AboutTeacher AboutTeacher { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
        public Skill Skill { get; set; }
    }
}
