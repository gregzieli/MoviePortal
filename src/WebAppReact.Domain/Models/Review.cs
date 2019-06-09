using System;
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

        public DateTime ReviewDate { get; set; }

        public void Update(string title, string text, int rating)
        {
            Title = title;
            Text = text;
            Rating = rating;
            ReviewDate = DateTime.UtcNow;
            Movie.UpdateRating();
        }
    }
}
