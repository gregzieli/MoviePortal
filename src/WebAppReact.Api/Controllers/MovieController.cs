using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppReact.Api.Abstractions.Providers;
using WebAppReact.Contract;
using WebAppReact.Domain.Repositories;

namespace WebAppReact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieController : Controller
    {
        private readonly IMovieProvider _movieProvider;
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieProvider movieProvider, IMovieRepository movieRepository)
        {
            _movieProvider = movieProvider;
            _movieRepository = movieRepository;
        }

        [HttpGet("{id}")]
        public async Task<MovieDetail> GetMovie(int id)
        {
            var movie = await _movieProvider.GetMovieAsync(id);

            return movie;
        }

        [HttpPost]
        public async Task<IEnumerable<MovieItem>> GetMovies(MovieFilter filter)
        {
            var movies = await _movieProvider.GetMoviesAsync(filter);

            return movies;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieItem>> GetMovies()
        {
            var movies = await _movieProvider.GetMoviesAsync();

            return movies;
        }
    }
}
