using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Models;

namespace MVCWebApp.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<MVCWebApp.Models.Movie>? Movie { get; set; }

        public DbSet<MVCWebApp.Models.MovieCustomerComments>? MovieCustomerComments { get; set; }
    }
}
