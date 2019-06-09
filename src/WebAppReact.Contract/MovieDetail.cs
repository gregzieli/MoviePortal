using System;
using System.Collections.Generic;
using WebAppReact.Domain.Models;

namespace WebAppReact.Contract
{
    public class MovieDetail
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PremiereDate { get; set; }

        public double Rating { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public DirectorDto Director { get; set; }

        public IEnumerable<ActorDto> Cast { get; set; }

        public IEnumerable<ReviewDto> Reviews { get; set; }
    }
}
