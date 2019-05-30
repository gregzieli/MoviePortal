using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppReact.Domain.Models;

namespace WebAppReact.Infrastructure.TypeConfigurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        // TODO: make it a query type
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseSqlServerIdentityColumn();

            builder.HasMany(x => x.Reviews).WithOne(x => x.Author);
        }
    }
}
