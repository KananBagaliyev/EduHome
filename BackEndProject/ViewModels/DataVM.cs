using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class DataVM
    {
        public Data Data { get; set; }
        public IEnumerable<CenterPhoneNumber> Phone { get; set; }
        public Reply Reply { get; set; }
    }
}
