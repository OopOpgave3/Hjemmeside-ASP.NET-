using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LaxWebsiteProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaxWebsiteProject.Data;

namespace LaxWebsiteProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly LaxWebsiteProjectContext _context;

        public HomeController(LaxWebsiteProjectContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var movies = from m in _context.Movie
                         orderby m.MovieReleaseDate descending
                         select m;

            var movieGenreVM = new MovieListViewModel
            {
                Movies = await movies.ToListAsync()
            };

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
