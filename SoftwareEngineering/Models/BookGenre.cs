using System;
using System.Collections.Generic;

#nullable disable

namespace SoftwareEngineering.Models
{
    public partial class BookGenre
    {
        public BookGenre()
        {
            BookGenreId1Navigations = new HashSet<Book>();
            BookGenreId2Navigations = new HashSet<Book>();
            BookGenreId3Navigations = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> BookGenreId1Navigations { get; set; }
        public virtual ICollection<Book> BookGenreId2Navigations { get; set; }
        public virtual ICollection<Book> BookGenreId3Navigations { get; set; }
    }
}
