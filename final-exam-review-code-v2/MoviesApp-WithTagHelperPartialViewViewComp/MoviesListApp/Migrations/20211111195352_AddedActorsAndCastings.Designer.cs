﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesListApp.Models;

namespace MoviesListApp.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20211111195352_AddedActorsAndCastings")]
    partial class AddedActorsAndCastings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesListApp.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            FirstName = "Humphrey",
                            LastName = "Bogart"
                        },
                        new
                        {
                            ActorId = 2,
                            FirstName = "Ingrid",
                            LastName = "Bergman"
                        },
                        new
                        {
                            ActorId = 3,
                            FirstName = "Keanu",
                            LastName = "Reeves"
                        },
                        new
                        {
                            ActorId = 4,
                            FirstName = "Carrie-Anne",
                            LastName = "Moss"
                        },
                        new
                        {
                            ActorId = 5,
                            FirstName = "John",
                            LastName = "Travolta"
                        },
                        new
                        {
                            ActorId = 6,
                            FirstName = "Uma",
                            LastName = "Thurman"
                        });
                });

            modelBuilder.Entity("MoviesListApp.Models.Casting", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("Castings");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            MovieId = 1,
                            Role = "Rick Blaine"
                        },
                        new
                        {
                            ActorId = 2,
                            MovieId = 1,
                            Role = "Ilsa Lund"
                        },
                        new
                        {
                            ActorId = 3,
                            MovieId = 2,
                            Role = "Neo"
                        },
                        new
                        {
                            ActorId = 4,
                            MovieId = 2,
                            Role = "Trinity"
                        },
                        new
                        {
                            ActorId = 5,
                            MovieId = 3,
                            Role = "Vincet Vega"
                        },
                        new
                        {
                            ActorId = 6,
                            MovieId = 3,
                            Role = "Mia Wallace"
                        });
                });

            modelBuilder.Entity("MoviesListApp.Models.Genre", b =>
                {
                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = "A",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = "C",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = "D",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = "H",
                            Name = "Horror"
                        },
                        new
                        {
                            GenreId = "M",
                            Name = "Musical"
                        },
                        new
                        {
                            GenreId = "R",
                            Name = "RomCom"
                        },
                        new
                        {
                            GenreId = "S",
                            Name = "SciFi"
                        });
                });

            modelBuilder.Entity("MoviesListApp.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            GenreId = "D",
                            Name = "Casablanca",
                            Rating = 4,
                            Year = 1942
                        },
                        new
                        {
                            MovieId = 2,
                            GenreId = "S",
                            Name = "The Matrix",
                            Rating = 5,
                            Year = 1985
                        },
                        new
                        {
                            MovieId = 3,
                            GenreId = "A",
                            Name = "Pulp Fiction",
                            Rating = 5,
                            Year = 1992
                        });
                });

            modelBuilder.Entity("MoviesListApp.Models.Casting", b =>
                {
                    b.HasOne("MoviesListApp.Models.Actor", "Actor")
                        .WithMany("Castings")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesListApp.Models.Movie", "Movie")
                        .WithMany("Castings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesListApp.Models.Movie", b =>
                {
                    b.HasOne("MoviesListApp.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MoviesListApp.Models.Actor", b =>
                {
                    b.Navigation("Castings");
                });

            modelBuilder.Entity("MoviesListApp.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MoviesListApp.Models.Movie", b =>
                {
                    b.Navigation("Castings");
                });
#pragma warning restore 612, 618
        }
    }
}
