using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class CenterPhoneNumber
    {
        public int Id { get; set; }
        [Required]
        public string Phone { get; set; }
        public int DataId { get; set; }
        public virtual Data Data { get; set; }
    }
}
