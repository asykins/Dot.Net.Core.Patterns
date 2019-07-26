using System.Collections.Generic;
using System;
using Pattern.ViewModels;

namespace Pattern.Component
{
    public interface IProductComponent
    {
        IEnumerable<ProductViewModel> GetMappedProducts(Guid clientId);
    }
}