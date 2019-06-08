using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Api.Abstractions.Providers;
using WebAppReact.Api.QueryObjects;
using WebAppReact.Contract;
using WebAppReact.Domain.Models;
using WebAppReact.Infrastructure;

namespace WebAppReact.Api.Providers
{
    public class MovieProvider : IMovieProvider
    {
        private readonly MoviePortalContext _movieContext;
        private readonly IMapper _mapper;

        public MovieProvider(MoviePortalContext movieContext, IMapper mapper)
        {
            _movieContext = movieContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieItem>> GetMoviesAsync()
        {
            return await _mapper.ProjectTo<MovieItem>(_movieContext.Movies).ToListAsync();
        }

        public async Task<IEnumerable<MovieItem>> GetMoviesAsync(MovieFilter filter)
        {
            var query = new MovieQuery
            {
                Genre = filter.Genre,
                Rating = filter.Rating,
                Title = filter.Title,
                Year = filter.Year
            };

            return await _mapper.ProjectTo<MovieItem>(_movieContext.Movies
                .Where(query.AllFilters)
                .OrderBy(x => x.PremiereDate)
                .Skip(filter.Skip)
                .Take(filter.Size))
                .ToListAsync();
        }

        public async ValueTask<MovieDetail> GetMovieAsync(int id)
        {
            return await _mapper.ProjectTo<MovieDetail>(_movieContext.Movies).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
