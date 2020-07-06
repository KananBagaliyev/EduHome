using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required,MinLength(94),MaxLength(170)]
        public string Description { get; set; }
        [Required, MaxLength(50)]
        public string Speciality { get; set; }
    }
}
