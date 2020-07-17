using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult HttpStatusCodeHandler()
        {
            return View();
        }
    }
}
