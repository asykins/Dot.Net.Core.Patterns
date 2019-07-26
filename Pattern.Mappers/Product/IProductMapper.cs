using System.Collections.Generic;
using Pattern.Domain;

namespace Pattern.Mappers
{
    public interface IProductMapper
    {
        IProduct ApplyTVA(IProduct product);
        IEnumerable<IProduct> ApplyTVA(IEnumerable<IProduct> products);
    }
}