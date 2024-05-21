using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace TheaterMovieProjectServer.Data.Models
{
    public class TheaterMovieDbContext: DbContext

    {
        public TheaterMovieDbContext() : base()
        {
            
        }
        public TheaterMovieDbContext(DbContextOptions options): base(options) 
        { 
        }
        public DbSet<Movie> Movies => Set <Movie>();
        public DbSet<Theater> Theaters => Set <Theater>();

       
    }
}
