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
    public class VendorController : Controller
    {
        private apContext _apContext;



        public VendorController(apContext apContext)
        {
            _apContext = apContext;
        }






        [HttpGet()]
        public IActionResult Add()
        {
            @TempData["showmessage"] = "dontshow";
            @TempData["message"] = "";



            ViewBag.Action = "Add";

            ViewBag.Terms = _apContext.Terms.OrderBy(g => g.TermsId).ToList();
            ViewBag.generalLedgerAccounts = _apContext.GeneralLedgerAccounts.OrderBy(g => g.AccountNumber).ToList();
            // ViewBag.TransactionTypes = _transactionContext.TransactionTypes.OrderBy(g => g.Name).ToList();

            // ViewBag.Companies = _transactionContext.Companys.OrderBy(g => g.Name).ToList();




            return View("Edit", new Vendor());
        }


        [HttpPost()]
        public IActionResult Add(Vendor vendor)
        {
            if (ModelState.IsValid)
            {

                _apContext.Vendors.Add(vendor);
                _apContext.SaveChanges();

                TempData["VendorAdded"] = true;
                TempData["AddedName"] = vendor.VendorName;
                return RedirectToAction("Index", "Vendors");
            }
            else
            {
                // it's invalid so we simply return the company object
                // to the Edit view setting add action again:
                ViewBag.Action = "Add";


                // also get the company & add them to the View bag:
                ViewBag.Terms = _apContext.Terms.OrderBy(g => g.TermsId).ToList();
                ViewBag.generalLedgerAccounts = _apContext.GeneralLedgerAccounts.OrderBy(g => g.AccountNumber).ToList();

           
  
                ModelState.AddModelError("", "There were errors in the form - please fix them and try again.");
                return View("Edit", vendor);
            }





        }



        // Defining GET & POST actions for the "Edit" sub/request resource:
        [HttpGet("Vendor/edit/{vendorID?}")]
        public IActionResult Edit(int vendorID)
        {
            ViewBag.Action = "Edit";



            ViewBag.Terms = _apContext.Terms.OrderBy(g => g.TermsId).ToList();
            ViewBag.generalLedgerAccounts = _apContext.GeneralLedgerAccounts.OrderBy(g => g.AccountNumber).ToList();

            var Vendors = _apContext.Vendors.OrderBy(n => n.VendorId).ToList();

            object t = new object();
            for (int i = 0; i < Vendors.Count(); i++)
                if (Vendors[i].VendorId == vendorID)
                {
                    t = Vendors[i];
                    break;
                }

            return View(t);
        }




        [HttpPost("Vendor/edit/{vendorID?}")]
        public IActionResult Edit(Vendor vendor)
        {



            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new company to the DB:
                _apContext.Vendors.Update(vendor);
                _apContext.SaveChanges();

                /// updating before sending it back to the user

                return RedirectToAction("Index", "Vendors");
            }
            else
            {
                // it's invalid so we simply return the company object
                // to the Edit view setting add action again:


                ViewBag.Action = "Edit";
                return View(vendor);
            }
        }


        // Defining GET & POST actions for the "Delete" sub/request resource:
        [HttpGet("Vendor/delete/{vendorID?}")]
        public IActionResult Delete(int vendorID)
        {





            // Find/retrieve/select the company to edit and then pass it to the view:
            var vendors = _apContext.Vendors.OrderBy(m => m.VendorId).ToList();
            Vendor ob = new Vendor();
            for (int i = 0; i < vendors.Count(); i++)
                if (vendors[i].VendorId == vendorID)
                {
                    VendorsServices.deletedID = vendorID;
                    ob = vendors[i];
                    break;
                }

            TempData["deletedVendorName"] = ob.VendorName;
            ob.IsDeleted = true;
            _apContext.Vendors.Update(ob);
            _apContext.SaveChanges();

            TempData["undo"] = true;
            return RedirectToAction("Index", "Vendors", new { sortOrder = TempData["activeCathegoryIndex"] });
        }



        [HttpGet("Vendor/retreave/")]
        public IActionResult retreave()
        {


            var vendors = _apContext.Vendors.OrderBy(m => m.VendorId).ToList();
            Vendor ob = new Vendor();
            for (int i = 0; i < vendors.Count(); i++)
                if (vendors[i].VendorId == VendorsServices.deletedID)
                {
                    ob = vendors[i];
                    break;
                }
            ob.IsDeleted = false;
            _apContext.Vendors.Update(ob);
            _apContext.SaveChanges();
            TempData["undo"] = false;
            return RedirectToAction("Index", "Vendors", new { sortOrder = TempData["activeCathegoryIndex"] });

        }

    }
}
