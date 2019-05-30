using System;
using System.Collections.Generic;
using WebAppReact.Domain.Abstractions;
using WebAppReact.Domain.Models.JoinTables;

namespace WebAppReact.Domain.Models
{
    public class Movie : BaseEntity<int>
    {
        public string Title { get; set; }

        public DateTime PremiereDate { get; set; }

        public float Rating { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public IEnumerable<ActorMovie> Cast { get; set; }

        public Director Director { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}
