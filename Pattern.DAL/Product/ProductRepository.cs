using System;
using System.Collections.Generic;
using Pattern.Domain;

namespace Pattern.DAL
{
    public class ProductRepository : IProductRepository
    {
        public IProduct Get(Guid id)
        {
            if(id.Equals(default(Guid))) 
                return new NullProduct();

            return new Product
            {
                Id = Guid.NewGuid(),
                Price = 25.76,
                ApplicableVAT = 0.21,
                Description = "New Xiaomi AirDots !",
                Name = "Xiaomi AirDots"
            };
        }

        public IEnumerable<IProduct> GetClientProducts(IClient client)
        {
            if(client.GetType().Equals(typeof(NullClient)))
                return new List<NullProduct>{ new NullProduct() };

            return new List<Product>{
                new Product
                {
                    Id = Guid.NewGuid(),
                    Price = 25.76,
                    ApplicableVAT = 0.21,
                    Description = "New Xiaomi AirDots !",
                    Name = "Xiaomi AirDots"
                },
                new Product {
                    Id = Guid.NewGuid(),
                    Price = 15.85,
                    ApplicableVAT = 0.06,
                    Description = "Old Xiaomi AirDots",
                    Name = "Old Xiaomi Airdots"
                }
            };
        }
    }
}