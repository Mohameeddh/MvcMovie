using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }
            context.Movies.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    Description = "En man på äventyr",
                    Genre = "Romantic Comedy",
                    Length = TimeSpan.FromMinutes(105),
                    Rating = "R",
                    Price = 7.99M,
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    Description = "En man som cyklar genom livet",
                    Length = TimeSpan.FromMinutes(69),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    Description = "Många spöken",
                    Length = TimeSpan.FromMinutes(209),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    Description = "En man som älskar kärleken",
                    Length = TimeSpan.FromMinutes(155),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}
