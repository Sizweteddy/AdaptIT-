using System;

namespace Shared.Models
{
    public class Client
    {
        public string ClientName { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Location { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
