using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorsManagmentApp.Models.DbGenerated;
using VendorsManagmentApp.Services;

using VendorsManagmentApp.Models;




namespace VendorsManagmentApp.Controllers
{
    public class ValidationController : Controller
    {
        private apContext _apContext;

        public ValidationController(apContext apc)
        {
            _apContext = apc;


        }

        public IActionResult CheckPhone(string VendorPhone)
        {
            string msg = CheckIfPhoneExistsInDb(VendorPhone);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okPhone"] = true;
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }

        private string CheckIfPhoneExistsInDb(string N)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(N))
            {
                var vendor = _apContext.Vendors.Where(c => c.VendorPhone.ToLower() == N.ToLower()).FirstOrDefault();
                if (vendor != null)
                    msg = $"The phone number \"{N}\" is already in use.";
            }

            return msg;
        }


      
    }
}
