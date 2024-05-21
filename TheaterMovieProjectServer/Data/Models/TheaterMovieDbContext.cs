using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;
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
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Theater> Theaters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Movie>(entity =>
            {
                entity.HasOne(d => d.Theater).WithMany(p => p.Movies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Theater");
            });

            builder.Entity<Theater>(entity =>
            {
                entity.Property(e => e.Name).IsFixedLength();
                entity.Property(e => e.Location).IsFixedLength();
            });
        }


    }
}
