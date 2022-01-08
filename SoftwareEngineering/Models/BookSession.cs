using System;
using System.Collections.Generic;

#nullable disable

namespace SoftwareEngineering.Models
{
    public partial class BookSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
