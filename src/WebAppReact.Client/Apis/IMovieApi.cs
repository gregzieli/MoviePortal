using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppReact.Contract;

namespace WebAppReact.Client.Apis
{
    public interface IMovieApi
    {
        [Get("/api/Movie/GetMovies")]
        Task<IEnumerable<MovieItem>> GetMovies();

        [Get("/api/Movie/GetMovie/{id}")]
        Task<MovieDetail> GetMovie(int id);

        [Post("/api/Movie/GetMovies")]
        Task<IEnumerable<MovieItem>> GetMovies([Body]MovieFilter filter);

        [Post("/api/Review/RateMovie")]
        Task<IActionResult> RateMovie([Body]ReviewDto review);

        [Get("/api/Review/GetOwnReview")]
        Task<ReviewDto> GetOwnReview(int movieId);

        [Get("/api/Review/GetReview")]
        Task<ReviewDto> GetReview(int id);

        [Get("/api/Review/GetReviews")]
        Task<IEnumerable<ReviewDto>> GetReviews(int id);
    }
}
