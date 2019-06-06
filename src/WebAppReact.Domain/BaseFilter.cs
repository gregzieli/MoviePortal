namespace WebAppReact.Domain
{
    public abstract class BaseFilter
    {
        public int PageNumber { get; set; } = 1;

        public int Size { get; set; } = 20;

        public int Skip => Size * (PageNumber - 1);
    }
}
