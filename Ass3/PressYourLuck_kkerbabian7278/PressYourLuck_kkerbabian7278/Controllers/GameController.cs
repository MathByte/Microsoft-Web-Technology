using Microsoft.AspNetCore.Mvc;
using PressYourLuck.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PressYourLuck.Models;
using Microsoft.AspNetCore.Http;


namespace PressYourLuck.Controllers
{
    public class GameController : Controller
    {

        private PULContext _pulContext;

        public GameController(PULContext pulContext)
        {
            _pulContext = pulContext;
        }



        [HttpPost()]
        public IActionResult Index(string originalBet)
        {
            double Obet = 0;
            //cheecking if original bet is not null and just numbers not chars
            if (originalBet != null && double.TryParse(originalBet, out Obet))
            {
                var tileList = GameHelper.GenerateNewGame(this.HttpContext);
                //we save originalBet in sessions
                CoinsHelper.SaveOriginalBet(this.HttpContext, Obet);
                CoinsHelper.SaveCurrentBet(this.HttpContext, Obet.ToString("N2"));

                ViewBag.showResalts = false;
                ViewBag.busted = false;
                TempData["totalCoins"] = CoinsHelper.Update_SaveTotalCoins(this.HttpContext, -1 * CoinsHelper.GetOriginalBet(this.HttpContext));
                TempData["switchtogamemode"] = true;


                //Saverecords current before senfing it to the user
                GameHelper.SaveCurrentGame(this.HttpContext, tileList);


                return View(tileList);

            }
            else
            {

                //if it is not coorect redirect to the bet page 
                TempData["switchtogamemode"] = false;
                TempData["CashOut"] = false;
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpGet("/Game/{id?}")]
        public IActionResult PickTileUpdate(string id)
        {
            ViewBag.multiplierValue = GameHelper.PickTileAndUpdateGame(this.HttpContext, id);
            ViewBag.showResalts = true;

            if (ViewBag.multiplierValue == 0.0)
                ViewBag.busted = true;
            else
                ViewBag.busted = false;

            TempData["totalCoins"] = CoinsHelper.GetTotalCoins(this.HttpContext).ToString("N2");
            TempData["switchtogamemode"] = true;
            return View("Index", GameHelper.GetCurrentGame(this.HttpContext));
        }


        [HttpGet("/Game/TryAgain/{status?}")]
        public IActionResult TryAgainOrTakeout(string status)
        {

            if (status == "takeout")
            {
                CoinsHelper.Update_SaveTotalCoins(this.HttpContext, CoinsHelper.GetCurrentBet(this.HttpContext));


                /// prepare instance of AUDIT and save it into data base
                Audit record = new Audit()
                {
                    Name = CoinsHelper.GetPlayerName(this.HttpContext),
                    Date = DateTime.Now,
                    AuditType = new AuditType() { Name = "Win" },
                    Ammount = CoinsHelper.GetCurrentBet(this.HttpContext).ToString("N2")
                };


                //add and save the chnages
                _pulContext.Audits.Add(record);
                _pulContext.SaveChanges();





                TempData["CashOut"] = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                /// prepare instance of AUDIT and save it into data base
                Audit record = new Audit()
                {
                    Name = CoinsHelper.GetPlayerName(this.HttpContext),
                    Date = DateTime.Now,
                    AuditType = new AuditType() { Name = "Lose" },
                    Ammount = CoinsHelper.GetOriginalBet(this.HttpContext).ToString("N2")
                };


                //add and save the chnages
                _pulContext.Audits.Add(record);
                _pulContext.SaveChanges();




                TempData["CashOut"] = false;
                return RedirectToAction("Index", "Home");
            }

        }



        [HttpGet("/Game/cashOut")]
        public IActionResult cashOut()
        {
            TempData["totalCoins"] = CoinsHelper.GetTotalCoins(this.HttpContext).ToString("N2");
            TempData["Title"] = "Welcome to Press Your Luck!";
            TempData["showResalts"] = true;
            ViewData["CashOut"] = true;

            GameHelper.ClearCurrentGame(this.HttpContext);
            CoinsHelper.DeletePlayerCookie(this.HttpContext);


            /// prepare instance of AUDIT and save it into data base
            Audit record = new Audit()
            {
                Name = CoinsHelper.GetPlayerName(this.HttpContext),
                Date = DateTime.Now,
                AuditType = new AuditType() { Name = "Cash Out" },
                Ammount = CoinsHelper.GetTotalCoins(this.HttpContext).ToString("N2")
            };


            //add and save the chnages
            _pulContext.Audits.Add(record);
            _pulContext.SaveChanges();






            return RedirectToAction("Index", "Player");

        }



    }
}
