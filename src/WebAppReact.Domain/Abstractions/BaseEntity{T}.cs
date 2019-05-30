namespace WebAppReact.Domain.Abstractions
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; private set; }
    }
}
