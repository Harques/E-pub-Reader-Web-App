using System;
using System.Collections.Generic;

#nullable disable

namespace SoftwareEngineering.Models
{
    public partial class Book
    {
        public Book()
        {
            BookSessions = new HashSet<BookSession>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int BookProviderId { get; set; }
        public bool IsAdultOnly { get; set; }
        public int? GenreId1 { get; set; }
        public int? GenreId2 { get; set; }
        public int? GenreId3 { get; set; }
        public bool IsAudiobook { get; set; }
        public string BookLink { get; set; }

        public virtual BookProvider BookProvider { get; set; }
        public virtual BookGenre GenreId1Navigation { get; set; }
        public virtual BookGenre GenreId2Navigation { get; set; }
        public virtual BookGenre GenreId3Navigation { get; set; }
        public virtual ICollection<BookSession> BookSessions { get; set; }
    }
}
