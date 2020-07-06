using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        public int AboutTeacherId { get; set; }
        public virtual AboutTeacher AboutTeacher { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual ICollection<TeacherHobby> TeacherHobbies { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
