using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Data;
using System.Diagnostics;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly MvcMovieContext _logger;

        public HomeController(MvcMovieContext logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            if (_logger.Movies == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _logger.Movies
            orderby m.Genre
                                            select m.Genre;
            var movies = from m in _logger.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            if (!movieGenreVM.Movies.Any())
            {
                Console.WriteLine("Ingen film hittades.");
            }

            return View(movieGenreVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
