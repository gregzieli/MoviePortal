using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Domain.Abstractions.Repository;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.Repositories;

namespace WebAppReact.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        private readonly MoviePortalContext _context;

        public ReviewRepository(MoviePortalContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Author> GetAuthorAsync(string id)
        {
            var author = await _context.Authors.FindAsync(id);

            return author ?? _context.Authors.Add(new Author
            {
                Id = id
            }).Entity;
        }

        public Review Add(Review entity)
        {
            return _context.Reviews.Add(entity).Entity;
        }
    }
}
