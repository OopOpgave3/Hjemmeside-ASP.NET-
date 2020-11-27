using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaxWebsiteProject.Models
{
    public class MovieListViewModel
    {
        public List<Movie> Movies { get; set; }

        public SelectList Categories { get; set; }

        public string Genre { get; set; }

        public String SearchString { get; set; }
    }
}
