using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class CourseFeature
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public decimal Duration { get; set; }
        [Required]
        public decimal ClassDuration { get; set; }
        [Required, MinLength(17)]
        public string SkillLevel { get; set; }
        [Required, MinLength(17)]
        public string Language { get; set; }
        [Required]
        public int Students { get; set; }
        [Required, MinLength(17)]
        public string Assesments  { get; set; }
        [Required]
        public decimal Fee { get; set; }
        public virtual Course Course { get; set; }

    }
}
