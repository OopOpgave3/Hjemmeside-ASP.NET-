﻿using Microsoft.EntityFrameworkCore;
using LaxWebsiteProject.Models;

namespace LaxWebsiteProject.Data
{
    public class LaxWebsiteProjectContext : DbContext
    {
        public LaxWebsiteProjectContext(DbContextOptions<LaxWebsiteProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<Movie_Category> MovieCategory { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Director> Director { get; set; }
    }
}
