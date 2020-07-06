using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Speciality { get; set; }
        public virtual ICollection<EventSpeaker> EventSpeakers { get; set; }
    }
}
