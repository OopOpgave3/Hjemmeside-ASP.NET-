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
    public class ControllerBase : Controller
    {
        private readonly LaxWebsiteProjectContext _context;

        public ControllerBase(LaxWebsiteProjectContext context)
        {
            _context = context;
        }
        public async Task<List<MovieWCategories>> GetMovies(string Genre, List<Movie> Movie, List<Movie_Category> MovieCategory, List<Category> Category) 
        {

            List<MovieWCategories> movieWCategories = new List<MovieWCategories>();

            foreach (var movieItem in Movie)
            {
                string TempCategoriesString = "";
                foreach (var movieCategoryItem in MovieCategory)
                {
                    if (movieItem.Id == movieCategoryItem.FK_MovieID)
                    {
                        foreach (var categoryItem in Category)
                        {
                            if (categoryItem.Id == movieCategoryItem.FK_CategoryID)
                            {
                                TempCategoriesString += categoryItem.CategoryName + " ";
                            }
                        }
                    }

                }
                MovieWCategories NewMovie = new MovieWCategories
                {
                    Id = movieItem.Id,
                    Title = movieItem.MovieTitle,
                    Release_date = movieItem.MovieReleaseDate,
                    Director = movieItem.MovieDirector,
                    Categories_string = TempCategoriesString,
                    
                };
                movieWCategories.Add(NewMovie);
            }
            if (!string.IsNullOrEmpty(Genre))
            {
                movieWCategories = await SortCategories(Genre, movieWCategories);
            }

            return movieWCategories;
        }
        public async Task<List<MovieWCategories>> SortCategories(string Genre, List<MovieWCategories> CategoriesList)
        {
            List<MovieWCategories> ReturnList = new List<MovieWCategories>();
            foreach (var item in CategoriesList)
            {
                if (item.Categories_string.Contains(Genre))
                {
                    ReturnList.Add(item);
                }
            }
            return ReturnList;
        }



        public async Task<List<CategoryCount>> NumberOfCategories(List<Movie_Category> MovieCategoryVM, List<Category> CategoryVM) 
        {
            List<CategoryCount> CategoryCountList = new List<CategoryCount>();
            foreach (var category in CategoryVM)
            {
                CategoryCount Counter = new CategoryCount();
                int CountInt = 0;
                foreach (var movieCategory in MovieCategoryVM)
                {
                    if (category.Id == movieCategory.FK_CategoryID)
                    {
                        CountInt++;
                    }
                }

                Counter.Name = category.CategoryName;
                Counter.Count = CountInt;
                CategoryCountList.Add(Counter);

            }
            IEnumerable<CategoryCount> SortedList = CategoryCountList.OrderByDescending(CategoryCount => CategoryCount.Count);

            List<CategoryCount> FinalList = new List<CategoryCount>();
            foreach (var item in SortedList)
            {
                FinalList.Add(item);
            }

            return FinalList;
        }
        public async Task<List<MovieWCategories>> JoinMovies(string Genre, string SearchString, bool MovieOrderBy)
        {
            var movies = from m in _context.Movie
                         select m;

            var moviesCateg = from m in _context.MovieCategory
                              select m;

            var categ = from m in _context.Category
                        select m;

            
            
            if (MovieOrderBy)
            {
                movies = await GetNewestAdded();
                
            }
            else
            {
                movies = await GetNewestRelease();
            }

            

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.MovieTitle.Contains(SearchString));

            }
            var MovieVM = new List<Movie>();
            MovieVM = await movies.ToListAsync();



            var MovieCategoryVM = new List<Movie_Category>();
            MovieCategoryVM = await moviesCateg.ToListAsync();

            var CategoryVM = new List<Category>();
            CategoryVM = await categ.ToListAsync();

            List<MovieWCategories> movieWCategories = new List<MovieWCategories>();

            movieWCategories = await GetMovies(Genre, MovieVM, MovieCategoryVM, CategoryVM);
            return movieWCategories;

        }
        public async Task<IQueryable<Movie>> GetNewestAdded()
        {
            
            var movies = from m in _context.Movie
                         orderby m.Id descending
                         select m;

            List<Movie> MovieList = new List<Movie>();
            MovieList = await movies.ToListAsync();
            return movies;

        }
        public async Task<IQueryable<Movie>> GetNewestRelease()
        {

            var movies = from m in _context.Movie
                         orderby m.MovieReleaseDate descending
                         select m;

            List<Movie> MovieList = new List<Movie>();
            MovieList = await movies.ToListAsync();
            return movies;

        }
    }
}
