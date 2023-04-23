using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PressYourLuck.Helpers;


namespace PressYourLuck.Controllers
{
    public class HomeController : Controller
    {
        private PULContext _pulContext;

        public HomeController(PULContext pulContext)
        {
            _pulContext = pulContext;
        }





        [HttpGet()]
        public IActionResult Index()
        {

            //very important to check first if the front end has cookie or not
            // so we can know where to direct
            if (!this.Request.Cookies.ContainsKey("Player"))
            {
                TempData["Title"] = "Welcome to Press Your Luck!";
                TempData["switchtogamemode"] = false;
                TempData["showResalts"] = false;
                return RedirectToAction("Index", "Player");
            }
            else
            {
                ViewData["Title"] = "Welcome, " + CoinsHelper.GetPlayerName(this.HttpContext) + " !";
                TempData["totalCoins"] = CoinsHelper.GetTotalCoins(this.HttpContext).ToString("N2");
                ViewData["showResalts"] = true;
                TempData["CashOut"] = false;
                TempData["switchtogamemode"] = true;
                return View("Index", "Home");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }



}
