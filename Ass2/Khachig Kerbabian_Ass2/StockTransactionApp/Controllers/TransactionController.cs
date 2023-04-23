using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTransactionApp.Models;
using Microsoft.EntityFrameworkCore;


namespace StockTransactionApp.Controllers
{
    public class TransactionController : Controller
    {

        private TransactionContext _transactionContext;



        public TransactionController(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }






        [HttpGet()]
        public IActionResult Add()
        {
            @TempData["showmessage"] = "dontshow";
            @TempData["message"] = "";



            ViewBag.Action = "Add";


            ViewBag.TransactionTypes = _transactionContext.TransactionTypes.OrderBy(g => g.Name).ToList();

            ViewBag.Companies = _transactionContext.Companys.OrderBy(g => g.Name).ToList();




            return View("Edit", new TransactionRecord());
        }


        [HttpPost()]
        public IActionResult Add(TransactionRecord transaction)
        {
            if (ModelState.IsValid)
            {

                _transactionContext.TransactionRecords.Add(transaction);
                _transactionContext.SaveChanges();
                @TempData["showmessage"] = "show";
                @TempData["message"] = "Transaction has been Added for " + _transactionContext.Companys.Find(transaction.CompanyId).Name + " Company!";
                return RedirectToAction("Index", "Transactions");
            }
            else
            {
                // it's invalid so we simply return the company object
                // to the Edit view setting add action again:
                ViewBag.Action = "Add";


                // also get the company & add them to the View bag:
                ViewBag.TransactionTypes = _transactionContext.TransactionTypes.OrderBy(g => g.Name).ToList();
                ViewBag.Companies = _transactionContext.Companys.OrderBy(g => g.Name).ToList();
                @TempData["showmessage"] = "show";
                @TempData["message"] = "Coudn't Add the Transaction!";
                return View("Edit", transaction);
            }





        }



        // Defining GET & POST actions for the "Edit" sub/request resource:
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            // reseting the TempData to prevent the botton from showing on the shared page
            @TempData["showmessage"] = "dontshow";
            @TempData["message"] = "";


            // also get the company & add them to the View bag:
            ViewBag.TransactionTypes = _transactionContext.TransactionTypes.OrderBy(g => g.Name).ToList();
            ViewBag.Companies = _transactionContext.Companys.OrderBy(g => g.Name).ToList();
            // Find/retrieve/select the company to edit and then pass it to the view:
            var transactions = _transactionContext.TransactionRecords.Include(m => m.Company).Include(n => n.TransactionType).OrderBy(n => n.TransactionId).ToList();
            object t = new object();
            for (int i = 0; i < transactions.Count(); i++)
                if (transactions[i].TransactionId == id)
                {
                    t = transactions[i];
                    break;
                }

            return View(t);
        }




        [HttpPost()]
        public IActionResult Edit(TransactionRecord transaction)
        {



            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new company to the DB:
                _transactionContext.TransactionRecords.Update(transaction);
                _transactionContext.SaveChanges();

                /// updating before sending it back to the user
                @TempData["showmessage"] = "show";
                @TempData["message"] = "Transaction has beed Eddited for " + _transactionContext.Companys.Find(transaction.CompanyId).Name + " Company!";
                return RedirectToAction("Index", "Transactions");
            }
            else
            {
                // it's invalid so we simply return the company object
                // to the Edit view setting add action again:

                @TempData["showmessage"] = "show";
                @TempData["message"] =  "Coudn't Eddit the Transaction!";
                ViewBag.Action = "Edit";
                return View(transaction);
            }
        }


        // Defining GET & POST actions for the "Delete" sub/request resource:
        [HttpGet()]
        public IActionResult Delete(int id)
        {


            @TempData["showmessage"] = "dontshow";
            @TempData["message"] = "";


            // Find/retrieve/select the company to edit and then pass it to the view:
            var transaction = _transactionContext.TransactionRecords.Include(m => m.Company).Include(m => m.TransactionType).OrderBy(m => m.TransactionId).ToList();
            object ob = new object();
            for (int i = 0; i < transaction.Count(); i++)
                if (transaction[i].TransactionId == id)
                {
                    ob = transaction[i];
                    break;
                }
            return View(ob);
        }



        [HttpPost()]
        public IActionResult Delete(TransactionRecord transaction)
        {
            @TempData["showmessage"] = "show";
            @TempData["message"] = "Transaction has been deleted for " + _transactionContext.Companys.Find(transaction.CompanyId).Name + " Company!";

            _transactionContext.TransactionRecords.Remove(transaction);
            _transactionContext.SaveChanges();
            return RedirectToAction("Index", "Transactions");
        }





    }
}
