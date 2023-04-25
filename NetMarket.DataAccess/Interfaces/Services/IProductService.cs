using NetMarket.DataAccess.Model;

namespace NetMarket.DataAccess.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();

        Task<Product> Get(int id);

        Task<Product> Create(Product product);

        Task Update(Product product);

        Task Delete(int id);
    }
}
