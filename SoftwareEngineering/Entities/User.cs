using System;

namespace SoftwareEngineering.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsSubscribed { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
