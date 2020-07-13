using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class EventEditVM
    {
        public string Image { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required, MinLength(5), MaxLength(28)]
        public string Header { get; set; }
        [Required, MinLength(5), MaxLength(47)]
        public string Definition { get; set; }
        [Required, MinLength(9), MaxLength(17)]
        public string Interval { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Location { get; set; }
        [Required, MinLength(150)]
        public string Content { get; set; }
        public List<Speaker> Speakers { get; set; }
        public List<Speaker> AllSpeakers { get; set; }
    }
}
