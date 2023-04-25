using NetMarket.DataAccess.Interfaces.Services;
using NetMarket.DataAccess.Model;

namespace NetMarket.DataAccess.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
