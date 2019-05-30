using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppReact.Domain.Models;

namespace WebAppReact.Infrastructure.TypeConfigurations
{
    public class DirectorEntityTypeConfiguration : IEntityTypeConfiguration<Director>
    {
        // TODO: make it a query type
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseSqlServerIdentityColumn();

            builder.HasMany(x => x.Movies).WithOne(x => x.Director);
        }
    }
}
