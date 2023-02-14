using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class NewMovieContext : DbContext
    {
        public NewMovieContext (DbContextOptions<NewMovieContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<MovieResponse> responses { get; set; }
    }
}
