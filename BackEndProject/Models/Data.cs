using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Data
    {
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Twitter { get; set; }
        [Required]
        public string Pinterest { get; set; }
        [Required]
        public string Vimeo { get; set; }
        [Required]
        public string Location { get; set; }
        [Required,EmailAddress, DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required]
        public string Web { get; set; }
        public virtual ICollection<CenterPhoneNumber> CenterPhoneNumbers { get; set; }
    }
}
