using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class NewMovieContext : DbContext
    {
        //call the setup options
        public NewMovieContext (DbContextOptions<NewMovieContext> options) : base(options)
        {
            //leave blank for now
        }
        // get and set the responses that are brough in by the movie response model
        public DbSet<MovieResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category { CategoryID=1, CategoryName= "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }

               
            );
        }
    }
}
