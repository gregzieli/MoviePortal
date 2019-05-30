namespace WebAppReact.Domain.Abstractions.Repository
{
    public interface ICanUpdateEntity<TEntity>
    {
        TEntity Update(TEntity entity);
    }
}
