﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesListApp.Models
{
    /// <summary>
    /// A class of data objects that represent the basic properties of a Movie.
    /// Using EF (Entity Framework) this will correspond to a table in the database.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// This will corresppnd to the primary key in the DB table
        /// And, because it is an int, it will be auto-generated by MS SQL svr
        /// </summary>
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Movie name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1850, int.MaxValue, ErrorMessage = "Year must be an integer greater than 1850.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be an integer between 1 and 5.")]
        public int? Rating { get; set; }

        // Here we want to add a Foreign Key (FK) relationship with Genre
        // objects. We do that by adding 2 fields, first an Id field that
        // defines the FK via the PK in the Genre table..
        [Required(ErrorMessage = "Please enter a genre")]
        public string GenreId { get; set; }

        // And we add a reference to a full Genre object:
        public Genre Genre { get; set; }

        // a nav prop:
        public ICollection<Casting> Castings { get; set; }
    }
}
