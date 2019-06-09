using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Client.Models;
using WebAppReact.Domain.Abstractions.Repository;

namespace WebAppReact.Client.Data
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public ValueTask<ApplicationUser> FindByIdAsync(string id)
        {
            return _context.Set<ApplicationUser>().FindAsync(id);
        }
    }
}
