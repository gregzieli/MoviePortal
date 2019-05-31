using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.QueryObjects;

namespace WebAppReact.Domain.Providers
{
    public interface IMovieProvider
    {
        Task<Movie> GetMovieAsync(int id);
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<IEnumerable<Movie>> GetMoviesAsync(MovieQuery filter);
    }
}
