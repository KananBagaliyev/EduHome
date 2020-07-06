using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required,MinLength(4),MaxLength(24)]
        public string Header { get; set; }
        [Required,MinLength(47),MaxLength(87)]
        public string Content { get; set; }
    }
}
