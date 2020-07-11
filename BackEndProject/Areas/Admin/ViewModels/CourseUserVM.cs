using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class CourseUserVM
    {
        public IEnumerable<Course> Course { get; set; }
        public User User { get; set; }
        public string Role { get; set; }
    }
}
