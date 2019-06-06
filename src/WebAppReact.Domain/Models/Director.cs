using System.Collections.Generic;

namespace WebAppReact.Domain.Models
{
    public class Director : Person, IRatable
    {
        public float Rating { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
