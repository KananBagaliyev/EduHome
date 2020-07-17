using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class CourseDetailVM
    {
        public Background Background { get; set; }
        public Course Course { get; set; }
        public Reply Reply { get; set; }
        public IEnumerable<CourseDetail> CourseDetails { get; set; }
        public IEnumerable<CourseFeature> CourseFeatures { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
