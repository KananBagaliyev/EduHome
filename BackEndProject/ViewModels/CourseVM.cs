using BackEndProject.DAL;
using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class CourseVM
    {
        public Background Background { get; set; }
        public IEnumerable<Course> Course { get; set; }
        public IEnumerable<CourseDetail> CourseDetails { get; set; }
        public IEnumerable<CourseFeature> CourseFeatures { get; set; }
    }
}
