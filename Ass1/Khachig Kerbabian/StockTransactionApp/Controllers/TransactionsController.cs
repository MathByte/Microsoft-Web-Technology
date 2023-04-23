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
        public IActionResult Index()
        {
            // Here we get all the transaction from the DB as a list but this time we add
            // an in Include call to make sure that the query also does a full join
            // and gets all the transaction data as well; i.e. each transaction object returned \
            // now also has its full transaction object property..
            var transactions = _transactionContext.Transactions.Include(m => m.TransactionType).OrderBy(m => m.TransactionId).ToList();
            return View(transactions);
        }
    }
}
