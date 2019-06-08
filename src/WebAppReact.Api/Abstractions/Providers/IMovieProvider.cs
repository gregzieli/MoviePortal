using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppReact.Api.QueryObjects;
using WebAppReact.Contract;
using WebAppReact.Domain.Models;

namespace WebAppReact.Api.Abstractions.Providers
{
    public interface IMovieProvider
    {
        ValueTask<MovieDetail> GetMovieAsync(int id);

        Task<IEnumerable<MovieItem>> GetMoviesAsync();

        Task<IEnumerable<MovieItem>> GetMoviesAsync(MovieFilter filter);
    }
}
