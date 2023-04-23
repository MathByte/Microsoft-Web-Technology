using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTransactionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace StockTransactionApp.Controllers
{
    public class TransactionsController : Controller
    {
        private TransactionContext _transactionContext;

        public TransactionsController(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }


        [HttpGet("/Transactions/{sortOrder?}")]
        public IActionResult Index(string sortOrder)
        {
            TempData["PageName"] = "Transactions";



            // firs to check if it is empty of null 
            if (sortOrder == null || sortOrder == "")
                sortOrder = "Ascending";


            //sseconf, check if it can be parsed, if yes that means it is filtered sorting list view 
            int outputInt = 0;
            if(int.TryParse(sortOrder, out outputInt))
            {
                var transactions = _transactionContext.TransactionRecords.Include(m => m.TransactionType).Include(m => m.Company).OrderBy(m => m.TransactionId).ToList();
                List<TransactionRecord> sendd = new List<TransactionRecord>();
                foreach (TransactionRecord t in transactions)
                    if (t.CompanyId == outputInt)
                        sendd.Add(t);

                //try chack if for checking if the list if empty or not
                try
                {
                    TempData["PageName"] = sendd[0].Company.Name + "'s transactions only!";
                    @ViewData["NameSortParm"] = "Ascending";
                    @ViewData["pagetype"] = "companypage";
                    return View(sendd);
                }
                catch (Exception)
                {

                    TempData["PageName"] = "No Tranasaction available to show!";
                    @ViewData["NameSortParm"] = "Ascending";
                    @ViewData["pagetype"] = "companypage";
                    return View(sendd);
                }
               
                
            }


            // if the (if ) statment is not true so it will go into switch statment and there will be no filtring 
            // if the obove if statment is true, it will never reach here at this point, because the fuction will return a view before reaching here

            switch (sortOrder)
            {
                case "Ascending":
                    {
                        var transactions = _transactionContext.TransactionRecords.Include(m => m.TransactionType).Include(m => m.Company).OrderBy(t => t.Company.Name).ToList();
                        @ViewData["NameSortParm"] = "Ascending";
                        @ViewData["pagetype"] = "Transactionpage";
                        return View(transactions);
                    }
                case "Descending":
                    {
                        var transactions = _transactionContext.TransactionRecords.Include(m => m.TransactionType).Include(m => m.Company).OrderByDescending(m => m.Company.Name).ToList();
                        @ViewData["NameSortParm"] = "Descending";
                        @ViewData["pagetype"] = "Transactionpage";
                        return View(transactions);
                    }
                default:
                    {
                        var transactions = _transactionContext.TransactionRecords.Include(m => m.TransactionType).Include(m => m.Company).OrderBy(m => m.Company.Name).ToList();
                        @ViewData["NameSortParm"] = "Ascending";
                        @ViewData["pagetype"] = "Transactionpage";
                        return View(transactions);
                    }
            }






        }


    }
}
