using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppReact.Client.Apis;
using WebAppReact.Contract;

namespace WebAppReact.Client.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    public class MovieController
    {
        private readonly IMovieApi _movieApi;

        public MovieController(IMovieApi movieApi)
        {
            _movieApi = movieApi;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieItem>> GetAllMovies()
        {
            return await _movieApi.GetMovies();
        }

        [HttpGet]
        public async Task<MovieDetail> GetMovies(int id)
        {
            return await _movieApi.GetMovie(id);
        }

        [HttpPost]
        public async Task<IEnumerable<MovieItem>> GetMovies([FromBody] MovieFilter filter)
        {
            return await _movieApi.GetMovies(filter);
        }
    }
}
