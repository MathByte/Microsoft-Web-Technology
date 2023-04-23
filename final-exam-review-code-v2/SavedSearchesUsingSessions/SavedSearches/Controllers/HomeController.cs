using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SavedSearches.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SavedSearches.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // If a cookie "search_key" doesn't yet exist, then let's create
            // it and give it a new GUID value (as a string):
            if (!this.Request.Cookies.ContainsKey("search_key"))
                this.Response.Cookies.Append("search_key", Guid.NewGuid().ToString());

            return View();
        }

        [HttpGet("/search")]
        public IActionResult Search()
        {
            // Get the user's search string from the query string:
            string searchString = this.Request.Query["q"];

            // look up this user's search_key:
            // current search to it search history value:
            string currentSearchKey = this.Request.Cookies["search_key"];

            // And use it to get the current history:
            string currentSearchHistoryValue = this.HttpContext.Session.GetString(currentSearchKey);

            // update the curr search history from the session:
            if (currentSearchHistoryValue == null || currentSearchHistoryValue == "")
                currentSearchHistoryValue = searchString;
            else
                currentSearchHistoryValue += $"|{searchString}";

            // save it to the session:
            this.HttpContext.Session.SetString(currentSearchKey, currentSearchHistoryValue);

            // redirect back to the Home/Index view:
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
