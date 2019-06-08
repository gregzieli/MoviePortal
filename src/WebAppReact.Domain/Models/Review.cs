using WebAppReact.Domain.Abstractions;

namespace WebAppReact.Domain.Models
{
    public class Review : BaseEntity<int>
    {
        public string Title { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Author Author { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }
    }
}