using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Api.Abstractions.Providers;
using WebAppReact.Contract;
using WebAppReact.Infrastructure;

namespace WebAppReact.Api.Providers
{
    public class ReviewProvider : IReviewProvider
    {
        private readonly MoviePortalContext _movieContext;
        private readonly IMapper _mapper;

        public ReviewProvider(MoviePortalContext movieContext, IMapper mapper)
        {
            _movieContext = movieContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewItem>> GetReviewsAsync(int movieId)
        {
            return await _mapper.ProjectTo<ReviewItem>(_movieContext.Reviews.Where(x => x.Movie.Id == movieId))
                .OrderByDescending(x => x.ReviewDate)
                .ToListAsync();
        }
    }
}
