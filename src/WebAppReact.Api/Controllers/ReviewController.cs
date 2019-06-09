using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Api.Abstractions.Providers;
using WebAppReact.Contract;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.Repositories;

namespace WebAppReact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpPost]
        public async Task<bool> RateMovie([FromBody]ReviewDto reviewDto)
        {
            try
            {
                var movie = await _reviewRepository.GetMovieAsync(reviewDto.MovieId);

                if (movie is null)
                {
                    return false;
                }

                var review = movie.Reviews.SingleOrDefault(x => x.Author != null && x.Author.Id == reviewDto.UserId);

                if (review is null)
                {
                    var author = await _reviewRepository.GetAuthorAsync(reviewDto.UserId);
                    author.Name = reviewDto.AuthorName;

                    review = _reviewRepository.Add(new Review
                    {
                        Movie = movie,
                        Author = author
                    });

                }

                review.Update(reviewDto.Title, reviewDto.Text, reviewDto.Rating);
                movie.UpdateRating(); // TODO: this will just be a getter on Rating

                await _reviewRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                throw;
            }
            return true;
        }
    }
}
