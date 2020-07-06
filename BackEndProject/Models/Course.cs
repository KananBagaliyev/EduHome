using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        public int CourseDetailId { get; set; }
        public virtual CourseDetail CourseDetail { get; set; }
        public int CourseFeatureId { get; set; }
        public virtual CourseFeature CourseFeature { get; set; }
    }
}
