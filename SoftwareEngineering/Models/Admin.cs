using System;
using System.Collections.Generic;

#nullable disable

namespace SoftwareEngineering.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
