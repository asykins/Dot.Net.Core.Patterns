using System.Collections.Generic;
using Pattern.Domain;
using Pattern.ViewModels;

namespace Pattern.Mappers
{
    public class NullProductViewModelMapper : IProductViewModelMapper
    {
        public ProductViewModel MapToViewModel(IProduct product)
        {
            return new ProductViewModel 
            {
                Name = "Invalid Product",
                Price = "",
                Description = "A technical error occured while retreiving the product."
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
