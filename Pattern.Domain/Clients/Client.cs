using System;

namespace Pattern.Domain
{
    public class Client : IClient
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}