namespace WebAppReact.Contract
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }

        public string AuthorName { get; set; }
    }
}
