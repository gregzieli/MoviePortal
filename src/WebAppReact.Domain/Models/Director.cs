using System.Collections.Generic;

namespace WebAppReact.Domain.Models
{
    public class Director : Person, IRatable
    {
        public float Rating { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
