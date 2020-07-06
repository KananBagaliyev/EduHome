using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class AboutVM
    {
        public Background Background { get; set; }
        public AboutUs AboutUs { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<AboutTeacher> AboutTeachers { get; set; }
        public IEnumerable<Testimonial> Testimonials { get; set; }
        public NoticeVideo NoticeVideo { get; set; }
        public IEnumerable<NoticeBoard> NoticeBoards { get; set; }

    }
}
