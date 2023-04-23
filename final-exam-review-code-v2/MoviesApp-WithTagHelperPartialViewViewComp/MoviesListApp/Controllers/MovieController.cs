using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MoviesListApp.Models;

namespace MoviesListApp.Controllers
{
    public class MovieController : Controller
    {
        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpGet("/movie/{movieId}/actors")]
        public IActionResult GetActorsInMovie(int movieId)
        {
            // Get the movie by ID:
            var movie = _movieContext.Movies.Include(m => m.Castings).ThenInclude(c => c.Actor).Where(m => m.MovieId == movieId).FirstOrDefault();

            // Return a view by name:
            return View("ActorsInMovie", movie);
        }

        // GET & POST action methods/handlers for the "Add" sub/request resource
        [HttpGet()]
        public IActionResult Add()
        {
            // First set the action to be "Add"
            ViewData["Action"] = "Add";

            // Add the genres to the viewbag:
            // NOW, instead of a dyanmic prop "Genres" we stoe the list of Genres
            // in the ViewData dictionary  keyed by the word Genres:
            ViewData["Genres"] = _movieContext.Genres.OrderBy(g => g.Name).ToList();

            // Return the Movie/Edit view with a blank/new movie object as the model:
            // NOTE: we need to name the view explicitly because our action/method name
            // is Add, not edit
            return View("Edit", new Movie());
        }

        // ASP.NET Core MVC serializes the incoming form data in the
        // POST request into a Movie object for us
        [HttpPost()]
        public IActionResult Add(Movie newMovie)
        {
            // we first check to see if the move data sent is valid...
            if (ModelState.IsValid)
            {
                // since valid, we want to add it our DB:
                _movieContext.Movies.Add(newMovie);
                _movieContext.SaveChanges();

                this.TempData["LastActionMessage"] = $"The movie \"{newMovie.Name}\" (year: {newMovie.Year}) was added";


                // redirect back to the all movies page:
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                // invalid so just send the movie back with validation warnings
                ViewData["Action"] = "Add";
                ViewData["Genres"] = _movieContext.Genres.OrderBy(g => g.Name).ToList();
                return View("Edit", newMovie);
            }
        }

        // GET & POST action methods/handlers for the "Edit" sub/request resource
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            // First set the action to be "Edit"
            ViewData["Action"] = "Edit";

            // Add the genres to the viewbag:
            ViewData["Genres"] = _movieContext.Genres.OrderBy(g => g.Name).ToList();

            // First lookup/retrieve the movie by id:
            var movie = _movieContext.Movies.Find(id);

            // and then pass that movie to the view
            return View(movie);
        }

        // ASP.NET Core MVC serializes the incoming form data in the
        // POST request into a Movie object for us
        [HttpPost()]
        public IActionResult Edit(Movie movie)
        {
            // we first check to see if the move data sent is valid...
            if (ModelState.IsValid)
            {
                // since valid, we want to update in our DB:
                _movieContext.Movies.Update(movie);
                _movieContext.SaveChanges();

                this.TempData["LastActionMessage"] = $"The movie \"{movie.Name}\" (year: {movie.Year}) was updated";

                // redirect back to the all movies page:
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                // invalid so just send the movie back with validation warnings
                ViewData["Action"] = "Edit";
                ViewData["Genres"] = _movieContext.Genres.OrderBy(g => g.Name).ToList();
                return View(movie);
            }
        }

        // GET & POST action methods/handlers for the "Delete" sub/request resource
        [HttpGet()]
        public IActionResult Delete(int id)
        {
            // First lookup/retrieve the movie by id:
            var movie = _movieContext.Movies.Find(id);

            // and then pass that movie to the view
            return View(movie);
        }

        // ASP.NET Core MVC serializes the incoming form data in the
        // POST request into a Movie object for us
        [HttpPost("/Movie/Delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            // first get the movie by ID:
            var movie = _movieContext.Movies.Find(id);

            // then delete it:
            _movieContext.Movies.Remove(movie);
            _movieContext.SaveChanges();

            // and use its props for a last action message:
            this.TempData["LastActionMessage"] = $"The movie \"{movie.Name}\" (year: {movie.Year}) was deleted";

            // redirect back to the all movies page:
            return RedirectToAction("Index", "Movies");
        }

        private MovieContext _movieContext;
    }
}
