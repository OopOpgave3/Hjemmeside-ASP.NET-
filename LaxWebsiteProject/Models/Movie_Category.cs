using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaxWebsiteProject.Models
{
    public class Movie_Category
    {
        public int Id { get; set; }

        public int FK_MovieID { get; set; }

        public int FK_CategoryID { get; set; }
    }
}
