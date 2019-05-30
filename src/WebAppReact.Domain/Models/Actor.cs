using System.Collections.Generic;
using WebAppReact.Domain.Models.JoinTables;

namespace WebAppReact.Domain.Models
{
    public class Actor : Person, IRatable
    {
        public float Rating { get; set; }

        public IEnumerable<ActorMovie> Movies { get; set; }
    }
}
