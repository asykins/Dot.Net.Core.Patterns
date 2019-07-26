using System;
using Pattern.Domain;

namespace Pattern.DAL
{
    public interface IClientRepository
    {
        IClient Get(Guid id);
    }
}