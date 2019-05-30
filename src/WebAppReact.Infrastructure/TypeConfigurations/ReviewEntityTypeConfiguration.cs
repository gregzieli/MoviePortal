using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppReact.Domain.Models;

namespace WebAppReact.Infrastructure.TypeConfigurations
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        // TODO: make it a query type
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseSqlServerIdentityColumn();

            builder.HasOne(x => x.Author).WithMany(x => x.Reviews);

            builder.HasOne(x => x.Movie).WithMany(x => x.Reviews);
        }
    }
}
