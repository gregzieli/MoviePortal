using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppReact.Domain.Models;

namespace WebAppReact.Infrastructure.TypeConfigurations
{
    public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseSqlServerIdentityColumn();

            builder.HasOne(x => x.Director).WithMany(x => x.Movies);

            builder.HasMany(x => x.Reviews).WithOne(x => x.Movie);
        }
    }
}
