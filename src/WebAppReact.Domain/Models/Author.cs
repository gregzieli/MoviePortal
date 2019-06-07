using System.Collections.Generic;

namespace WebAppReact.Domain.Models
{
    public class Author : Person
    {
        public virtual ICollection<Review> Reviews { get; set; }
    }
}