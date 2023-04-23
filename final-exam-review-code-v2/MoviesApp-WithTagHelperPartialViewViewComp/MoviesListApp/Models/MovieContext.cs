using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesListApp.Models
{
    /// <summary>
    /// This class defines the way we interact with the DB by inheriting
    /// from EF's DbContext class
    /// </summary>
    public class MovieContext : DbContext
    {
        /// <summary>
        /// Here we define the constructor that passes the required options 
        /// param up to the base class constructor.
        /// </summary>
        public MovieContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// This property is how we access all the movies in the Movie
        /// table in the DB from our code; i.e. DbSet<Movie> represents
        /// the result set from the DB query
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// A way of accessing the Genres table in the DB
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Casting> Castings { get; set; }

        /// <summary>
        /// This is where we can do some DB initialization, e.g. seed it with
        /// some data - e.g. 3 movies.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // setup the composite key in Castings:
            modelBuilder.Entity<Casting>().HasKey(c => new { c.ActorId, c.MovieId});

            // setup 1-to-many between movie & casting:
            modelBuilder.Entity<Casting>().HasOne(c => c.Movie).WithMany(m => m.Castings).HasForeignKey(c => c.MovieId);

            // setup 1-to-many between actor & casting:
            modelBuilder.Entity<Casting>().HasOne(c => c.Actor).WithMany(m => m.Castings).HasForeignKey(c => c.ActorId);

            // Add our genres data:
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = "A", Name = "Action"},
                new Genre() { GenreId = "C", Name = "Comedy" },
                new Genre() { GenreId = "D", Name = "Drama" },
                new Genre() { GenreId = "H", Name = "Horror" },
                new Genre() { GenreId = "M", Name = "Musical" },
                new Genre() { GenreId = "R", Name = "RomCom" },
                new Genre() { GenreId = "S", Name = "SciFi" }
                );

            // seed some actors:
            modelBuilder.Entity<Actor>().HasData(
                new Actor() { ActorId = 1, FirstName = "Humphrey", LastName = "Bogart"},
                new Actor() { ActorId = 2, FirstName = "Ingrid", LastName = "Bergman" },
                new Actor() { ActorId = 3, FirstName = "Keanu", LastName = "Reeves" },
                new Actor() { ActorId = 4, FirstName = "Carrie-Anne", LastName = "Moss" },
                new Actor() { ActorId = 5, FirstName = "John", LastName = "Travolta" },
                new Actor() { ActorId = 6, FirstName = "Uma", LastName = "Thurman" }
                );

            // Add 3 movies, including a ref to a genre for each one:
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    MovieId = 1,
                    Name = "Casablanca",
                    Year = 1942,
                    Rating = 4,
                    GenreId = "D"
                },
                new Movie()
                {
                    MovieId = 2,
                    Name = "The Matrix",
                    Year = 1985,
                    Rating = 5,
                    GenreId = "S"
                },
                new Movie()
                {
                    MovieId = 3,
                    Name = "Pulp Fiction",
                    Year = 1992,
                    Rating = 5,
                    GenreId = "A"
                }
                );

            // seed some castings:
            modelBuilder.Entity<Casting>().HasData(
                new Casting() { MovieId = 1, ActorId = 1, Role = "Rick Blaine"},
                new Casting() { MovieId = 1, ActorId = 2, Role = "Ilsa Lund" },
                new Casting() { MovieId = 2, ActorId = 3, Role = "Neo" },
                new Casting() { MovieId = 2, ActorId = 4, Role = "Trinity" },
                new Casting() { MovieId = 3, ActorId = 5, Role = "Vincet Vega" },
                new Casting() { MovieId = 3, ActorId = 6, Role = "Mia Wallace" }
                );
        }
    }
}
