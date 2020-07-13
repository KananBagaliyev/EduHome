using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class CourseEditVM
    {
        [Required]
        public string Name { get; set; }
        [Required, MinLength(95), MaxLength(144)]
        public string Content { get; set; }
        [Required, MinLength(200)]
        public string AboutCourse { get; set; }
        [Required]
        public string HowToApply { get; set; }
        [Required]
        public string Certification { get; set; }
        public CourseFeature CourseFeature { get; set; }
    }
}
