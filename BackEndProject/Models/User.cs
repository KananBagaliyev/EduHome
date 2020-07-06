using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class User:IdentityUser
    {
        [Required, StringLength(100)]
        public string Fullname { get; set; }
        [Required]
        public bool isDeleted { get; set; }
        public User()
        {
            isDeleted = false;
        }
    }
}
