using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pattern.DAL;
using Pattern.Domain;
using System.Linq;
using Pattern.Factories;
using Pattern.Mappers;
using Pattern.Component;

namespace Pattern.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductComponent productComponent;
        public HomeController(IProductComponent productComponent)
        {
            this.productComponent = productComponent ?? throw new ArgumentNullException(nameof(productComponent));
        }

        public IActionResult Index()
        {
            var firstMappedProduct = productComponent.GetMappedProducts(Guid.NewGuid())
                                                     .FirstOrDefault();
            return View("Index", viewModel);
        }

        public IActionResult IndexNull()
        {
            var firstMappedProduct = productComponent.GetMappedProducts(default(Guid))
                                                     .FirstOrDefault();

            return View("Index", firstMappedProduct);
        }
    }
}
