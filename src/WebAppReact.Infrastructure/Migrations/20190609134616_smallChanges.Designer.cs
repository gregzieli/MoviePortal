﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppReact.Infrastructure;

namespace WebAppReact.Infrastructure.Migrations
{
    [DbContext(typeof(MoviePortalContext))]
    [Migration("20190609134616_smallChanges")]
    partial class smallChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppReact.Domain.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Name");

                    b.Property<float>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.Author", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Name");

                    b.Property<float>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.JoinTables.ActorMovie", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<int>("MovieId");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("DirectorId");

                    b.Property<int>("Genre");

                    b.Property<DateTime>("PremiereDate");

                    b.Property<double>("Rating");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId");

                    b.Property<int?>("MovieId");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("ReviewDate");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MovieId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.JoinTables.ActorMovie", b =>
                {
                    b.HasOne("WebAppReact.Domain.Models.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppReact.Domain.Models.Movie", "Movie")
                        .WithMany("Cast")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.Movie", b =>
                {
                    b.HasOne("WebAppReact.Domain.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId");
                });

            modelBuilder.Entity("WebAppReact.Domain.Models.Review", b =>
                {
                    b.HasOne("WebAppReact.Domain.Models.Author", "Author")
                        .WithMany("Reviews")
                        .HasForeignKey("AuthorId");

                    b.HasOne("WebAppReact.Domain.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId");
                });
#pragma warning restore 612, 618
        }
    }
}
