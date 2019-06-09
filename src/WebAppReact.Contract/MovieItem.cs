using System;
using WebAppReact.Domain.Models;

namespace WebAppReact.Contract
{
    public class MovieItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PremiereDate { get; set; }

        public double Rating { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public string DirectorName { get; set; }

        public int ReviewCount { get; set; }
    }
}
