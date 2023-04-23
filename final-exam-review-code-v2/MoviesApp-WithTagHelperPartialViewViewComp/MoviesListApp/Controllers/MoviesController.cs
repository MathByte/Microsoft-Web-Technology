using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MoviesListApp.Models;

namespace MoviesListApp.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            // Getting all the movies from the DB abd storing the results in 
            // a List<Movie> object
            // NOTE: we now have to explicitly say to "include" the full Genre
            // objects when we retrieve movies (in DB this means a join)
            var movies = _movieContext.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();

            // ..and then passing that list object to our view:
            return View(movies);
        }

        [HttpGet("/movies/genre/{genreId}")]
        public IActionResult GetMoviesByGenre(string genreId)
        {
            var activeGenre = _movieContext.Genres.Include(g => g.Movies).Where(g => g.GenreId == genreId).FirstOrDefault();
            var moviesInGenre = activeGenre.Movies;
            return View("MoviesByGenre", new MoviesByGenreViewModel() { Movies = moviesInGenre, ActiveGenreName = activeGenre.Name});
        }

        private MovieContext _movieContext;
    }
}
