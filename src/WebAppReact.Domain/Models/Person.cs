using System;
using WebAppReact.Domain.Abstractions;

namespace WebAppReact.Domain.Models
{
    public class Person : BaseEntity<int>
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
