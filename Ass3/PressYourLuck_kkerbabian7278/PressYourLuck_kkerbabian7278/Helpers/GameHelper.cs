
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PressYourLuck.Helpers
{
    public static class GameHelper
    {



        //This creates a collection of 12 tiles with randomly generated values
        public static List<Tile> GenerateNewGame(HttpContext httpContext)
        {

            if (httpContext.Session.GetString("current-game") != null || httpContext.Session.GetString("game") != "")
            {

                var tileList = new List<Tile>();
                Random r = new Random();
                for (int i = 0; i < 12; i++)
                {
                    double randomValue = 0;
                    if (r.Next(1, 4) != 1)
                    {
                        randomValue = (r.NextDouble() + 0.5) * 2;
                    }

                    var tile = new Tile()
                    {
                        TileIndex = i,
                        Visible = false,
                        Value = randomValue.ToString("N2")
                    };

                    tileList.Add(tile);
                }

                string playerJson = JsonConvert.SerializeObject(tileList);
                httpContext.Session.SetString("current-game", playerJson);

                return tileList;
            }
            else
            {

                string listTiles = httpContext.Session.GetString("current-game");
                List<Tile> tiles = JsonConvert.DeserializeObject<List<Tile>>(listTiles);

                return tiles;

            }
        }




        // - GetCurrentGame - If there is no current game state in session Generate a New Game
        // and store it in session, otherwise deserialize the List<Tile> from session
        public static List<Tile> GetCurrentGame(HttpContext httpContext)
        {
            string Json = httpContext.Session.GetString("current-game");
            return GameHelper.DeserializeTileList(httpContext, Json); ;
        }

        // - SaveCurrentGame - Save the current state of the game to session. 
        public static void SaveCurrentGame(HttpContext httpContext, List<Tile> tiles)
        {
            string tilesJson = JsonConvert.SerializeObject(tiles);
            httpContext.Session.SetString("current-game", tilesJson);

        }


        // - ClearCurrentGame - clear the current game state from session
        public static void ClearCurrentGame(HttpContext httpContext)
        {
            List<Tile> tiles = new List<Tile>();
            httpContext.Session.SetString("current-game", GameHelper.SerializeTileList(httpContext, tiles));
        }










        /* - PickATileAndUpdateGame - code that contains the game logic as 
         * mentioned in Part 4 of the assignment. Hint: you'll need to pass in the
         * id of the selected tile as one of the parameters.
         */
        public static double PickTileAndUpdateGame(HttpContext httpContext, string id)
        {

            //we get curent game first and then find the tile and update the visibality
            List<Tile> Tiles = GameHelper.GetCurrentGame(httpContext);
            Tiles[Int32.Parse(id)].Visible = true;



            // do the mu;ipication
            double resault = CoinsHelper.GetCurrentBet(httpContext) * double.Parse(Tiles[Int32.Parse(id)].Value);
            CoinsHelper.SaveCurrentBet(httpContext, resault.ToString("N2"));


            // the result of the flipped card is 0 then make all visible
            if (resault == 0.0)
                foreach (Tile tile in Tiles)
                    tile.Visible = true;


            // very important to save the game and send it back to the user
            GameHelper.SaveCurrentGame(httpContext, Tiles);
            return double.Parse(Tiles[Int32.Parse(id)].Value);
        }






        //- Finally, methods to serialize and deserialzie the Tile list.
        public static string SerializeTileList(HttpContext httpContext, List<Tile> Tiles)
        {
            var result = "";
            result = JsonConvert.SerializeObject(Tiles);
            return result;
        }

        public static List<Tile> DeserializeTileList(HttpContext httpContext, string TilesJson)
        {
            var results = new List<Tile>();
            results = JsonConvert.DeserializeObject<List<Tile>>(TilesJson);
            return results;
        }
    }
}
