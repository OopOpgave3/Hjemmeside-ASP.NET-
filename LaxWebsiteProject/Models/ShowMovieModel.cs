using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaxWebsiteProject.Models
{
    public class ShowMovieModel
    {
        public List<MovieWCategories> Movies { get; set; }
        public List<Movie_Category> MovieCategories { get; set; }

        public List<CategoryCount> Categories { get; set; }

        public SelectList SelectCategories { get; set; }

        public string MovieGenre { get; set; }

        public String SearchString { get; set; }
    }
}
