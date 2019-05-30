using System.Collections.Generic;

namespace WebAppReact.Domain.Abstractions.Repository
{
    public interface ICanUpdateEntities<TEntity>
    {
        IEnumerable<TEntity> Update(IEnumerable<TEntity> entity);
    }
}
