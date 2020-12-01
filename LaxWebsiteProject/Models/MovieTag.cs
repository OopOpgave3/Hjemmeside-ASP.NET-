using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaxWebsiteProject.Models
{
    public class MovieTag
    {
        public int Id { get; set; }

        public int FK_MovieId { get; set; }

        public int FK_TagID { get; set; }
    }
}
