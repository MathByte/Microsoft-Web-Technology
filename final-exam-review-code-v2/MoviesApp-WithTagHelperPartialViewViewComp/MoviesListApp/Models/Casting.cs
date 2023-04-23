using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesListApp.Models
{
    public class Casting
    {
        // composite PK (configure that in OnModelCreating)
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public string Role { get; set; }

        // navigation props:
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
