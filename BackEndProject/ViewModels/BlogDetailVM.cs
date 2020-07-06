using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class BlogDetailVM
    {
        public Background Background { get; set; }
        public Blog Blog { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
