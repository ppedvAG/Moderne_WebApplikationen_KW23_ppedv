using Microsoft.EntityFrameworkCore;
using MovieAPIService.Models;

namespace MovieAPIService.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieAPIService.Models.MovieCustomerComments> MovieCustomerComments { get; set; }
    }
}
