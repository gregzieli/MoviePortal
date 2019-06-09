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
    public class ReviewController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IAuthorRepository _authorRepository;

        public ReviewController(IMovieRepository movieRepository, IAuthorRepository authorRepository)
        {
            _movieRepository = movieRepository;
            _authorRepository = authorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RateMovie([FromBody]ReviewDto review)
        {
            var movie = await _movieRepository.FindByIdAsync(review.MovieId);

            if (movie is null)
            {
                return NotFound();
            }



            //movie.Rate(rate, userId);
            await _movieRepository.UnitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
