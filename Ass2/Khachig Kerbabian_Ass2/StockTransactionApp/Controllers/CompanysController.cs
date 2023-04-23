using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTransactionApp.Models;
using Microsoft.EntityFrameworkCore;


namespace StockTransactionApp.Controllers
{
    public class CompanysController : Controller
    {


        private TransactionContext _transactionContext;

        public CompanysController(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }


        public IActionResult Index()
        {

            TempData["PageName"] = "Companies List";
            var compnays = _transactionContext.Companys.OrderBy(m => m.CompanyId).ToList();
       
            return View(compnays);
        
        }

    }
}
