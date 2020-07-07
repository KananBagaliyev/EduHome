using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        public IActionResult Content()
        {
            return View();
        }
        public IActionResult Image()
        {
            return View();
        }
    }
}
