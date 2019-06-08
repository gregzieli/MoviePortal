using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.Models.JoinTables;
using WebAppReact.Infrastructure;

namespace WebAppReact.Api.Controllers
{
    public class Seeder : Controller
    {
        public Seeder(MoviePortalContext moviePortalContext)
        {
            _moviePortalContext = moviePortalContext;
        }

        private readonly MoviePortalContext _moviePortalContext;

        private void SeedTables()
        {
            var movies = GetMovies().ToList();
            var directors = GetDirectors().ToList();
            var actors = GetActors().ToList();

            var toTable = new List<Movie>();

            foreach (var item in movies)
            {
                var director = directors.RandomElement(new Random());

                var cast = actors.Select(x => new ActorMovie { Movie = item, Actor = x }).ToList();
                cast.Remove(cast.RandomElement(new Random()));
                cast.Remove(cast.RandomElement(new Random()));
                cast.Remove(cast.RandomElement(new Random()));
                cast.Remove(cast.RandomElement(new Random()));

                toTable.Add(new Movie
                {
                    Cast = cast,
                    Description = item.Description,
                    Director = director,
                    Genre = item.Genre,
                    PremiereDate = item.PremiereDate,
                    Rating = item.Rating,
                    Title = item.Title
                });
            }

            try
            {
                _moviePortalContext.Movies.AddRange(toTable);

                var directorsWithMovies = toTable.Select(x => x.Director).ToList();
                var directorsWithoutMovies = directors.Except(directorsWithMovies).ToList();
                if (directorsWithoutMovies.Any())
                {
                    _moviePortalContext.Directors.AddRange(directorsWithoutMovies);
                }

                var actorsInMovies = toTable.SelectMany(x => x.Cast.Select(x => x.Actor)).ToList();
                var actorsNotInMovies = actors.Except(actorsInMovies).ToList();
                if (actorsNotInMovies.Any())
                {
                    _moviePortalContext.Actors.AddRange(actorsNotInMovies);
                }

                _moviePortalContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private IEnumerable<Actor> GetActors()
        {
            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-18).AddDays(-13),
                Name = "Keir Wagstaff",
                Rating = 7,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-20).AddDays(-211),
                Name = "Muhammed Smith",
                Rating = 6,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-33).AddDays(-113),
                Name = "Safwan Fischer",
                Rating = 8,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-50).AddDays(-223),
                Name = "Aaminah Thomson",
                Rating = 9,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-65).AddDays(-93),
                Name = "Kaylem Lang",
                Rating = 5,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-73).AddDays(-74),
                Name = "Jamil Lee",
                Rating = 4,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-37).AddDays(-124),
                Name = "Rianna French",
                Rating = 9,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-25).AddDays(-5),
                Name = "Korban Baker",
                Rating = 7,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-27).AddDays(-83),
                Name = "Elise Watts",
                Rating = 8,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-22).AddDays(-66),
                Name = "Herbie Hunt",
                Rating = 6,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-29).AddDays(-56),
                Name = "Zoha Oneill",
                Rating = 5,
            };

            yield return new Actor
            {
                BirthDay = DateTime.Today.AddYears(-44).AddDays(-65),
                Name = "Shae Costa",
                Rating = 2,
            };
        }

        private IEnumerable<Director> GetDirectors()
        {
            yield return new Director
            {
                BirthDay = DateTime.Today.AddYears(-40).AddDays(-23),
                Name = "Reilly Crane",
                Rating = 6,
            };

            yield return new Director
            {
                BirthDay = DateTime.Today.AddYears(-32).AddDays(-123),
                Name = "Makayla Barron",
                Rating = 5,
            };

            yield return new Director
            {
                BirthDay = DateTime.Today.AddYears(-54).AddDays(23),
                Name = "Samiyah Hume",
                Rating = 4,
            };

            yield return new Director
            {
                BirthDay = DateTime.Today.AddYears(-66).AddDays(-13),
                Name = "Tahmina Randall",
                Rating = 7,
            };

            yield return new Director
            {
                BirthDay = DateTime.Today.AddYears(-27).AddDays(-342),
                Name = "Franky Griffith",
                Rating = 8,
            };
        }

        private IEnumerable<Movie> GetMovies()
        {
            yield return new Movie
            {
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Aliquam nulla facilisi cras fermentum odio eu feugiat pretium. Placerat orci nulla pellentesque dignissim enim sit. Accumsan tortor posuere ac ut consequat semper viverra. Enim sit amet venenatis urna cursus. Et tortor consequat id porta nibh venenatis cras. Et netus et malesuada fames. Quam elementum pulvinar etiam non quam lacus suspendisse. Phasellus faucibus scelerisque eleifend donec pretium vulputate sapien nec. Neque viverra justo nec ultrices. Sapien eget mi proin sed libero enim sed faucibus.",
                Genre = Genre.Action,
                PremiereDate = DateTime.Today.AddDays(-124),
                Rating = 6,
                Title = "Lorem Ipsum"
            };

            yield return new Movie
            {
                Description = "Sed turpis tincidunt id aliquet risus feugiat. Nunc vel risus commodo viverra maecenas. Et malesuada fames ac turpis egestas sed. Sed arcu non odio euismod lacinia at quis risus sed.",
                Genre = Genre.Action,
                PremiereDate = DateTime.Today.AddDays(-4124),
                Rating = 10,
                Title = "Semper Feugiat"
            };

            yield return new Movie
            {
                Description = "Enim blandit volutpat maecenas volutpat blandit aliquam etiam erat velit. Pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat vivamus. Rutrum quisque non tellus orci ac auctor augue mauris augue. Aliquam ultrices sagittis orci a scelerisque purus semper.",
                Genre = Genre.Comedy,
                PremiereDate = DateTime.Today.AddDays(-1231),
                Rating = 8,
                Title = "Non Tellus Orci Ac"
            };

            yield return new Movie
            {
                Description = "Facilisi morbi tempus iaculis urna id volutpat lacus laoreet non. Egestas pretium aenean pharetra magna ac placerat vestibulum lectus. Fames ac turpis egestas maecenas pharetra convallis posuere morbi leo. Eu turpis egestas pretium aenean. Nibh cras pulvinar mattis nunc sed blandit libero volutpat.",
                Genre = Genre.Drama,
                PremiereDate = DateTime.Today.AddDays(-999),
                Rating = 4,
                Title = "Egestas Pretium Aenean"
            };

            yield return new Movie
            {
                Description = "Nam at lectus urna duis convallis convallis tellus id. Viverra adipiscing at in tellus integer feugiat scelerisque varius. Diam vel quam elementum pulvinar etiam non. Sollicitudin tempor id eu nisl nunc mi ipsum faucibus. Rhoncus urna neque viverra justo nec ultrices dui sapien eget. Faucibus et molestie ac feugiat sed lectus vestibulum mattis. Donec adipiscing tristique risus nec feugiat.",
                Genre = Genre.Horror,
                PremiereDate = DateTime.Today.AddDays(-66),
                Rating = 6,
                Title = "Urna Duis Convallis"
            };

            yield return new Movie
            {
                Description = "Pellentesque adipiscing commodo elit at imperdiet dui accumsan sit amet. Ultricies mi eget mauris pharetra et ultrices neque ornare aenean. Risus quis varius quam quisque id diam vel quam elementum. Et egestas quis ipsum suspendisse ultrices gravida dictum fusce. Posuere urna nec tincidunt praesent semper feugiat. Aenean sed adipiscing diam donec adipiscing tristique risus. Turpis cursus in hac habitasse platea dictumst quisque sagittis purus. Volutpat consequat mauris nunc congue nisi vitae suscipit.",
                Genre = Genre.Comedy,
                PremiereDate = DateTime.Today.AddDays(-499),
                Rating = 9,
                Title = "Quis Opsum Suspendisse"
            };

            yield return new Movie
            {
                Description = "Laoreet sit amet cursus sit amet dictum sit amet. Dui ut ornare lectus sit amet est. Posuere urna nec tincidunt praesent semper feugiat. Quam pellentesque nec nam aliquam sem et. Ut tellus elementum sagittis vitae et leo duis ut diam.",
                Genre = Genre.Action,
                PremiereDate = DateTime.Today.AddDays(-749),
                Rating = 7,
                Title = "Dui ut Ornare"
            };

            yield return new Movie
            {
                Description = "Amet commodo nulla facilisi nullam. Ultrices tincidunt arcu non sodales neque sodales ut etiam sit. Sed blandit libero volutpat sed cras ornare arcu. Condimentum mattis pellentesque id nibh tortor id aliquet lectus. Odio aenean sed adipiscing diam donec adipiscing. Montes nascetur ridiculus mus mauris vitae ultricies leo. Fames ac turpis egestas integer eget aliquet nibh praesent tristique. Egestas tellus rutrum tellus pellentesque eu tincidunt tortor. Eget egestas purus viverra accumsan in. Venenatis a condimentum vitae sapien pellentesque habitant morbi. Condimentum lacinia quis vel eros donec.",
                Genre = Genre.Horror,
                PremiereDate = DateTime.Today.AddDays(-1499),
                Rating = 5,
                Title = "Eu Tincidunt Tortor"
            };
        }
    }

    public static class Extensions
    {
        public static T RandomElement<T>(this IEnumerable<T> source, Random rng)
        {
            var current = default(T);
            var count = 0;
            foreach (var element in source)
            {
                count++;
                if (rng.Next(count) == 0)
                {
                    current = element;
                }
            }
            if (count == 0)
            {
                throw new InvalidOperationException("Sequence was empty");
            }
            return current;
        }
    }
}
