using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppReact.Client.Apis;
using WebAppReact.Client.Data;
using WebAppReact.Client.Models;
using WebAppReact.Contract;

namespace WebAppReact.Client.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReviewController : Controller
    {
        private readonly IMovieApi _movieApi;
        private readonly IUserRepository _userRepository;

        public ReviewController(IMovieApi movieApi, IUserRepository userRepository)
        {
            _movieApi = movieApi;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> RateMovie([FromBody] ReviewDto review)
        {
            var user = await _userRepository.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            review.UserId = user.Id;
            review.AuthorName = user.UserName;
            return await _movieApi.RateMovie(review);
        }
    }
}
