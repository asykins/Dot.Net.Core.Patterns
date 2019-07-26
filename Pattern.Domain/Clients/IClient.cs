using System;

namespace Pattern.Domain
{
    public interface IClient
    {
        Guid Id { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
    }
}