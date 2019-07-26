using System.Collections.Generic;
using Pattern.Domain;
using Pattern.ViewModels;

namespace Pattern.Mappers
{
    public class ProductViewModelMapper : IProductViewModelMapper
    {
        public ProductViewModel MapToViewModel(IProduct product)
        {
            return new ProductViewModel
            {
                Price = product.Price.ToString(),
                Description = product.Description,
                Name = product.Name
            };
        }

        public IEnumerable<ProductViewModel> MapToViewModel(IEnumerable<IProduct> products)
        {
            var viewModels = new List<ProductViewModel>();

            foreach(var product in products)
            {
                viewModels.Add(MapToViewModel(product));
            }

            return viewModels;
        }
    }
}