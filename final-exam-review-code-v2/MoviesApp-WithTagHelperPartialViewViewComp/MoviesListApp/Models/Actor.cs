using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesListApp.Models
{
    public class Actor
    {
        // PK
        public int ActorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // a nav prop:
        public ICollection<Casting> Castings { get; set; }
    }
}
