using Microsoft.EntityFrameworkCore;
using WebAppReact.Domain.Abstractions;
using WebAppReact.Domain.Models;
using WebAppReact.Infrastructure.TypeConfigurations;

namespace WebAppReact.Infrastructure
{
    public class MoviePortalContext : DbContext, IUnitOfWork
    {
        public MoviePortalContext(DbContextOptions<MoviePortalContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActorMovieEntityTypeConfiguration());
        }
    }
}
