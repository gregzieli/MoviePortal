using System.Threading.Tasks;
using WebAppReact.Domain.Abstractions.Repository;
using WebAppReact.Domain.Models;

namespace WebAppReact.Domain.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> FindByIdAsync(int id);
    }
}
