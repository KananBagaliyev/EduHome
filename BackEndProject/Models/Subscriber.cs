using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
    }
}
