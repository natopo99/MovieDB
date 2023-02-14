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
    }
}
