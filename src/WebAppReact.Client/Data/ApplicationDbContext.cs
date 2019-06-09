using WebAppReact.Client.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppReact.Client.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IUnitOfWork
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AspNetUserEntityTypeConfiguration());
        }
    }

    internal class AspNetUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("AspNetUsers");
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.UserName)
                .HasColumnName("UserName");

        }
    }
}
