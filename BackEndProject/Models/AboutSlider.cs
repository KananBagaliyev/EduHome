using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class AboutSlider
    {
        public int Id { get; set; }
        [Required,MinLength(5),MaxLength(30)]
        public string Header { get; set; }
        [Required,MinLength(10),MaxLength(160)]
        public string Content { get; set; }
    }
}
