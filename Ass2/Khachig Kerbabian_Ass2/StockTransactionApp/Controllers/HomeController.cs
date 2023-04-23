using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockTransactionApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StockTransactionApp.Controllers
{
    public class HomeController : Controller
    {
      

        private TransactionContext _TransactionContext;


        public HomeController(TransactionContext transactionContext)
        {
            _TransactionContext = transactionContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





       
    }
}
