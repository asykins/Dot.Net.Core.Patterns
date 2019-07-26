using System.Collections.Generic;
using Pattern.Domain;

namespace Pattern.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public IProduct ApplyTVA(IProduct product)
        {
            return new Product
            {
                ApplicableVAT = product.ApplicableVAT,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price + (product.Price * product.ApplicableVAT)
            };
        }

        public IEnumerable<IProduct> ApplyTVA(IEnumerable<IProduct> products)
        {
            var processedProducts = new List<IProduct>();

            foreach(var product in products)
            {
                processedProducts.Add(ApplyTVA(product));
            }

            return processedProducts;
        }
    }
}
