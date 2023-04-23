using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTransactionApp.Models;

namespace StockTransactionApp.Controllers
{
    public class TransactionController : Controller
    {

        private TransactionContext _transactionContext;



        public TransactionController(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }







        // Defining GET & POST actions for the "Add" sub/request resource:
        [HttpGet()]
        public IActionResult Add()
        {
            // Because editing & adding new tansaction will share the same view
            // we will set the action here:
            ViewBag.Action = "Add";

            // also get the Genres & add them to the View bag:
            ViewBag.TransactionTypes = _transactionContext.TransactionTypes.OrderBy(g => g.Name).ToList();


            // Return the blank Edit view by naming it:
            // NOTE: if we don't give the name of the view ASP.NET Core
            // will look for a view named Add, not Edit
            return View("Edit", new Transaction());
        }

        // ASP.NET Core MVC does the work of taking the new Movie form
        // data and bundling/serializing it into a Movie object that is
        // passed here as an input param
        [HttpPost()]
        public IActionResult Add(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _transactionContext.Transactions.Add(transaction);
                _transactionContext.SaveChanges();
                return RedirectToAction("Index", "Transactions");
            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view setting add action again:
                ViewBag.Action = "Add";


                // also get the Genres & add them to the View bag:
                ViewBag.TransactionTypes = _transactionContext.TransactionTypes.OrderBy(g => g.Name).ToList();

                return View("Edit", transaction);
            }





        }



        // Defining GET & POST actions for the "Edit" sub/request resource:
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            // also get the Genres & add them to the View bag:
            ViewBag.TransactionTypes = _transactionContext.TransactionTypes.OrderBy(g => g.Name).ToList();

            // Find/retrieve/select the movie to edit and then pass it to the view:
            var transaction = _transactionContext.Transactions.Find(id);

            return View(transaction);
        }

        [HttpPost()]
        public IActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _transactionContext.Transactions.Update(transaction);
                _transactionContext.SaveChanges();
                return RedirectToAction("Index", "Transactions");
            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view setting add action again:
                ViewBag.Action = "Edit";
                return View( transaction);
            }
        }












        // Defining GET & POST actions for the "Delete" sub/request resource:
        [HttpGet()]
        public IActionResult Delete(int id)
        {
            // Find/retrieve/select the movie to edit and then pass it to the view:
            var transaction = _transactionContext.Transactions.Find(id);
            return View(transaction);
        }

        [HttpPost()]
        public IActionResult Delete(Transaction transaction)
        {
            // Simply remove the movie and then redirect back to the all moviews view:
            _transactionContext.Transactions.Remove(transaction);
            _transactionContext.SaveChanges();
            return RedirectToAction("Index", "Transactions");
        }





    }
}
