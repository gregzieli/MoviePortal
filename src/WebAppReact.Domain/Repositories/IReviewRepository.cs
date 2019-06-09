using System.Threading.Tasks;
using WebAppReact.Domain.Abstractions.Repository;
using WebAppReact.Domain.Models;

namespace WebAppReact.Domain.Repositories
{
    public interface IReviewRepository : IRepository<Review>, ICanAddEntity<Review>
    {
        Task<Movie> GetMovieAsync(int id);

        Task<Author> GetAuthorAsync(string id);
    }
}
