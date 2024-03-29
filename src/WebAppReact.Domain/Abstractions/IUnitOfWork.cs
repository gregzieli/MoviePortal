using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppReact.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
