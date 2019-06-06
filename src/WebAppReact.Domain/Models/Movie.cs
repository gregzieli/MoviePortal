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

        public virtual ICollection<ActorMovie> Cast { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public void Rate(int rate, int userId)
        {
            // LOL need to come up with a rating algorithm xD
            //  Ale to ok, bo trzeba powiazać użytkowników z ratingami i tak
            throw new NotImplementedException();
        }
    }
}
