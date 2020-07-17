using BackEndProject.Migrations;
using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class ReplySubscriberVM
    {
        public IEnumerable<Models.Reply> Reply { get; set; }
        public IEnumerable<Subscriber> Subscriber { get; set; }
        public string Role { get; set; }
    }
}
