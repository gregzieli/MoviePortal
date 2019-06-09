using System;

namespace WebAppReact.Contract
{
    public class ReviewItem
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }

        public string AuthorName { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
