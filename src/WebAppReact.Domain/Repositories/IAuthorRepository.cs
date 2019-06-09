using System.Threading.Tasks;
using WebAppReact.Domain.Abstractions.Repository;
using WebAppReact.Domain.Models;

namespace WebAppReact.Domain.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetAsync(string id);
    }
}
