using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, IEnumerable<Expression<Func<TSource, bool>>> predicates)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicates is null)
            {
                throw new ArgumentNullException(nameof(predicates));
            }

            foreach (var predicate in predicates)
            {
                source = source.Where(predicate);
            }

            return source;
        }
    }
}
