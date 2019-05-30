namespace WebAppReact.Domain.Abstractions.Repository
{
    public interface IRepository<T> : IRepository
    {
    }

    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
