using System;
using System.Linq;
using Bogus;
using SportsStore.Models;
using SportsStore.Services.Interfaces;

namespace SportsStore.Services.Implementations
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly EnumerableQuery<Product> _products;

        public FakeProductRepository()
        {
            var faker = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(p => p.ProductId, f => f.UniqueIndex)
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Price, f => f.Random.Int())
                .RuleFor(p => p.Category, f => f.Commerce.Product());

            _products = new EnumerableQuery<Product>(
                new[]
                {
                    faker.Generate(),
                    faker.Generate(),
                    faker.Generate()
                });
        }

        public IQueryable<Product> Products => _products;
    }
}