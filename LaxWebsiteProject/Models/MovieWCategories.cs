using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaxWebsiteProject.Models
{
    public class MovieWCategories
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Release_date { get; set; }

        public string Categories_string { get; set; }

        public string Director { get; set; }
    }
}
