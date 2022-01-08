using System;
using System.Collections.Generic;

#nullable disable

namespace SoftwareEngineering.Models
{
    public partial class User
    {
        public User()
        {
            BookSessions = new HashSet<BookSession>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsSubscribed { get; set; }
        public DateTime BirthDate { get; set; }
        public string Hash { get; set; }

        public virtual ICollection<BookSession> BookSessions { get; set; }
    }
}
