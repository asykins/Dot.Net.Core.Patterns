using System;
using Pattern.Domain;
using Pattern.ViewModels;
using Pattern.Factories;
using Pattern.DAL;

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
            IClient client = clientRepository.Get(default(Guid));

            IEnumerable<IProduct> products = productRepository.GetClientProducts(client);

            IProducctMapper productMapper = mapperFactory.CreateMapper<IProductMapper>(products);

            IEnumerable<IProduct> processedProducts = productMapper.ApplyTVA(products);
            
            IProductViewModelMapper viewModelMapper = mapperFactory.CreateMapper<IProductViewModelMapper>(processedProducts);

            IEnumerable<ProductViewModel> viewModel = viewModelMapper.MapToViewModel(processedProducts);

            return viewModel;
        }
    }
}
