using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaxWebsiteProject.Models
{
    public class ShowMovieModel
    {

        public SelectList SelectCategories { get; set; }

        public List<Movie> Movies { get; set; }

        public List<MovieCategory> MovieCategories { get; set; }

        public List<Category> Categories { get; set; }

        public String SearchString { get; set; }
    }
}
