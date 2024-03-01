using Microsoft.EntityFrameworkCore;
using RazorPageMovie2.Data;

using System.ComponentModel.DataAnnotations;


namespace RazorPageMovie2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovie2Context(
            serviceProvider.GetRequiredService<
            DbContextOptions<RazorPageMovie2Context>>()))
            {
                if (context == null || context.Movie == null) //si contexto es nulo y el contexto de movie es nulo ponemos un throw
                { 
                throw new ArgumentException("Null Razor Page Movie Context");
                }
                //Para mirar cualquier pelicula 
                if (context.Movie.Any())
                {
                    return;//la base de datos muestra todo lo que contiene la clase 
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Meet Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating="R"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "Rio Bravo ",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
