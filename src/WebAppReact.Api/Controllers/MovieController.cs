using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.Providers;

namespace WebAppReact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieController : Controller
    {
        private readonly IMovieProvider _movieProvider;

        public MovieController(IMovieProvider movieProvider)
        {
            _movieProvider = movieProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieProvider.GetMoviesAsync();

            // TODO: map to some easier graphed DTO
            return Ok(movies);
        }
    }
}
