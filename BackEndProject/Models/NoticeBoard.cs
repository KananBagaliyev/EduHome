using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class NoticeBoard
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required,MinLength(10),MaxLength(150)]
        public string Content { get; set; }
    }
}
