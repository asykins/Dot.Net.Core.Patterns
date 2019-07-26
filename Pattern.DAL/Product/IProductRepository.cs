using System;
using System.Collections.Generic;
using Pattern.Domain;

namespace Pattern.DAL
{
    public interface IProductRepository
    {
        IProduct Get(Guid id);

        IEnumerable<IProduct> GetClientProducts(IClient client);
    }
}