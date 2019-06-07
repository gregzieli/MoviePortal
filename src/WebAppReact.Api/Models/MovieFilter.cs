using WebAppReact.Domain;
using WebAppReact.Domain.Models;

namespace WebAppReact.Api.Models
{
    public class MovieFilter : BaseFilter, IMovieQuery
    {
        public string Title { get; set; }

        public int? Year { get; set; }

        public int? Rating { get; set; }

        public Genre? Genre { get; set; }
    }

    public interface IMovieQuery
    {
        string Title { get; set; }

        int? Year { get; set; }

        int? Rating { get; set; }

        Genre? Genre { get; set; }
    }
}
