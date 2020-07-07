using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class CourseVM
    {
        public Course Course { get; set; }
        public CourseDetail CourseDetail { get; set; }
        public CourseFeature CourseFeature { get; set; }
    }
}
