using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class EditAccountVM
    {
        [Required, StringLength(150)]
        public string Fullname { get; set; }
        [Required, StringLength(30)]
        public string Username { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
