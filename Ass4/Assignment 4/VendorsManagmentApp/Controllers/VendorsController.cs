using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorsManagmentApp.Models;
using VendorsManagmentApp.Models.DbGenerated;
using VendorsManagmentApp.Services;






namespace VendorsManagmentApp.Controllers
{
    public class VendorsController : Controller
    {
        //private VendorsServices _venServices;
        private apContext _apContext;

        public VendorsController(apContext venSer)
        {
            _apContext = venSer;
        }
        [HttpGet("Vendors/{sortOrder?}")]
        public IActionResult Index(int sortOrder)
        {
            VendorsViewModel vvm = new VendorsViewModel();
            vvm.VendorsItems = VendorsServices.GetVendorsByCategory(_apContext, VendorsServices.VendorsDisplayCategories[sortOrder]);
            vvm.VendorsCategories = VendorsServices.VendorsDisplayCategories;
            vvm.ActiveCategoryindex = sortOrder;
            vvm.ActiveCategory = VendorsServices.VendorsDisplayCategories[sortOrder];
            TempData["activeCathegoryIndex"] = vvm.ActiveCategoryindex;
            TempData["activeCathegory"] = vvm.ActiveCategory;
            return View(vvm);
        }
    }
}
