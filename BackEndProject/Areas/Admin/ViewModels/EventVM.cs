using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class EventVM
    {
        public  Event Event { get; set; }
        public Speaker Speaker { get; set; }
    }
}
