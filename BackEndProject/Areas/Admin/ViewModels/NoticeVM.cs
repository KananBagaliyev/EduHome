using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class NoticeVM
    {
        public NoticeVideo Video { get; set; }
        public IEnumerable<NoticeBoard> Boards { get; set; }
    }
}
