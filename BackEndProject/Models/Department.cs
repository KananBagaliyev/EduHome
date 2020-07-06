using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MaxLength(9)]
        public string Abbreviation { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
