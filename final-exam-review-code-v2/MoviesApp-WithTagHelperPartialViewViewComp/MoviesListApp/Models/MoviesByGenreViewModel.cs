using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesListApp.Models
{
    public class MoviesByGenreViewModel
    {
        public ICollection<Movie> Movies { get; set; }

        public string ActiveGenreName { get; set; }
    }
}
