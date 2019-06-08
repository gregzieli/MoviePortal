using Refit;
using System.Threading.Tasks;
using WebAppReact.Contract;

namespace WebAppReact.Client.Apis
{
    public interface IMovieApi
    {
        [Get("/api/Movie/GetMovies")]
        Task<MovieItem> GetMovies();
    }
}
