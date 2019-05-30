using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppReact.Domain.Models.JoinTables;

namespace WebAppReact.Infrastructure.TypeConfigurations
{
    public class ActorMovieEntityTypeConfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasKey(x => new { x.ActorId, x.MovieId });

            builder.HasOne(x => x.Movie).WithMany(x => x.Cast).HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.Actor).WithMany(x => x.Movies).HasForeignKey(x => x.ActorId);
        }
    }
}
