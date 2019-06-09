using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppReact.Client.Models;
using WebAppReact.Domain.Abstractions.Repository;

namespace WebAppReact.Client.Data
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ValueTask<ApplicationUser> FindByIdAsync(string id);
    }
}
