using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class ContactVM
    {
        public Data Data { get; set; }
        public IEnumerable<CenterPhoneNumber> Numbers { get; set; }
        public IEnumerable<CenterPhoneNumber> AllNumbers { get; set; }
    }
}
