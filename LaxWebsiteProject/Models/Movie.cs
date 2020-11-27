using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaxWebsiteProject.Models
{
    public class Movie
    {
        public int PK_MovieId { get; set; }

        public string MovieTitle { get; set; }

        public DateTime MovieReleaseDate { get; set; }

        public string MovieDirector { get; set; }

        public List<MovieCategory> MovieCategories { get; set; }
    }
}
