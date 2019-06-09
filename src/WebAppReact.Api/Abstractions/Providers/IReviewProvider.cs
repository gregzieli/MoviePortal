using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppReact.Api.QueryObjects;
using WebAppReact.Contract;
using WebAppReact.Domain.Models;

namespace WebAppReact.Api.Abstractions.Providers
{
    public interface IReviewProvider
    {
        Task<IEnumerable<ReviewItem>> GetReviewsAsync(int movieId);
    }
}
