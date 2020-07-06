using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class HeaderFooterVM
    {
        public Data Data { get; set; }
        public IEnumerable<CenterPhoneNumber> CenterPhoneNumbers { get; set; }
    }
}
