using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class CourseDetail
    {
        public int Id { get; set; }
        [Required,MinLength(50)]
        public string Content { get; set; }
        [Required,MinLength(200)]
        public string AboutCourse { get; set; }
        [Required]
        public string HowToApply { get; set; }
        [Required]
        public string Certification { get; set; }
        public virtual Course Course { get; set; }
    }
}
