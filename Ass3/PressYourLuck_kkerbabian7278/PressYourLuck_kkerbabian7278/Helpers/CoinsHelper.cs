
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PressYourLuck.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace PressYourLuck.Helpers
{
    public static class CoinsHelper
    {


        //this 2 varialbles will be used every time the user at player page
        // when he is setting up his name and total ammount
        // after when the server will redirect the used current page to bet placement page
        // that moment we cant call request cookies player name  and ammount, because we did not refresh the page yet, we still in the server
        //so setting up cookies and asking cookies while in the server 
        //will accoure an error. the error will be at request cookies.
        private static string _name = "";
        private static string _TotalCoins = "";




        /// <summary>
        /// settting up player vaarialbe and converting it tp Json and then appending the new cookie with it.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="playerName"></param>
        /// <param name="totalCoins"></param>
        public static void CreatePlayerCookie(HttpContext httpContext, string playerName, string totalCoins)
        {
            Player player = new Player
            {
                Name = playerName,
                TotalCoins = totalCoins
            };
            _name = playerName;
            _TotalCoins = totalCoins;
            string playerJson = JsonConvert.SerializeObject(player);
            httpContext.Response.Cookies.Append("Player", playerJson);

        }



        /// <summary>
        /// with try and catch we can know if we still in the server side
        /// because when the code cant get executed during request 
        /// that means we are still in the server side
        /// so we return the _name private variable
        /// other wise, when code gets exicuted, we will ask the cookie value and get it from front end side
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetPlayerName(HttpContext httpContext)
        {
            try
            {

                string currentPlayerhKey = httpContext.Request.Cookies["Player"];
                string currentSessionString = httpContext.Session.GetString(currentPlayerhKey);
                Player player = JsonConvert.DeserializeObject<Player>(currentSessionString);

                return player.Name;
            }
            catch (Exception)
            {

                return _name;
            }
        }

        /// <summary>
        /// delete the cookie from front end side
        /// </summary>
        /// <param name="httpContext"></param>
        public static void DeletePlayerCookie(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete("Player");
        }





        /// <summary>
        /// saving curent bet in session for server related purposese 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="bet"></param>
        public static void SaveCurrentBet(HttpContext httpContext, string bet)
        {
            httpContext.Session.SetString("current-bet", bet);
        }


        //Return the current bet stored in session
        public static double GetCurrentBet(HttpContext httpContext)
        {
            //Code goes here
            return double.Parse(httpContext.Session.GetString("current-bet"));
        }

        //Save the original bet into session
        public static void SaveOriginalBet(HttpContext httpContext, double bet)
        {
            httpContext.Session.SetString("original-bet", bet.ToString("N2"));
        }

        //Get the original bet from session
        public static double GetOriginalBet(HttpContext httpContext)
        {
            return double.Parse(httpContext.Session.GetString("original-bet"));
        }











        /// <summary>
        /// with try and catch we can know if we still in the server side
        /// because when the code cant get executed during request 
        /// that means we are still in the server side
        /// so we return the _totalCoins private variable
        /// other wise, when code gets exicuted, we will ask the cookie value and get it from front end side
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static double GetTotalCoins(HttpContext httpContext)
        {
            try
            {
                string currentPlayerhKey = httpContext.Request.Cookies["Player"];

                Player player = JsonConvert.DeserializeObject<Player>(currentPlayerhKey);

                return double.Parse(player.TotalCoins);
            }
            catch (Exception)
            {

                return double.Parse(_TotalCoins);
            }
        }




        /// <summary>
        /// Update save and return total coins to a cookie 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Update_SaveTotalCoins(HttpContext httpContext, double value)
        {
            string currentPlayerhKey = httpContext.Request.Cookies["Player"];

            Player player = JsonConvert.DeserializeObject<Player>(currentPlayerhKey);

            double totalcoins = double.Parse(player.TotalCoins);

            player.TotalCoins = (totalcoins + value).ToString("N2");

            string playerJson = JsonConvert.SerializeObject(player);

            httpContext.Response.Cookies.Append("Player", playerJson);
            return player.TotalCoins;
        }




    }
}
