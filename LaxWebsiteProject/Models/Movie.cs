using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaxWebsiteProject.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string MovieTitle { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime MovieReleaseDate { get; set; }

        public string MovieDirector { get; set; }

        //public List<MovieCategory> MovieCategories { get; set; }

        //public List<Category> CategoriesList { get; set; }
    }
}
