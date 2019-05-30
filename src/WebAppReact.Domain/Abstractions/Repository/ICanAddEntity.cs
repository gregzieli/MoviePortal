namespace WebAppReact.Domain.Abstractions.Repository
{
    public interface ICanAddEntity<TEntity>
    {
        TEntity Add(TEntity entity);
    }
}
