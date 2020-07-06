using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class AboutUs
    {
        public int Id { get; set; }
        [Required,MinLength(5),MaxLength(30)]
        public string Header { get; set; }
        [Required,MinLength(100),MaxLength(300)]
        public string Content { get; set; }
        [Required,MinLength(35),MaxLength(200)]
        public string ShortContent { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
