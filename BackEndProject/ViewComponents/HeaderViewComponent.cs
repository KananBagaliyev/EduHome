using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;

        public HeaderViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {

            HeaderFooterVM headerVM = new HeaderFooterVM
            {
                Data = _db.Data.FirstOrDefault(),
                CenterPhoneNumbers = _db.CenterPhoneNumbers
            };
            

            return View(await Task.FromResult(headerVM));
        }
    }
}
