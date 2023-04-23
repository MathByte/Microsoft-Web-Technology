using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesListApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesListApp.Controllers
{
    public class HomeController : Controller
    {
        // EF does the magic of passing the movie context to our controller's 
        // constructor...
        public HomeController(MovieContext movieContext)
        {
            //.. all we do is assign it to our private data field:
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        // A temp test action method to test if our DB access is working:
        public IActionResult DbTest()
        {
            // Let's try to access our Movies table in the DB
            // and return a string the contains the name of the 1st movie:
            var movies = _movieContext.Movies.OrderBy(m => m.Name).ToList();
            var firstMovieName = movies[0].Name;
            return Content($"The name of the first movie is {firstMovieName}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // We store the movie context as a private data field:
        private MovieContext _movieContext;
    }
}
