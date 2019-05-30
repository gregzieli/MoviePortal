using System.Collections.Generic;

namespace WebAppReact.Domain.Abstractions.Repository
{
    public interface ICanAddEntities<TEntity>
    {
        IEnumerable<TEntity> Add(IEnumerable<TEntity> entity);
    }
}
