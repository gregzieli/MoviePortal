using System.Collections.Generic;
using WebAppReact.Domain.Abstractions;

namespace WebAppReact.Domain.Models
{
    public class Author : BaseEntity<string>
    {
        public string Name { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}