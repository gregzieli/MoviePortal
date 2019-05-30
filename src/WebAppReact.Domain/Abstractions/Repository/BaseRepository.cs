namespace WebAppReact.Domain.Abstractions.Repository
{
    public abstract class BaseRepository : IRepository
    {
        protected BaseRepository(IUnitOfWork context)
        {
            UnitOfWork = context;
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}
