namespace WebAppReact.Contract
{
    public class ReviewDetail
    {
        public MovieDetail Movie { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int? Rating { get; set; }

        public string AuthorName { get; set; }
    }
}
