using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieProvider.GetMovieAsync(id);

            return movie is null ? NotFound() : (IActionResult)Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> GetMovies(MovieFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movies = await _movieProvider.GetMoviesAsync(filter);

            return Ok(movies);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieProvider.GetMoviesAsync();

            return Ok(movies);
        }

        [HttpPut]// TODO: Authorize
        public async Task<IActionResult> RateMovie(int movieId, int rate)
        {
            // TODO: get the user id
            var userId = 1;
            var movie = await _movieRepository.FindByIdAsync(movieId);

            if (movie is null)
            {
                return NotFound();
            }

            movie.Rate(rate, userId);
            await _movieRepository.UnitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
