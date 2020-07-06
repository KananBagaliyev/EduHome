using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class EventDetailVM
    {
        public Background Background { get; set; }
        public Event Event { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
