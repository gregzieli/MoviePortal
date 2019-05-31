using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.Providers;
using WebAppReact.Domain.QueryObjects;
using WebAppReact.Infrastructure;

namespace WebAppReact.Api.Providers
{
    public class MovieProvider : IMovieProvider
    {
        private readonly MoviePortalContext _movieContext;

        public MovieProvider(MoviePortalContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _movieContext.Movies
                .Include(x => x.Director)
                .Include(x => x.Cast)
                    .ThenInclude(x => x.Actor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(MovieQuery filter)
        {
            return await _movieContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _movieContext.Movies.FindAsync(id);
        }
    }
}
