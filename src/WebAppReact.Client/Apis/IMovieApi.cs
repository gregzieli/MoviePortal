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
        Task<bool> RateMovie([Body]ReviewDto review);

        [Get("/api/Review/GetReview/{userId}/{userName}/{movieId}")]
        Task<ReviewDetail> GetReview(string userId, string userName, int movieId);

        [Get("/api/Review/GetReviews/{movieId}")]
        Task<IEnumerable<ReviewItem>> GetReviews(int movieId);
    }
}
