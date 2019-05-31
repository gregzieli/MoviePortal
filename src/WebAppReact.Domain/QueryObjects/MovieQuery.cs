using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAppReact.Domain.Abstractions.Query;
using WebAppReact.Domain.Models;

namespace WebAppReact.Domain.QueryObjects
{
    public class MovieQuery : IQuery<Movie>
    {
        public IEnumerable<Expression<Func<Movie, bool>>> AllFilters => throw new NotImplementedException();
    }
}
