using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaxWebsiteProject.Models
{
    public class Category
    {
        public int PK_CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }
}
