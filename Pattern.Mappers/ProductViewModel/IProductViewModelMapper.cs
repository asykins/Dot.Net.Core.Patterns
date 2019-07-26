using System.Collections.Generic;
using Pattern.Domain;
using Pattern.ViewModels;

namespace Pattern.Mappers
{
    public interface IProductViewModelMapper
    {
        ProductViewModel MapToViewModel(IProduct product);
        IEnumerable<ProductViewModel> MapToViewModel(IEnumerable<IProduct> products);
    }
}