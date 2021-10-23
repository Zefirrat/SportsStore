using System.Linq;
using SportsStore.Models;

namespace SportsStore.Services.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}