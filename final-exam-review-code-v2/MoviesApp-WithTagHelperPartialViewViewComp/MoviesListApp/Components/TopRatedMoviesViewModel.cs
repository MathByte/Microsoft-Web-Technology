using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MoviesListApp.Models;

namespace MoviesListApp.Components
{
    public class TopRatedMoviesViewModel
    {
        public List<Movie> Movies { get; set; }

        public int LowestRating { get; set; }

        public int NumberOfMoviesToDisplay { get; set; }
    }
}
