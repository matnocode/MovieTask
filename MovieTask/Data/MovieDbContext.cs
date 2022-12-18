using Microsoft.EntityFrameworkCore;
using MovieTask.Models;

namespace MovieTask.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<MovieModel> movies { get; set; }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) 
        {

        }
    }
}
