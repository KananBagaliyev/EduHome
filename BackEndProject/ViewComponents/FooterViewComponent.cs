using BackEndProject.DAL;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;

        public FooterViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync() {

            HeaderFooterVM footerVM = new HeaderFooterVM
            {
                Data = _db.Data.FirstOrDefault(),
                CenterPhoneNumbers = _db.CenterPhoneNumbers
            };

            return View(await Task.FromResult(footerVM));
        }
    }
}
