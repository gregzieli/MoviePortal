using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAppReact.Contract;
using WebAppReact.Domain.Abstractions.Query;
using WebAppReact.Domain.Models;

namespace WebAppReact.Api.QueryObjects
{
    public class MovieQuery : IQuery<Movie>, IMovieQuery
    {
        public string Title { get; set; }

        public int? Year { get; set; }

        public int? Rating { get; set; }

        public Genre? Genre { get; set; }

        public IEnumerable<Expression<Func<Movie, bool>>> AllFilters
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Title))
                {
                    yield return HasTitle;
                }

                if (Year.HasValue)
                {
                    yield return IsFromYear;
                }

                if (Rating.HasValue)
                {
                    yield return HasRating;
                }

                if (Genre.HasValue)
                {
                    yield return IsOfGenre;
                }
            }
        }

        private Expression<Func<Movie, bool>> HasTitle => x => x.Title == Title;

        private Expression<Func<Movie, bool>> IsFromYear => x => x.PremiereDate.Year == Year;

        private Expression<Func<Movie, bool>> HasRating => x => x.Rating == Rating;

        private Expression<Func<Movie, bool>> IsOfGenre => x => x.Genre == Genre;
    }
}
