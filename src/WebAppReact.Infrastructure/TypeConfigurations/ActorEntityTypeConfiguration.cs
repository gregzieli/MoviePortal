using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppReact.Domain.Models;

namespace WebAppReact.Infrastructure.TypeConfigurations
{
    public class ActorEntityTypeConfiguration : IEntityTypeConfiguration<Actor>
    {
        // TODO: make it a query type
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseSqlServerIdentityColumn();
        }
    }
}
