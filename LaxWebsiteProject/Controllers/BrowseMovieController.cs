using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using LaxWebsiteProject.Models;
using LaxWebsiteProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LaxWebsiteProject.Controllers
{
    public class BrowseMovieController : Controller
    {
        private readonly LaxWebsiteProjectContext _context;

        public BrowseMovieController(LaxWebsiteProjectContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Category
                                            orderby m.CategoryName
                                            select m.CategoryName;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieTitle.Contains(searchString));
            }

            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    movies = movies.Where(x => x.Genre == movieGenre);
            //}

            var movieGenreVM = new MovieListViewModel
            {
                Categories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
