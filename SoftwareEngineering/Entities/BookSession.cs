using System;

namespace SoftwareEngineering.Entities
{
    public class BookSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
