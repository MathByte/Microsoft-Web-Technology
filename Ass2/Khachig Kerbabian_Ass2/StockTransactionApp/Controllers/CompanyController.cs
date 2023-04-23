using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTransactionApp.Models;

namespace StockTransactionApp.Controllers
{
    public class CompanyController : Controller
    {


        private TransactionContext _transactionContext;

        public CompanyController(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;

        }



  
        [HttpGet()]
        public IActionResult Add()
        {
            @TempData["showmessage"] = "dontshow";
            @TempData["message"] = "";

            ViewBag.Action = "Add";
            ViewBag.Companies = _transactionContext.Companys.OrderBy(g => g.Name).ToList(); 
            return View("Edit", new Company());
        }

        
        [HttpPost()]
        public IActionResult Add(Company company)
        {
            if (ModelState.IsValid)
            {
     
                _transactionContext.Companys.Add(company);
                _transactionContext.SaveChanges();
                @TempData["showmessage"] = "show";
                @TempData["message"] = company.Name + " company has been added!";
                return RedirectToAction("Index", "Companys");
            }
            else
            {
                ViewBag.Action = "Add";            
                ViewBag.Companys = _transactionContext.Companys.OrderBy(g => g.Name).ToList();
                @TempData["showmessage"] = "show";
                @TempData["message"] = company.Name + " company failed to add!";

                return View("Edit", company);
            }





        }



        // Defining GET & POST actions for the "Edit" sub/request resource:
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            @TempData["showmessage"] = "dontshow";
            @TempData["message"] = "";

            ViewBag.Action = "Edit";

            // also get the Companys & add them to the View bag:
            ViewBag.Companys = _transactionContext.Companys.OrderBy(g => g.Name).ToList();

            // Find/retrieve/select the company to edit and then pass it to the view:
            var company = _transactionContext.Companys.Find(id);

            return View(company);
        }

        [HttpPost()]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new company to the DB:
                _transactionContext.Companys.Update(company);
                _transactionContext.SaveChanges();
                @TempData["showmessage"] = "show";
                @TempData["message"] = company.Name + " company has been Eddited!";
                return RedirectToAction("Index", "Companys");
            }
            else
            {
                // it's invalid so we simply return the company object
                // to the Edit view setting add action again:
                @TempData["showmessage"] = "show";
                @TempData["message"] = company.Name + " company failed to Eddit!";
                ViewBag.Action = "Edit";
                return View(company);
            }
        }




        [HttpGet()]
        public IActionResult Delete(int id)
        {
            @TempData["showmessage"] = "dontshow";
            @TempData["message"] = "";
            var company = _transactionContext.Companys.Find(id);
            return View(company);
        }

        [HttpPost()]
        public IActionResult Delete(Company company)
        {
            @TempData["showmessage"] = "show";
            @TempData["message"] = company.Name + " company has beed Deleted!";
            _transactionContext.Companys.Remove(company);
            _transactionContext.SaveChanges();
            return RedirectToAction("Index", "Companys");
        }
    }
}
