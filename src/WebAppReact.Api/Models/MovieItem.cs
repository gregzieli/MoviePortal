using System;
using WebAppReact.Domain.Models;

namespace WebAppReact.Api.Models
{
    public class MovieItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PremiereDate { get; set; }

        public float Rating { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public string DirectorName { get; set; }

        public int ReviewCount { get; set; }
    }
}
