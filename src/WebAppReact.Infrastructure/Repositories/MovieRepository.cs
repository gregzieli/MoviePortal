using System.Threading.Tasks;
using WebAppReact.Domain.Abstractions.Repository;
using WebAppReact.Domain.Models;
using WebAppReact.Domain.Repositories;

namespace WebAppReact.Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        private readonly MoviePortalContext _context;

        public MovieRepository(MoviePortalContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Movie> FindByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }
    }
}
