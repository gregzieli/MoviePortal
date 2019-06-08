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
    }
}
