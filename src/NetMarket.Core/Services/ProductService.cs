using NetMarket.Core.Interfaces.Services;
using NetMarket.Core.Models;

namespace NetMarket.Core.Services
{
    public class ProductService : IProductService
    {
        private IEnumerable<Product> _mockProducts;

        public ProductService()
        {
            _mockProducts = new List<Product>
            {
                new()
                {
                    Id = 1,
                    Name = "Computer",
                    Description = "Gaming PC",
                    Price = 1099.99m
                },
                new()
                {
                    Id = 2,
                    Name = "Chair",
                    Description = "Wood chair",
                    Price = 89.99m
                },
            };
        }

        public Task<IEnumerable<Product>> Get()
        {
            return Task.Run(() => _mockProducts);
        }

        public Task<Product> Get(int id)
        {
            return Task.Run(() => _mockProducts.FirstOrDefault(p => p.Id == id) ?? throw new NullReferenceException());
        }
    }
}
