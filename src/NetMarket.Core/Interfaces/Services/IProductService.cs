﻿using NetMarket.Core.Models;

namespace NetMarket.Core.Interfaces.Services
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
