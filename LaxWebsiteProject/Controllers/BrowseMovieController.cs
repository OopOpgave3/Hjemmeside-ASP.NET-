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

            

            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------

            var movies = from m in _context.Movie
                         select m;

            var moviesCateg = from m in _context.MovieCategory
                              select m;

            var categ = from m in _context.Category
                        select m;

            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------



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
            //    item.moviecategories = await moviescateg.tolistasync();
            //}

            //if (!string.isnullorempty(moviegenre))
            //{
            //    movies = movies.where(x => x.genre == moviegenre);
            //}
            //---------------------------
            //if (!string.IsNullOrEmpty(MovieGenre))
            //{
            //    movies = movies.Where(x => x.MovieDirector.Contains("PDgrpewiUBV"));
            //    //movieWCategories = await SortCategories(Genre, movieWCategories);
            //}
            //---------------------------

            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------

            ControllerBase BaseMethod = new ControllerBase();

            var MovieVM = new List<Movie>();
            MovieVM = await movies.ToListAsync();

            var MovieCategoryVM = new List<MovieCategory>();
            MovieCategoryVM = await moviesCateg.ToListAsync();

            var CategoryVM = new List<Category>();
            CategoryVM = await categ.ToListAsync();

            List<MovieWCategories> movieWCategories = new List<MovieWCategories>();

            movieWCategories = await BaseMethod.GetMovies(MovieGenre,MovieVM, MovieCategoryVM, CategoryVM);

            

            

            //--------------------------------------------------------------------------------------------------------------

            //List<MovieWCategories> movieWCategories = new List<MovieWCategories>();

            //foreach (var movieItem in MovieVM)
            //{
            //    string TempCategoriesString = "";
            //    foreach (var movieCategoryItem in MovieCategoryVM)
            //    {
            //        if (movieItem.Id == movieCategoryItem.FK_MovieId) 
            //        {
            //            foreach (var categoryItem in CategoryVM)
            //            {
            //                if (categoryItem.Id == movieCategoryItem.FK_CategoryID) 
            //                {
            //                    TempCategoriesString += categoryItem.CategoryName + " ";
            //                }
            //            }
            //        }

            //    }
            //    MovieWCategories NewMovie = new MovieWCategories
            //    { Id = movieItem.Id,
            //        MovieTitle = movieItem.MovieTitle,
            //        MovieReleaseDate = movieItem.MovieReleaseDate,
            //        MovieDirector = movieItem.MovieDirector,
            //        CategoriesString = TempCategoriesString
            //    };
            //    movieWCategories.Add(NewMovie);
            //}
            //--------------------------------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            //var MovieVM = new List<Movie>();
            //MovieVM = await movies.ToListAsync();

            //var MovieCategoryVM = new List<MovieCategory>();
            //MovieCategoryVM = await moviesCateg.ToListAsync();

            //var CategoryVM = new List<Category>();
            //CategoryVM = await categ.ToListAsync();

            var movieGenreVM = new ShowMovieModel
            {
                SelectCategories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = movieWCategories
                //MovieCategories = await moviesCateg.ToListAsync(),
                //Categories = await categ.ToListAsync()
            };

            //var ShowMovieModel = new ShowMovieModel
            //{
            //    SelectCategories = new SelectList(await genreQuery.Distinct().ToListAsync()),
            //    Movies = MovieGenreVM,
            //    MovieCategories = MovieCategoryVM,
            //    Categories = CategoryVM
            //};

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
