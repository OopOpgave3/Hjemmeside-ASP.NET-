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

            //--------------------------------------------------------------------------------------------------------------


            ControllerBase BaseMethod = new ControllerBase();

            var MovieVM = new List<Movie>();
            MovieVM = await movies.ToListAsync();

            var moviesCateg = from m in _context.MovieCategory
                              select m;

            var categ = from m in _context.Category
                        select m;

            var MovieCategoryVM = new List<MovieCategory>();
            MovieCategoryVM = await moviesCateg.ToListAsync();

            var CategoryVM = new List<Category>();
            CategoryVM = await categ.ToListAsync();

            List<MovieWCategories> movieWCategories = new List<MovieWCategories>();

            movieWCategories = await BaseMethod.GetMovies(null,MovieVM, MovieCategoryVM, CategoryVM);

            //--------------------------------------------------------------------------------------------------------------

            List<CategoryCount> CategoryCounts = new List<CategoryCount>();
            CategoryCounts = await BaseMethod.NumberOfCategories(MovieCategoryVM, CategoryVM);

            List<CategoryCount> CountFinal = new List<CategoryCount>();

            for (int i = 0; i < 6; i++)
            {
                //if(is)
                //{

                //}
            }

            var movieGenreVM = new ShowMovieModel
            {
                Movies = movieWCategories,
                Categories = CategoryCounts
                //MovieCategories = await moviesCateg.ToListAsync(),
                //Categories = await categ.ToListAsync()
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
