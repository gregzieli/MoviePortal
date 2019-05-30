using System.Collections.Generic;

namespace WebAppReact.Domain.Models
{
    public class Author : Person
    {
        public IEnumerable<Review> Reviews { get; set; }
    }
}