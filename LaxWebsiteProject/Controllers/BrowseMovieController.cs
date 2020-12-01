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
            //Use LINQ to get list of genres.
           IQueryable<string> genreQuery = from m in _context.Category
                                           orderby m.CategoryName
                                           select m.CategoryName;
            var movies = from m in _context.Movie
                         select m;

            var moviesCateg = from m in _context.MovieCategory
                              select m;

            var categ = from m in _context.Category
                        select m;





            //IQueryable<string> genreQuery = from m in _context.Category
            //                                orderby m.CategoryName
            //                                select m.CategoryName;



            //var moviesCateg = from m in _context.MovieCategory
            //                  join category in _context.Category on m.FK_Category equals category.Id into myNewTable2
            //                  from subtable in myNewTable2.DefaultIfEmpty()
            //                  select m;

            //var movies = from a in _context.Movie
            //             join category in _context.MovieCategory on a.Id equals category.FK_MovieId into myNewTable
            //             from subtable in myNewTable.DefaultIfEmpty()
            //             select a;

            //var categ = from m in _context.Category
            //            select m;





            //foreach (var item in movies)
            //{

            //}
            //var MovieTest1 = new Movie
            //{
            //    MovieCategories = 
            //};


            //List<MovieCategory> MovieCategList = new List<MovieCategory>();
            //List<Category> CategList = new List<Category>();

            //foreach (var item in movies)
            //{
            //    var moviesCateg = from m in _context.MovieCategory
            //                      select m;

            //    moviesCateg = moviesCateg.Where(x => x.FK_MovieId == item.Id);

            //    item.MovieCategories = await moviesCateg.ToListAsync();

            //}

            //foreach (var item in movies)
            //{
            //    var categ = from m in _context.Category
            //                select m;

            //    foreach (var categItem in item.MovieCategories)
            //    {
            //        categ = categ.Where(x => x.Id == categItem.FK_Category);

            //        categItem.CategoryStuff = await categ.ToListAsync();

            //    };



            //}

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieTitle.Contains(searchString));
            }
            //foreach (var item in movies)
            //{
            //    item.MovieCategories = await moviesCateg.ToListAsync();
            //}

            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    movies = movies.Where(x => x.Genre == movieGenre);
            //}


            var movieGenreVM = new MovieListViewModel
            {
                Categories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync(),
                //MovieCategories = await moviesCateg.ToListAsync(),
                //Categories = await categ.ToListAsync()
            };

            return View(movieGenreVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private async Task<IActionResult> MovieCategoriesGet(IQueryable<Movie> Movie) 
        //{
        //    var moviesCateg = from m in _context.MovieCategory
        //                      select m;


        //}
    }
}
