using NetMarket.Core.Interfaces.Services;
using NetMarket.Core.Models;

namespace NetMarket.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly DataAccess.Interfaces.Services.IProductService _dataProductService;

        public ProductService(DataAccess.Interfaces.Services.IProductService dataProductService)
        {
            _dataProductService = dataProductService;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _dataProductService.Get();

            return products.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
            });
        }

        // TODO: make custom exception
        public async Task<Product> Get(int id)
        {
            var product = await _dataProductService.Get(id);

            if (product == null)
            {
                throw new Exception();
            }

            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }

        public async Task<Product> Create(Product product)
        {
            var dataProduct = await _dataProductService.Create(new DataAccess.Model.Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });

            return new Product
            {
                Id = dataProduct.Id,
                Name = dataProduct.Name,
                Description = dataProduct.Description,
                Price = dataProduct.Price,
            };
        }

        public async Task Update(int id, Product product)
        {
            product = await Get(id);

            await _dataProductService.Update(new DataAccess.Model.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            });
        }

        public async Task Delete(int id)
        {
            var product = await _dataProductService.Get(id);

            await _dataProductService.Delete(product.Id);
        }
    }
}
