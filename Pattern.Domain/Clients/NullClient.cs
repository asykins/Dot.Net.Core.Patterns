using System;

namespace Pattern.Domain
{
    public class NullClient : IClient
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}