using System;
using Pattern.Domain;

namespace Pattern.DAL
{
    public class ClientRepository : IClientRepository
    {
        public IClient Get(Guid id)
        {
            if(id.Equals(default(Guid))) 
                return new NullClient();

            return new Client
            {
                Id = Guid.NewGuid(),
                FirstName = "Jean",
                LastName = "Dupont",
            };
        }
    }
}