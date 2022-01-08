using System;
using System.Collections.Generic;

#nullable disable

namespace SoftwareEngineering.Models
{
    public partial class BookProvider
    {
        public BookProvider()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Hash { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
