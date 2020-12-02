using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaxWebsiteProject.Models
{
    public class MovieCategory
    {
        public int Id { get; set; }

        public int FK_MovieId { get; set; }

        public int FK_CategoryID { get; set; }

        //public int MovieCategoryRating_0 { get; set; }

        //public int MovieCategoryRating_1 { get; set; }

        //public int MovieCategoryRating_2 { get; set; }

        //public int MovieCategoryRating_3 { get; set; }

        //public int MovieCategoryRating_4 { get; set; }

        //public int MovieCategoryRating_5 { get; set; }

        //public int MovieCategoryRatCount { get; set; }

        //public List<Category> CategoryStuff { get; set; }
    }
}
