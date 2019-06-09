using System;
using System.Collections.Generic;
using System.Linq;
using WebAppReact.Domain.Abstractions;
using WebAppReact.Domain.Models.JoinTables;

namespace WebAppReact.Domain.Models
{
    public class Movie : BaseEntity<int>
    {
        public string Title { get; set; }

        public DateTime PremiereDate { get; set; }

        public double Rating { get; set; } 

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ActorMovie> Cast { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public string Image { get; set; }

        public void UpdateRating()
        {
            Rating = Reviews.Average(x => (double?)x.Rating) ?? 0;
        }
    }
}
