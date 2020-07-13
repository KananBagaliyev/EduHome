using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class BlogEditVM
    {
        public string Image { get; set; }
        [Required, MinLength(33), MaxLength(63)]
        public string Header { get; set; }
        [Required, MaxLength(6)]
        public string Publisher { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required, MinLength(200)]
        public string Content { get; set; }
    }
}
