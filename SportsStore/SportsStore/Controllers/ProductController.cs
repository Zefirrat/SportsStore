using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Services.Interfaces;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public ViewResult List() => View(_repository.Products.ToArray());
    }
}