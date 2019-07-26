using System.Collections.Generic;
using Pattern.Domain;

namespace Pattern.Mappers
{
    public class NullProductMapper : IProductMapper
    {
        public IProduct ApplyTVA(IProduct product)
        {
            return product;
        }

        public IEnumerable<IProduct> ApplyTVA(IEnumerable<IProduct> products)
        {
            return products;
        }
    }
}