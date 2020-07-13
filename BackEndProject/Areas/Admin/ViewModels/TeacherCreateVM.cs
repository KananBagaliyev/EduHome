using BackEndProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class TeacherCreateVM
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
        public AboutTeacher AboutTeacher { get; set; }
        public Skill Skill { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
    }
}
