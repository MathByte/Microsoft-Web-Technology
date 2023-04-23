using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PressYourLuck.Models;
using PressYourLuck.Helpers;






namespace PressYourLuck.Controllers
{

    public class PlayerController : Controller
    {

        private PULContext _pulContext;

        public PlayerController(PULContext pulContext)
        {
            _pulContext = pulContext;
        }


        [HttpGet("/Player")]
        public IActionResult Index()
        {
            TempData["switchtogamemode"] = false;
            return View("Edit");
        }


        [HttpPost()]
        public IActionResult Add(Player Modelplayer)
        {


            if (ModelState.IsValid)
            {
                double total = double.Parse(Modelplayer.TotalCoins);

                //as soon we have player, we create cookie for it
                CoinsHelper.CreatePlayerCookie(this.HttpContext, Modelplayer.Name, total.ToString("N2"));


                /// prepare instance of AUDIT and save it into data base
                Audit record = new Audit()
                {
                    Name = Modelplayer.Name,
                    Date = DateTime.Now,
                    AuditType = new AuditType() { Name = "Cash In" },
                    Ammount = total.ToString("N2")
                };


                //add and save the chnages
                _pulContext.Audits.Add(record);
                _pulContext.SaveChanges();


                TempData["switchtogamemode"] = true;
                TempData["CashOut"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["showResalts"] = false;
                TempData["switchtogamemode"] = false;
                return View("Edit", Modelplayer);
            }

        }


    }
}

