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
        public async Task<IActionResult> Index(string MovieGenre, string searchString)
        {
            //Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Category
                                            orderby m.CategoryName
                                            select m.CategoryName;
            ControllerBase BaseMethod = new ControllerBase(_context);

            List<MovieWCategories> movieWCategories = new List<MovieWCategories>();

            movieWCategories = await BaseMethod.JoinMovies(MovieGenre, searchString, false);

            var movieGenreVM = new ShowMovieModel
            {
                SelectCategories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = movieWCategories
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
