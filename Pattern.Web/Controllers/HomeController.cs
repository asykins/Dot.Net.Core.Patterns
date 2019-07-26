using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pattern.DAL;
using Pattern.Domain;
using System.Linq;
using Pattern.Factories;
using Pattern.Mappers;

namespace Pattern.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository clientRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapperFactory mapperFactory;

        public HomeController(IClientRepository clientRepository, 
                              IProductRepository productRepository,
                              IMapperFactory mapperFactory)
        {
            this.clientRepository = clientRepository ?? throw new ArgumentException(nameof(clientRepository));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository)); 
            this.mapperFactory = mapperFactory ?? throw new ArgumentNullException(nameof(mapperFactory));
        }

        public IActionResult Index()
        {
            IClient client = clientRepository.Get(Guid.NewGuid());

            IEnumerable<IProduct> products = productRepository.GetClientProducts(client);

            var productMapper = mapperFactory.CreateMapper<IProductMapper, IProduct>(products);

            var processedProducts = productMapper.ApplyTVA(products);
            
            var viewModelMapper = mapperFactory.CreateMapper<IProductViewModelMapper, IProduct>(processedProducts);

            var viewModel = viewModelMapper.MapToViewModel(processedProducts).First();

            return View("Index", viewModel);
        }

        public IActionResult IndexNull()
        {
            IClient client = clientRepository.Get(default(Guid));

            IEnumerable<IProduct> products = productRepository.GetClientProducts(client);

            var productMapper = mapperFactory.CreateMapper<IProductMapper, IProduct>(products);

            var processedProducts = productMapper.ApplyTVA(products);
            
            var viewModelMapper = mapperFactory.CreateMapper<IProductViewModelMapper, IProduct>(processedProducts);

            var viewModel = viewModelMapper.MapToViewModel(processedProducts).First();

            return View("Index", viewModel);
        }
    }
}
