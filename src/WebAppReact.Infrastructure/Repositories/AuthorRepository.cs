using System.Threading.Tasks;
using WebAppReact.Domain.Abstractions.Repository;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.Repositories;

namespace WebAppReact.Infrastructure.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        private readonly MoviePortalContext _context;

        public AuthorRepository(MoviePortalContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Author> FindByIdAsync(string id)
        {
            throw new System.Exception();
           // return await _context.Authors.FindAsync(id);
        }
    }
}
