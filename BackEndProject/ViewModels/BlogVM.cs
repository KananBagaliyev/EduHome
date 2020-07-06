using BackEndProject.DAL;
using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class BlogVM
    {
        public Background Background { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Event> Events { get; set; }

    }
}
