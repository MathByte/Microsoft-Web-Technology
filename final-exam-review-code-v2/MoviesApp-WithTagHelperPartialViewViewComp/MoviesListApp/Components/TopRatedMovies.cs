using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MoviesListApp.Models;

namespace MoviesListApp.Components
{
    public class TopRatedMovies : ViewComponent
    {
        public TopRatedMovies(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        /// <summary>
        /// Our invoke method uses the 2 params to show at most numberOfMoviesToDisplay movies
        /// in a list of movies whose rating is at least as high as lowestRating
        /// </summary>
        public IViewComponentResult Invoke(int lowestRating, int numberOfMoviesToDisplay)
        {
            // Get our top rated movies from the DB:
            var movies = _movieContext.Movies.Include(m => m.Genre).Where(m => m.Rating >= lowestRating).OrderBy(m => m.Name).ToList();
            var viewModel = new TopRatedMoviesViewModel() { Movies = movies, LowestRating = lowestRating, NumberOfMoviesToDisplay = Math.Min(movies.Count, numberOfMoviesToDisplay) };
            return View(viewModel);
        }

        private MovieContext _movieContext;
    }
}
