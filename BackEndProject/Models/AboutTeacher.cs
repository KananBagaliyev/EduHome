using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class AboutTeacher
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Speciality { get; set; }
        [Required,MinLength(100)]
        public string About { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Pinterest { get; set; }
        public string Vimeo { get; set; }
    }
}
