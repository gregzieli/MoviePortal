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

        public async Task<Author> GetAsync(string id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author ?? new Author
            {
                Id = id
            };
        }
    }
}
