using System;
using Pattern.Domain;
using Pattern.ViewModels;
using Pattern.Factories;
using Pattern.DAL;
using System.Collections.Generic;
using Pattern.Mappers;

namespace Pattern.Component
{
    public class ProductComponent : IProductComponent
    {
        private readonly IClientRepository clientRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapperFactory mapperFactory;

        public ProductComponent(IClientRepository clientRepository,
                                IProductRepository productRepository,
                                IMapperFactory mapperFactory)
        {
            this.clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.mapperFactory = mapperFactory ?? throw new ArgumentNullException(nameof(mapperFactory));
        }

        public IEnumerable<ProductViewModel> GetMappedProducts(Guid clientId)
        {
            IClient client = clientRepository.Get(clientId);

            IEnumerable<IProduct> products = productRepository.GetClientProducts(client);

            IProductMapper productMapper = mapperFactory.CreateMapper<IProductMapper, IProduct>(products);

            IEnumerable<IProduct> processedProducts = productMapper.ApplyTVA(products);
            
            IProductViewModelMapper viewModelMapper = mapperFactory.CreateMapper<IProductViewModelMapper, IProduct>(processedProducts);

            IEnumerable<ProductViewModel> viewModel = viewModelMapper.MapToViewModel(processedProducts);

            return viewModel;
        }
    }
}
